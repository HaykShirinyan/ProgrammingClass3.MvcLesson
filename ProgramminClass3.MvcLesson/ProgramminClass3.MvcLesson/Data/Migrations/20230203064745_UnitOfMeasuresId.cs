using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramminClass3.MvcLesson.Data.Migrations
{
    public partial class UnitOfMeasuresId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductCategory_Categories_CategoryId",
            //    table: "ProductCategory");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductCategory_Products_ProductId",
            //    table: "ProductCategory");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ProductCategory",
            //    table: "ProductCategory");

            //migrationBuilder.RenameTable(
            //    name: "ProductCategory",
            //    newName: "ProductCategories");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductCategory_CategoryId",
            //    table: "ProductCategories",
            //    newName: "IX_ProductCategories_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasuresId",
                table: "Products",
                type: "int",
                nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ProductCategories",
            //    table: "ProductCategories",
            //    columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitOfMeasuresId",
                table: "Products",
                column: "UnitOfMeasuresId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductCategories_Categories_CategoryId",
            //    table: "ProductCategories",
            //    column: "CategoryId",
            //    principalTable: "Categories",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductCategories_Products_ProductId",
            //    table: "ProductCategories",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasures_UnitOfMeasuresId",
                table: "Products",
                column: "UnitOfMeasuresId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasures_UnitOfMeasuresId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitOfMeasuresId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasuresId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
