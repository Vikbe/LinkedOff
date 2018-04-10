using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LinkedOff.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusUpdates_AspNetUsers_UserId",
                table: "StatusUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusUpdates",
                table: "StatusUpdates");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "StatusUpdates");

            migrationBuilder.RenameTable(
                name: "StatusUpdates",
                newName: "Timeline");

            migrationBuilder.RenameIndex(
                name: "IX_StatusUpdates_UserId",
                table: "Timeline",
                newName: "IX_Timeline_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeline",
                table: "Timeline",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StatusUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    TimelineId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusUpdates_Timeline_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timeline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatusUpdates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusUpdates_TimelineId",
                table: "StatusUpdates",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusUpdates_UserId",
                table: "StatusUpdates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeline_AspNetUsers_UserId",
                table: "Timeline",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeline_AspNetUsers_UserId",
                table: "Timeline");

            migrationBuilder.DropTable(
                name: "StatusUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeline",
                table: "Timeline");

            migrationBuilder.RenameTable(
                name: "Timeline",
                newName: "StatusUpdates");

            migrationBuilder.RenameIndex(
                name: "IX_Timeline_UserId",
                table: "StatusUpdates",
                newName: "IX_StatusUpdates_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "StatusUpdates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusUpdates",
                table: "StatusUpdates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusUpdates_AspNetUsers_UserId",
                table: "StatusUpdates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
