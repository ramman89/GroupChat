using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupChat.Migrations
{
    public partial class intialmigrartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MessageBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rMessages_rGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "rGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rMessageLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rMessageLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rMessageLikes_rMessages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "rMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageLikeId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rUsers_rMessageLikes_MessageLikeId",
                        column: x => x.MessageLikeId,
                        principalTable: "rMessageLikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rMessageLikes_MessageId",
                table: "rMessageLikes",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_rMessages_GroupId",
                table: "rMessages",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_rUsers_MessageLikeId",
                table: "rUsers",
                column: "MessageLikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rUsers");

            migrationBuilder.DropTable(
                name: "rMessageLikes");

            migrationBuilder.DropTable(
                name: "rMessages");

            migrationBuilder.DropTable(
                name: "rGroups");
        }
    }
}
