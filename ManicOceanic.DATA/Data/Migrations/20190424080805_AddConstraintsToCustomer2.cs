using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicOceanic.DOMAIN.Migrations
{
    public partial class AddConstraintsToCustomer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_CustomerNumber",
                table: "Customers",
                column: "CustomerNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_CustomerNumber",
                table: "Customers");
        }
    }
}
