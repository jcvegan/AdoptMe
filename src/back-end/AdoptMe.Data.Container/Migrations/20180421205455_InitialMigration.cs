using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdoptMe.Data.Container.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Pet");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "PetTypes",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "Pet",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    History = table.Column<string>(nullable: true),
                    IsAdoptionAvailable = table.Column<bool>(nullable: false),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    LastModifiedUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    PetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_PetTypes_PetTypeId",
                        column: x => x.PetTypeId,
                        principalSchema: "Master",
                        principalTable: "PetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdoptionRequests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    LastModifiedUserId = table.Column<string>(nullable: true),
                    PetId = table.Column<long>(nullable: false),
                    Request = table.Column<string>(nullable: true),
                    RequestedById = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionRequests_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdoptionRequests_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdoptionRequests_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pet",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionRequests_Users_RequestedById",
                        column: x => x.RequestedById,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    PetId = table.Column<long>(nullable: false),
                    To = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptions_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pet",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    LastModifiedTime = table.Column<DateTime>(nullable: false),
                    LastModifiedUserId = table.Column<string>(nullable: true),
                    MimeType = table.Column<string>(nullable: true),
                    PetId = table.Column<long>(nullable: false),
                    PhotoContent = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Users_LastModifiedUserId",
                        column: x => x.LastModifiedUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pet",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_CreatedUserId",
                table: "AdoptionRequests",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_LastModifiedUserId",
                table: "AdoptionRequests",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_RequestedById",
                table: "AdoptionRequests",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_OwnerId",
                table: "Adoptions",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_PetId",
                table: "Adoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CreatedUserId",
                table: "Photos",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_LastModifiedUserId",
                table: "Photos",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PetId",
                table: "Photos",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_PetTypes_Name",
                schema: "Master",
                table: "PetTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CreatedUserId",
                schema: "Pet",
                table: "Pets",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_LastModifiedUserId",
                schema: "Pet",
                table: "Pets",
                column: "LastModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                schema: "Pet",
                table: "Pets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetTypeId",
                schema: "Pet",
                table: "Pets",
                column: "PetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionRequests");

            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Pets",
                schema: "Pet");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "PetTypes",
                schema: "Master");
        }
    }
}
