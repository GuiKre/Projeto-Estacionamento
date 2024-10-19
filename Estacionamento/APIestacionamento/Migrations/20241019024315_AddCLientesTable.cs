using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIestacionamento.Migrations
{
    /// <inheritdoc />
    public partial class AddCLientesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Carros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ClienteId",
                table: "Carros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Clientes_ClienteId",
                table: "Carros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Clientes_ClienteId",
                table: "Carros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Carros_ClienteId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carros");
        }
    }
}
