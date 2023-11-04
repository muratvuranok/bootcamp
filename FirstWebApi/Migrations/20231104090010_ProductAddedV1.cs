using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCamp.Migrations
{
    /// <inheritdoc />
    public partial class ProductAddedV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitsInStock",
                table: "Products",
                newName: "StokAdet");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "Fiyat");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "UrunAdi");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "KategoriId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_KategoriId");

            migrationBuilder.AlterColumn<string>(
                name: "UrunAdi",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_KategoriId",
                table: "Products",
                column: "KategoriId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_KategoriId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "UrunAdi",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StokAdet",
                table: "Product",
                newName: "UnitsInStock");

            migrationBuilder.RenameColumn(
                name: "KategoriId",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "Product",
                newName: "UnitPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Products_KategoriId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
