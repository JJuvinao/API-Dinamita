using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Dinamita.Migrations
{
    /// <inheritdoc />
    public partial class cambiar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tickets_Disponibles",
                table: "Eventos",
                newName: "Tickets_Disponible");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tickets_Disponible",
                table: "Eventos",
                newName: "Tickets_Disponibles");
        }
    }
}
