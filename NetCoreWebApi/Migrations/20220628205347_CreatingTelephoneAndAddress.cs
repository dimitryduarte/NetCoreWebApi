using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreWebApi.Migrations
{
    public partial class CreatingTelephoneAndAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Customers");
        }
    }
}
