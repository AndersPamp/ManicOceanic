using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicOceanic.DOMAIN.Migrations
{
    public partial class AddConstraintsToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SocialSecurityNumber",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_SocialSecurityNumber",
                table: "Customers",
                column: "SocialSecurityNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_SocialSecurityNumber",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "SocialSecurityNumber",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
