using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL_Shortener.data.migrations
{
    /// <inheritdoc />
    public partial class AddedUserAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisitorsUserAgent",
                table: "UrlLinks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitorsUserAgent",
                table: "UrlLinks");
        }
    }
}
