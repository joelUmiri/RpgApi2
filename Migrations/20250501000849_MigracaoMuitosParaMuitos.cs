using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 107, 147, 91, 255, 107, 220, 45, 76, 61, 132, 214, 106, 164, 30, 10, 72, 235, 15, 239, 177, 248, 240, 154, 236, 67, 114, 155, 218, 96, 148, 66, 159, 82, 115, 90, 251, 184, 130, 54, 24, 200, 163, 64, 107, 79, 34, 123, 121, 158, 214, 32, 34, 75, 162, 183, 150, 252, 33, 159, 76, 30, 127, 36, 3 }, new byte[] { 245, 3, 253, 40, 124, 161, 141, 152, 214, 218, 32, 96, 219, 54, 63, 118, 63, 59, 178, 58, 46, 37, 88, 203, 68, 21, 32, 230, 219, 248, 64, 34, 133, 85, 121, 101, 83, 201, 212, 69, 249, 149, 164, 193, 211, 195, 250, 156, 8, 62, 247, 155, 60, 4, 147, 122, 196, 116, 177, 216, 105, 103, 26, 171, 241, 100, 84, 139, 60, 32, 73, 115, 199, 26, 19, 185, 220, 102, 24, 180, 170, 186, 29, 86, 186, 174, 76, 198, 204, 54, 249, 66, 148, 87, 175, 135, 133, 141, 5, 77, 60, 155, 50, 128, 166, 176, 62, 44, 235, 132, 38, 62, 151, 220, 186, 47, 71, 208, 20, 161, 170, 224, 71, 1, 57, 77, 102, 140 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 86, 42, 183, 131, 17, 58, 14, 84, 16, 183, 56, 72, 160, 118, 145, 111, 122, 67, 226, 90, 109, 147, 65, 106, 121, 107, 38, 88, 236, 216, 101, 134, 40, 162, 98, 253, 29, 176, 127, 19, 192, 68, 32, 245, 84, 17, 200, 173, 199, 174, 239, 14, 71, 191, 136, 110, 13, 22, 11, 141, 112, 175, 85, 149 }, new byte[] { 125, 122, 106, 190, 109, 226, 227, 35, 43, 176, 142, 129, 64, 162, 148, 170, 222, 242, 226, 95, 4, 184, 180, 58, 71, 131, 29, 54, 242, 101, 201, 251, 150, 234, 153, 28, 15, 219, 180, 206, 208, 183, 15, 232, 150, 243, 204, 163, 38, 185, 16, 40, 160, 99, 205, 222, 29, 195, 57, 167, 12, 58, 154, 61, 221, 252, 201, 122, 139, 213, 217, 147, 18, 104, 148, 59, 9, 227, 34, 185, 32, 216, 92, 175, 248, 101, 244, 158, 224, 135, 9, 197, 148, 236, 85, 103, 134, 29, 72, 17, 116, 137, 97, 230, 79, 184, 67, 112, 91, 134, 107, 216, 99, 27, 112, 135, 29, 61, 211, 87, 218, 178, 171, 142, 232, 136, 77, 127 } });
        }
    }
}
