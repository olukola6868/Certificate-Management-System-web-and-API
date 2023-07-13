using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertificateManagementApi.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isGenerated",
                table: "Certificates",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGenerated",
                table: "Certificates");
        }
    }
}
