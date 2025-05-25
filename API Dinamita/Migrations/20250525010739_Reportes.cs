using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Dinamita.Migrations
{
    /// <inheritdoc />
    public partial class Reportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Reportes",
               columns: table => new
               {
                   Id_Reporte = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Nombre_Reporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Nombre_Evento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   N_Ventas = table.Column<int>(type: "int", nullable: false),
                   N_Asistencias = table.Column<int>(type: "int", nullable: false),
                   Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Reportes", x => x.Id_Reporte);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reportes");
        }
    }
}
