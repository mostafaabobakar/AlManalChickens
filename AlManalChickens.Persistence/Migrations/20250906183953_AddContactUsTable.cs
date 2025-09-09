using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlManalChickens.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddContactUsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ContactUs");
        }
    }
}
