using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBills.Infrastructure.Migrations
{
    public partial class AddedRelationUserBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bills_BillId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BillId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAppId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserAppId1",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserAppId1",
                table: "Bills",
                column: "UserAppId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_UserAppId1",
                table: "Bills",
                column: "UserAppId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_UserAppId1",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_UserAppId1",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserAppId1",
                table: "Bills");

            migrationBuilder.AddColumn<Guid>(
                name: "BillId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BillId",
                table: "AspNetUsers",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bills_BillId",
                table: "AspNetUsers",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
