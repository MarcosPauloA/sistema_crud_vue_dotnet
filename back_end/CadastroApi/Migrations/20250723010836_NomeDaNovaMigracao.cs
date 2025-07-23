using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroApi.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaNovaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Regioes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Regioes");
        }
    }
}
