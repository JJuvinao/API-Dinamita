using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Dinamita.Migrations
{
    /// <inheritdoc />
    public partial class CambiosEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tickets_Vendidos",
                table: "Eventos",
                newName: "Tickets_Disponibles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tickets_Disponibles",
                table: "Eventos",
                newName: "Tickets_Vendidos");
        }
    }
}
