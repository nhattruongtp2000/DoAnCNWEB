using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class upid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_idBrand",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productColors_idColor",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_idType",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productColors",
                table: "productColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productBrands",
                table: "productBrands");

            migrationBuilder.RenameTable(
                name: "productTypes",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "productColors",
                newName: "ProductColors");

            migrationBuilder.RenameTable(
                name: "productBrands",
                newName: "ProductBrands");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "ProductTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "ProductColors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "ProductBrands",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "idType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors",
                column: "idColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands",
                column: "idBrand");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b9a64a86-0881-4594-b069-ed4890e15252");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3424ddd9-a4ca-4647-a2f4-0d96cc4e804f", "AQAAAAEAACcQAAAAEEMii0adIHqembrA6wd7SGhfrmWO62dPj+0iAPZ8vhhGE5sL7Fbia5UzSg1kxxQsVA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_LanguageId",
                table: "ProductTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_LanguageId",
                table: "ProductColors",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrands_LanguageId",
                table: "ProductBrands",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBrands_Languages_LanguageId",
                table: "ProductBrands",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_Languages_LanguageId",
                table: "ProductColors",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductBrands_idBrand",
                table: "products",
                column: "idBrand",
                principalTable: "ProductBrands",
                principalColumn: "idBrand",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductColors_idColor",
                table: "products",
                column: "idColor",
                principalTable: "ProductColors",
                principalColumn: "idColor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductTypes_idType",
                table: "products",
                column: "idType",
                principalTable: "ProductTypes",
                principalColumn: "idType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Languages_LanguageId",
                table: "ProductTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBrands_Languages_LanguageId",
                table: "ProductBrands");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_Languages_LanguageId",
                table: "ProductColors");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductBrands_idBrand",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductColors_idColor",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductTypes_idType",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Languages_LanguageId",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_LanguageId",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors");

            migrationBuilder.DropIndex(
                name: "IX_ProductColors_LanguageId",
                table: "ProductColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands");

            migrationBuilder.DropIndex(
                name: "IX_ProductBrands_LanguageId",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProductColors");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProductBrands");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "productTypes");

            migrationBuilder.RenameTable(
                name: "ProductColors",
                newName: "productColors");

            migrationBuilder.RenameTable(
                name: "ProductBrands",
                newName: "productBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes",
                column: "idType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productColors",
                table: "productColors",
                column: "idColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productBrands",
                table: "productBrands",
                column: "idBrand");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "6784f6b8-7695-4bdd-88fd-4399c512eec1");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d314bdb-f5f8-4fff-9918-80db8181df8a", "AQAAAAEAACcQAAAAEKtoh7g8l+2Sm1x8WV0G2U2w9Rl+lOSmgKQKiPA/4GFdWt8FdmUZGTvQhmU8ldkgRw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_idBrand",
                table: "products",
                column: "idBrand",
                principalTable: "productBrands",
                principalColumn: "idBrand",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productColors_idColor",
                table: "products",
                column: "idColor",
                principalTable: "productColors",
                principalColumn: "idColor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_idType",
                table: "products",
                column: "idType",
                principalTable: "productTypes",
                principalColumn: "idType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
