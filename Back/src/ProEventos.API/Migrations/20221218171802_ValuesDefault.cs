using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.API.Migrations
{
    public partial class ValuesDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "DataEvento", "ImageURL", "Local", "Lote", "QtdPessoas", "Tema" },
                values: new object[] { 1, "03/10/1987", "foto.png", "Brasilia", "1", 50, "Asp net core" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "DataEvento", "ImageURL", "Local", "Lote", "QtdPessoas", "Tema" },
                values: new object[] { 2, "18/10/1954", "foto2.png", "Goiânia", "2", 150, "Angular" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 2);
        }
    }
}
