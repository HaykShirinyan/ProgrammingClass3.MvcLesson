﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramminClass3.MvcLesson.Data.Migrations
{
    public partial class UnitOfMeasureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasures_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasures_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Products");
        }
    }
}
