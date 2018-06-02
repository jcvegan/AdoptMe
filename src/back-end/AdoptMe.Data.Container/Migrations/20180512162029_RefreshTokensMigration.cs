using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdoptMe.Data.Container.Migrations
{
    public partial class RefreshTokensMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpiresUtc = table.Column<DateTime>(nullable: false),
                    IssuedUtc = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.UniqueConstraint("RefreshToken_Token", x => x.Token);
                    table.UniqueConstraint("RefreshToken_UserId", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId1",
                table: "RefreshTokens",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");
        }
    }
}
