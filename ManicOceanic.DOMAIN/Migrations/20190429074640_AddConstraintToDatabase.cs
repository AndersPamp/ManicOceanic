using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicOceanic.DOMAIN.Migrations
{
    public partial class AddConstraintToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Administrators",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Administrators",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_UserName",
                table: "Customers",
                column: "UserName");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Administrators_AdminName",
                table: "Administrators",
                column: "AdminName");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Administrators_UserName",
                table: "Administrators",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_UserName",
                table: "Customers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Administrators_AdminName",
                table: "Administrators");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Administrators_UserName",
                table: "Administrators");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Administrators",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Administrators",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
