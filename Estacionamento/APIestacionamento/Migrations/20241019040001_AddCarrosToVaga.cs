using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIestacionamento.Migrations
{
    /// <inheritdoc />
    public partial class AddCarrosToVaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carros_VagaId",
                table: "Carros");

            migrationBuilder.AddColumn<int>(
                name: "VagaId1",
                table: "Carros",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_VagaId",
                table: "Carros",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_VagaId1",
                table: "Carros",
                column: "VagaId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Vagas_VagaId1",
                table: "Carros",
                column: "VagaId1",
                principalTable: "Vagas",
                principalColumn: "VagaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Vagas_VagaId1",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_VagaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_VagaId1",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "VagaId1",
                table: "Carros");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_VagaId",
                table: "Carros",
                column: "VagaId",
                unique: true);
        }
    }
}
