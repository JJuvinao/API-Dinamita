using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Dinamita.Migrations
{
    /// <inheritdoc />
    public partial class CambiosTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Eventos_EventosId_Evento",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventosId_Evento",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventosId_Evento",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Tickets",
                newName: "CodigoAlfanumerico");

            migrationBuilder.RenameColumn(
                name: "Duracion",
                table: "Eventos",
                newName: "Tickets_Vendidos");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "CodigoQR",
                table: "Tickets",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<float>(
                name: "PrecioTicket",
                table: "Eventos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoQR",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PrecioTicket",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "CodigoAlfanumerico",
                table: "Tickets",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "Tickets_Vendidos",
                table: "Eventos",
                newName: "Duracion");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventosId_Evento",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventosId_Evento",
                table: "Tickets",
                column: "EventosId_Evento");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Eventos_EventosId_Evento",
                table: "Tickets",
                column: "EventosId_Evento",
                principalTable: "Eventos",
                principalColumn: "Id_Evento");
        }
    }
}
