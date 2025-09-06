using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlManalChickens.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveAndIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PartnersSuccesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PartnersSuccesses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PartnersSuccesses");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PartnersSuccesses");
        }
    }
}
