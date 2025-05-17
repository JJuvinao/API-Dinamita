using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Dinamita.Migrations
{
    /// <inheritdoc />
    public partial class Carrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarritoId_Carrito",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    Id_Carrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Carrito_CarritoId_Carrito",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CarritoId_Carrito",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CarritoId_Carrito",
                table: "Tickets");
        }
    }
}
