using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramminClass3.MvcLesson.Data.Migrations
{
    public partial class UnitOfMeasuresId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasuresId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitOfMeasuresId",
                table: "Products",
                column: "UnitOfMeasuresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasures_UnitOfMeasuresId",
                table: "Products",
                column: "UnitOfMeasuresId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasures_UnitOfMeasuresId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitOfMeasuresId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasuresId",
                table: "Products");
        }
    }
}
