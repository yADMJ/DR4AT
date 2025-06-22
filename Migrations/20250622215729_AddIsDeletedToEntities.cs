using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DR4AT.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PacoteTuristicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CidadeDestinos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PacoteTuristicos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CidadeDestinos");
        }
    }
}
