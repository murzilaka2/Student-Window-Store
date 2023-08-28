using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class OrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "OrderStatus",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "New");

            migrationBuilder.AddCheckConstraint(
                name: "OrderStatus",
                table: "Orders",
                sql: "(OrderStatus in ('New','Sent','Paid','Cancelled'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "New");

            migrationBuilder.AddCheckConstraint(
                name: "OrderStatus",
                table: "OrderDetails",
                sql: "(OrderStatus in ('New','Sent','Paid','Cancelled'))");
        }
    }
}
