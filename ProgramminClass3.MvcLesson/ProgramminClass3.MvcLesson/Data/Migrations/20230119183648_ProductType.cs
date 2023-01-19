using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramminClass3.MvcLesson.Data.Migrations
{
    public partial class ProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_UnitOfMeasures_UnitOfMeasureId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UnitOfMeasureId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ProductTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UnitOfMeasureId",
                table: "Categories",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_UnitOfMeasures_UnitOfMeasureId",
                table: "Categories",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }
    }
}
