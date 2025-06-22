using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DR4AT.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CidadeDestinoId",
                table: "PacoteTuristicos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacoteTuristicos_CidadeDestinoId",
                table: "PacoteTuristicos",
                column: "CidadeDestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PacoteTuristicos_CidadeDestinos_CidadeDestinoId",
                table: "PacoteTuristicos",
                column: "CidadeDestinoId",
                principalTable: "CidadeDestinos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacoteTuristicos_CidadeDestinos_CidadeDestinoId",
                table: "PacoteTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_PacoteTuristicos_CidadeDestinoId",
                table: "PacoteTuristicos");

            migrationBuilder.DropColumn(
                name: "CidadeDestinoId",
                table: "PacoteTuristicos");
        }
    }
}
