using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdoptMe.Data.Container.Migrations
{
    public partial class ModifyPhotoEntitiyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PetId",
                table: "Photos");

            migrationBuilder.EnsureSchema(
                name: "Pets");

            migrationBuilder.RenameTable(
                name: "Photos",
                newSchema: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                schema: "Pets",
                table: "Photos",
                columns: new[] { "PetId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                schema: "Pets",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Photos",
                schema: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PetId",
                table: "Photos",
                column: "PetId");
        }
    }
}
