using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.Extensions.Logging;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;
        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                //Programação dos próximos passos aqui
                Personagem? atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem? oponente = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(p => p.Id == d.OponentId);

                int dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));

                dano = dano - new Random().Next(oponente.Defesa);

                    if (dano > 0)
                        oponente.PontosVida = oponente.PontosVida - (int)dano;
                    if (oponente.PontosVida <= 0)
                        d.Narracao = $"{oponente.Nome} foi derrotado!";
                    
                    _context.TB_PERSONAGENS.Update(oponente);
                    await _context.SaveChangesAsync();

                    StringBuilder dados = new StringBuilder();
                    dados.AppendFormat(" Atacante: {0}. ", atacante.Nome);
                    dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                    dados.AppendFormat(" Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                    dados.AppendFormat(" Pontos de vida do oponente: {0}. ", atacante.Arma.Nome);
                    dados.AppendFormat(" Dano: {0}. ", dano);
                    
                    d.Narracao += dados.ToString();
                    d.DataDisputa = DateTime.Now;
                    _context.TB_DISPUTAS.Add(d);
                    _context.SaveChanges();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                //Programação dos próximos passos aqui
                Personagem atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ph => ph.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);
                
                Personagem oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponentId);
                
                PersonagemHabilidade ph = await _context.TB_PERSONAGENS_HABILIDADES
                    .Include(p => p.Habilidade).FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId && phBusca.PersonagemId == d.AtacanteId);
                
                if (ph == null)
                    d.Narracao = $"{atacante.Nome} não possui esta habilidade";
                else
                {
                    int dano = ph.Habilidade.Dano + (new Random().Next(atacante.Inteligencia));

                    if (dano > 0)
                        oponente.PontosVida = oponente.PontosVida - dano;
                    if (oponente.PontosVida <= 0)
                        d.Narracao += $"{oponente.Nome} foi derrotado!";
                    _context.TB_PERSONAGENS.Update(oponente);
                    await _context.SaveChangesAsync();

                    StringBuilder dados = new StringBuilder();
                    dados.AppendFormat(" Atacante: {0}. ", atacante.Nome);
                    dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                    dados.AppendFormat(" Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                    dados.AppendFormat(" Pontos de vida do oponente: {0}. ", atacante.Arma.Nome);
                    dados.AppendFormat(" Dano: {0}. ", dano);
                    
                    d.Narracao += dados.ToString();
                    d.DataDisputa = DateTime.Now;
                    _context.TB_DISPUTAS.Add(d);
                    _context.SaveChanges();
                }
                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DisputaEmGrupo")]
        public async Task<IActionResult> DisputaEmGrupoAsync(Disputa d)
        {
            try
            {
                d.Resultados = new List<string>();//Instância a listade resultados

                //Busca na base dos personagens informados o parâmetro incluindo Armas e Habilidades
                List<Personagem> personagens = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ph => ph.Habilidade)
                    .Where(p => d.ListaIdPersonagens.Contains(p.Id)).ToListAsync();
                
                //Contagem de personagens vivos na lista obtida no banco de dados
                int qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;

                //Enquanto haver mais de um poersonagem vivo haverá disputa
                while (qtdPersonagensVivos > 1)
                {
                    //ATENÇÂO: todas as eteapas a seguir devem ficar aqui dentro do while
                    //Seleciona personagens com pontos de vida positivos e dps faz sorteio.
                    List<Personagem> atacantes = personagens.Where(p => p.PontosVida > 0).ToList();
                    Personagem atacante = atacantes[new Random().Next(atacantes.Count)];

                    //Seleciona personagens com pontos de vida positivos, exceto o atacante escolhido e depois faz sorteio.
                    List<Personagem> oponentes = personagens.Where(p => p.Id != atacante.Id && p.PontosVida > 0).ToList();
                    Personagem oponente = oponentes[new Random().Next(oponentes.Count)];
                    d.OponentId = oponente.Id;

                    //Declara e redefine a cada passagem do while o valor das variáveis que serão usadas.
                    int dano = 0;
                    string ataqueUsado = string.Empty;
                    string resultado = string.Empty;

                    //Sorteia entre 0 e 1: 0 é um ataque com arma e 1 é um ataque com habilidades
                    bool ataqueUsaArma = (new Random().Next(1) == 0);

                    if (ataqueUsaArma && atacante.Arma != null)
                    {
                        //Programação do ataque com arma
                    }
                    else if (atacante.PersonagemHabilidades.Count != 0)//Verifica se o personagem tem habilidades
                    {
                        //Programação do ataque com hablidades
                    }

                }
                //Código após o fechamentodo while, atualizará os pontos de vida,
                //disputas, vitórias e derrotas de todos os personagens ao final das batalhas
                _context.TB_PERSONAGENS.UpdateRange(personagens);
                await _context.SaveChangesAsync();

                return Ok(d);//retorna os dados das disputas
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}