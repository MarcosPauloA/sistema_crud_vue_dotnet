using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroApi.Migrations
{
    /// <inheritdoc />
    public partial class UniqueUfNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Regioes_Uf_Nome",
                table: "Regioes",
                columns: new[] { "Uf", "Nome" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Regioes_Uf_Nome",
                table: "Regioes");
        }
    }
}
