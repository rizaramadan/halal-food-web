using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class tsvectornullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Restaurants",
                type: "tsvector",
                nullable: true,
                oldClrType: typeof(NpgsqlTsVector),
                oldType: "tsvector")
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name", "Address", "Category", "HalalClaimDetails", "HalalCertificationNumber" })
                .OldAnnotation("Npgsql:TsVectorConfig", "english")
                .OldAnnotation("Npgsql:TsVectorProperties", new[] { "Name", "Address", "Category", "HalalClaimDetails", "HalalCertificationNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Restaurants",
                type: "tsvector",
                nullable: false,
                oldClrType: typeof(NpgsqlTsVector),
                oldType: "tsvector",
                oldNullable: true)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name", "Address", "Category", "HalalClaimDetails", "HalalCertificationNumber" })
                .OldAnnotation("Npgsql:TsVectorConfig", "english")
                .OldAnnotation("Npgsql:TsVectorProperties", new[] { "Name", "Address", "Category", "HalalClaimDetails", "HalalCertificationNumber" });
        }
    }
}
