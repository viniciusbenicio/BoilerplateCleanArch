using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Categories_CategoryId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.Sql("INSERT INTO Products (Name,Description,Price,Stock,Image,CategoryId) VALUES ('Caderno espiral','Caderno espiral 100 folhas',7.45,50,'caderno1.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Products (Name,Description,Price,Stock,Image,CategoryId) VALUES ('Estojo escolar','Estojo escolar cinza',6.65,70,'estojo1.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Products (Name,Description,Price,Stock,Image,CategoryId) VALUES ('Borracha escolar','Borracha branca pequena',3.25,80,'borracha1.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Products (Name,Description,Price,Stock,Image,CategoryId) VALUES ('Calculadora simples','Calculadora simples',15.39,20,'calculadora1.jpg',2)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "products",
                newName: "IX_products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
