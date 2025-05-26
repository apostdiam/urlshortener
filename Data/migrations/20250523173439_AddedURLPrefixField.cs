using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL_Shortener.data.migrations
{
    /// <inheritdoc />
    public partial class AddedURLPrefixField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortenedUrlPrefix",
                table: "UrlLinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortenedUrlPrefix",
                table: "UrlLinks");
        }
    }
}
