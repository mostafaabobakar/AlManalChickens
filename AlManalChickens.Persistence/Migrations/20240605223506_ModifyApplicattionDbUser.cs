using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlManalChickens.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyApplicattionDbUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgProfile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lang",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "Settings",
                newName: "SenderNameSms");

            migrationBuilder.RenameColumn(
                name: "DeviceId_",
                table: "DeviceIds",
                newName: "Identifier");

            migrationBuilder.RenameColumn(
                name: "user_Name",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "TypeUser",
                table: "AspNetUsers",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "AspNetUsers",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CloseNotify",
                table: "AspNetUsers",
                newName: "IsCodeActivated");

            migrationBuilder.RenameColumn(
                name: "ActiveCode",
                table: "AspNetUsers",
                newName: "AllowNotify");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoponUsed_CoponId",
                table: "CoponUsed",
                column: "CoponId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoponUsed_Copon_CoponId",
                table: "CoponUsed",
                column: "CoponId",
                principalTable: "Copon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoponUsed_Copon_CoponId",
                table: "CoponUsed");

            migrationBuilder.DropIndex(
                name: "IX_CoponUsed_CoponId",
                table: "CoponUsed");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SenderNameSms",
                table: "Settings",
                newName: "SenderName");

            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "DeviceIds",
                newName: "DeviceId_");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "AspNetUsers",
                newName: "TypeUser");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "AspNetUsers",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "IsCodeActivated",
                table: "AspNetUsers",
                newName: "CloseNotify");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "user_Name");

            migrationBuilder.RenameColumn(
                name: "AllowNotify",
                table: "AspNetUsers",
                newName: "ActiveCode");

            migrationBuilder.AddColumn<string>(
                name: "ImgProfile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
