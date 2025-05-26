using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL_Shortener.data.migrations
{
    /// <inheritdoc />
    public partial class IpAddressModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VisitorsIpAddress",
                table: "UrlLinks",
                type: "nvarchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VisitorsIpAddress",
                table: "UrlLinks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldNullable: true);
        }
    }
}
