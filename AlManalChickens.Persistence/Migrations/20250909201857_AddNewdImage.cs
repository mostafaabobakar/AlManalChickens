using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlManalChickens.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewdImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");
        }
    }
}
