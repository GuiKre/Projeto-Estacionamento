using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIestacionamento.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacaoUmParaUmCarroVaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VagaId",
                table: "Carros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_VagaId",
                table: "Carros",
                column: "VagaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Vagas_VagaId",
                table: "Carros",
                column: "VagaId",
                principalTable: "Vagas",
                principalColumn: "VagaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Vagas_VagaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_VagaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "VagaId",
                table: "Carros");
        }
    }
}
