using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        //Codoficação geral dentro do corpo da controller.
        private readonly DataContext _context;
        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {
                //Código aqui
                Personagem personagem = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)
                    throw new System.Exception("Personagem não informado para o Id informado.");
                
                Habilidade habilidade = await _context.TB_HABILIDADES
                                    .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if (habilidade == null)
                    throw new System.Exception("Habilidade não encontrada.");

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}