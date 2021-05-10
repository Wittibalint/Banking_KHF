using Microsoft.EntityFrameworkCore.Migrations;

namespace Banking.data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OuterAccount",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.AddColumn<long>(
                name: "OuterAccount",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
