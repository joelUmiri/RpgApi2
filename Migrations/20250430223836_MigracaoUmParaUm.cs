using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 86, 42, 183, 131, 17, 58, 14, 84, 16, 183, 56, 72, 160, 118, 145, 111, 122, 67, 226, 90, 109, 147, 65, 106, 121, 107, 38, 88, 236, 216, 101, 134, 40, 162, 98, 253, 29, 176, 127, 19, 192, 68, 32, 245, 84, 17, 200, 173, 199, 174, 239, 14, 71, 191, 136, 110, 13, 22, 11, 141, 112, 175, 85, 149 }, new byte[] { 125, 122, 106, 190, 109, 226, 227, 35, 43, 176, 142, 129, 64, 162, 148, 170, 222, 242, 226, 95, 4, 184, 180, 58, 71, 131, 29, 54, 242, 101, 201, 251, 150, 234, 153, 28, 15, 219, 180, 206, 208, 183, 15, 232, 150, 243, 204, 163, 38, 185, 16, 40, 160, 99, 205, 222, 29, 195, 57, 167, 12, 58, 154, 61, 221, 252, 201, 122, 139, 213, 217, 147, 18, 104, 148, 59, 9, 227, 34, 185, 32, 216, 92, 175, 248, 101, 244, 158, 224, 135, 9, 197, 148, 236, 85, 103, 134, 29, 72, 17, 116, 137, 97, 230, 79, 184, 67, 112, 91, 134, 107, 216, 99, 27, 112, 135, 29, 61, 211, 87, 218, 178, 171, 142, 232, 136, 77, 127 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 240, 96, 113, 191, 159, 232, 30, 139, 235, 116, 36, 218, 25, 206, 42, 163, 123, 83, 205, 150, 237, 153, 70, 160, 173, 209, 213, 244, 240, 192, 135, 145, 3, 209, 53, 215, 84, 205, 103, 231, 39, 6, 71, 181, 249, 116, 13, 1, 40, 181, 10, 21, 225, 106, 98, 24, 92, 208, 162, 174, 145, 134, 211, 20 }, new byte[] { 223, 221, 125, 114, 220, 124, 4, 112, 85, 154, 223, 255, 34, 65, 240, 242, 30, 0, 198, 121, 194, 224, 234, 111, 213, 17, 39, 32, 54, 3, 213, 192, 145, 21, 25, 165, 170, 50, 150, 234, 20, 178, 81, 32, 120, 213, 36, 51, 205, 190, 180, 189, 150, 2, 24, 21, 232, 83, 162, 0, 127, 169, 233, 92, 136, 46, 13, 85, 137, 68, 132, 182, 82, 221, 169, 77, 175, 188, 161, 197, 41, 217, 178, 139, 163, 124, 81, 81, 56, 161, 143, 171, 82, 203, 253, 253, 167, 202, 87, 199, 18, 124, 19, 15, 193, 18, 50, 226, 81, 253, 143, 233, 124, 108, 201, 235, 35, 180, 102, 234, 120, 237, 43, 123, 49, 197, 61, 42 } });
        }
    }
}
