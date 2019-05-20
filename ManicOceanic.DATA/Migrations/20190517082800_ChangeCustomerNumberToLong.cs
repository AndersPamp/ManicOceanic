using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicOceanic.DATA.Migrations
{
    public partial class ChangeCustomerNumberToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_CustomerNumber",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerNumber",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerNumber",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_CustomerNumber",
                table: "AspNetUsers",
                column: "CustomerNumber");
        }
    }
}
