using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicOceanic.DATA.Migrations
{
    public partial class RemoveOrderFromOrderLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderLines",
                nullable: false,
                defaultValue: 0);
        }
    }
}
