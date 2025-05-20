using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Dinamita.Migrations
{
    /// <inheritdoc />
    public partial class CambioCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Carrito_CarritoId_Carrito",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Eventos_EventosId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CarritoId_Carrito",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CarritoId_Carrito",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id_Administrador",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "Id_Carrito",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "Id_Carrito",
                table: "Tickets",
                newName: "Id_Usuario");

            migrationBuilder.RenameColumn(
                name: "EventosId",
                table: "Tickets",
                newName: "EventosId_Evento");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EventosId",
                table: "Tickets",
                newName: "IX_Tickets_EventosId_Evento");

            migrationBuilder.RenameColumn(
                name: "Dirreccion_Lugar",
                table: "Eventos",
                newName: "Direccion_Lugar");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Eventos",
                newName: "Id_Evento");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Eventos_EventosId_Evento",
                table: "Tickets",
                column: "EventosId_Evento",
                principalTable: "Eventos",
                principalColumn: "Id_Evento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Eventos_EventosId_Evento",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "Tickets",
                newName: "Id_Carrito");

            migrationBuilder.RenameColumn(
                name: "EventosId_Evento",
                table: "Tickets",
                newName: "EventosId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EventosId_Evento",
                table: "Tickets",
                newName: "IX_Tickets_EventosId");

            migrationBuilder.RenameColumn(
                name: "Direccion_Lugar",
                table: "Eventos",
                newName: "Dirreccion_Lugar");

            migrationBuilder.RenameColumn(
                name: "Id_Evento",
                table: "Eventos",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId_Carrito",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Administrador",
                table: "Reportes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Carrito",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    Id_Carrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.Id_Carrito);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CarritoId_Carrito",
                table: "Tickets",
                column: "CarritoId_Carrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Carrito_CarritoId_Carrito",
                table: "Tickets",
                column: "CarritoId_Carrito",
                principalTable: "Carrito",
                principalColumn: "Id_Carrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Eventos_EventosId",
                table: "Tickets",
                column: "EventosId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }
    }
}
