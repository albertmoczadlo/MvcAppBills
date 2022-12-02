using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBills.Infrastructure.Migrations
{
    public partial class fixId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_UserAppId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_UserAppId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "UserAppsId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserAppsId",
                table: "Bills",
                column: "UserAppsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_UserAppsId",
                table: "Bills",
                column: "UserAppsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_UserAppsId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_UserAppsId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserAppsId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "UserAppId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserAppId",
                table: "Bills",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_UserAppId",
                table: "Bills",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
