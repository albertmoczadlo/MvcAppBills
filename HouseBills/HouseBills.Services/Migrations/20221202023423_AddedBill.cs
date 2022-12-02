using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBills.Infrastructure.Migrations
{
    public partial class AddedBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BlockEnergy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Heating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ColdWater = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeatingWater = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RenovationFund = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserAppId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_AspNetUsers_UserAppId",
                        column: x => x.UserAppId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserAppId",
                table: "Bills",
                column: "UserAppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");
        }
    }
}
