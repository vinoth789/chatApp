using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatEntries_UserEntries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatEntries_UserEntries_usersId",
                        column: x => x.usersId,
                        principalTable: "UserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserEntries",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Role", "Username" },
                values: new object[] { 1, "vinoth@gmail.com", "Vinoth", "Moorthy", "Admin", "vinoth" });

            migrationBuilder.InsertData(
                table: "UserEntries",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Role", "Username" },
                values: new object[] { 2, "chittu@gmail.com", "Vivek", "Moorthy", "User", "chittu" });

            migrationBuilder.InsertData(
                table: "ChatEntries",
                columns: new[] { "Id", "CreatedTimestamp", "Message", "UserId", "usersId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hello dad*", 1, null });

            migrationBuilder.InsertData(
                table: "ChatEntries",
                columns: new[] { "Id", "CreatedTimestamp", "Message", "UserId", "usersId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hello dad!", 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_ChatEntries_UserId",
                table: "ChatEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEntries_usersId",
                table: "ChatEntries",
                column: "usersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatEntries");

            migrationBuilder.DropTable(
                name: "UserEntries");
        }
    }
}
