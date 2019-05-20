using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicOceanic.DATA.Migrations
{
    public partial class AddUniqueCustomerNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_CustomerNumber",
                table: "AspNetUsers",
                column: "CustomerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_CustomerNumber",
                table: "AspNetUsers");
        }
    }
}
