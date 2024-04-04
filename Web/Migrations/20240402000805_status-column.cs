using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class statuscolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Restaurants",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name", "Address", "Category", "HalalClaimDetails", "HalalCertificationNumber" });

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_SearchVector",
                table: "Restaurants",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurants_SearchVector",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Restaurants");
        }
    }
}
