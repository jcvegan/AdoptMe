using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdoptMe.Data.Container.Migrations
{
    public partial class ModifyingAdoptionRequestsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdoptionRequests",
                table: "AdoptionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests");

            migrationBuilder.RenameTable(
                name: "AdoptionRequests",
                newSchema: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdoptionRequests",
                schema: "Pets",
                table: "AdoptionRequests",
                columns: new[] { "PetId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdoptionRequests",
                schema: "Pets",
                table: "AdoptionRequests");

            migrationBuilder.RenameTable(
                name: "AdoptionRequests",
                schema: "Pets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdoptionRequests",
                table: "AdoptionRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests",
                column: "PetId");
        }
    }
}
