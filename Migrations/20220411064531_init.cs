using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_System.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.TicketTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketAction",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAction", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_TicketAction_TicketType_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketType",
                        principalColumn: "TicketTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypeRules",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypeRules", x => new { x.RoleId, x.TicketTypeId });
                    table.ForeignKey(
                        name: "FK_TicketTypeRules_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTypeRules_TicketType_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketType",
                        principalColumn: "TicketTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketsId);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketType_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketType",
                        principalColumn: "TicketTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketActionRules",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    TicketActionId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketActionRules", x => new { x.RoleId, x.TicketActionId });
                    table.ForeignKey(
                        name: "FK_TicketActionRules_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketActionRules_TicketAction_TicketActionId",
                        column: x => x.TicketActionId,
                        principalTable: "TicketAction",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "QA" },
                    { 2, "RD" },
                    { 3, "PM" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "TicketType",
                columns: new[] { "TicketTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Bug" },
                    { 2, "Feature Request" },
                    { 3, "Test Case" }
                });

            migrationBuilder.InsertData(
                table: "TicketAction",
                columns: new[] { "ActionId", "ActionName", "TicketTypeId" },
                values: new object[,]
                {
                    { 1, "Add", 1 },
                    { 2, "Delete", 1 },
                    { 3, "Edit", 1 },
                    { 4, "Resolve", 1 },
                    { 5, "Add", 2 },
                    { 6, "Delete", 2 },
                    { 7, "Edit", 2 },
                    { 8, "Resolve", 2 },
                    { 9, "Add", 3 },
                    { 10, "Delete", 3 },
                    { 11, "Edit", 3 },
                    { 12, "Resolve", 3 }
                });

            migrationBuilder.InsertData(
                table: "TicketTypeRules",
                columns: new[] { "RoleId", "TicketTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password", "UserRoleId" },
                values: new object[,]
                {
                    { 1, "QA", "QA", 1 },
                    { 2, "RD", "RD", 2 },
                    { 3, "PM", "PM", 3 },
                    { 4, "Admin", "Admin", 4 }
                });

            migrationBuilder.InsertData(
                table: "TicketActionRules",
                columns: new[] { "RoleId", "TicketActionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 9 },
                    { 1, 12 },
                    { 2, 4 },
                    { 2, 8 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketsId", "CreateTime", "Description", "Priority", "Severity", "Summary", "TicketTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 11, 14, 45, 30, 817, DateTimeKind.Local).AddTicks(8580), "👾", null, null, "12qqqq3rrr", 1, 1 },
                    { 2, new DateTime(2022, 4, 11, 14, 45, 30, 817, DateTimeKind.Local).AddTicks(8593), "😂", null, null, "123rttrtrrr", 1, 1 },
                    { 3, new DateTime(2022, 4, 11, 14, 45, 30, 817, DateTimeKind.Local).AddTicks(8595), "😀", null, null, "123xxxxrrr", 2, 3 },
                    { 4, new DateTime(2022, 4, 11, 14, 45, 30, 817, DateTimeKind.Local).AddTicks(8596), "😎", null, null, "123ssssrrr", 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketAction_TicketTypeId",
                table: "TicketAction",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketActionRules_TicketActionId",
                table: "TicketActionRules",
                column: "TicketActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypeRules_TicketTypeId",
                table: "TicketTypeRules",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                table: "User",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketActionRules");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketTypeRules");

            migrationBuilder.DropTable(
                name: "TicketAction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
