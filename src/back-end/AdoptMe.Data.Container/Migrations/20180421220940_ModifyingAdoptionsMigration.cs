using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdoptMe.Data.Container.Migrations
{
    public partial class ModifyingAdoptionsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adoptions",
                table: "Adoptions");

            migrationBuilder.DropIndex(
                name: "IX_Adoptions_PetId",
                table: "Adoptions");

            migrationBuilder.RenameTable(
                name: "Adoptions",
                newSchema: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adoptions",
                schema: "Pets",
                table: "Adoptions",
                columns: new[] { "PetId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adoptions",
                schema: "Pets",
                table: "Adoptions");

            migrationBuilder.RenameTable(
                name: "Adoptions",
                schema: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adoptions",
                table: "Adoptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_PetId",
                table: "Adoptions",
                column: "PetId");
        }
    }
}
