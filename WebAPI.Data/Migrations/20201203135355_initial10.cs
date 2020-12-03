using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productSizes_idSize",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productSizes",
                table: "productSizes");

            migrationBuilder.RenameTable(
                name: "productSizes",
                newName: "ProductSizes");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "ProductSizes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes",
                column: "idSize");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_LanguageId",
                table: "ProductSizes",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductSizes_idSize",
                table: "products",
                column: "idSize",
                principalTable: "ProductSizes",
                principalColumn: "idSize",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Languages_LanguageId",
                table: "ProductSizes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductSizes_idSize",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Languages_LanguageId",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_LanguageId",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                newName: "productSizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productSizes",
                table: "productSizes",
                column: "idSize");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c85a65e1-3b0c-41e9-a151-e64e6e3a89df");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "497b252f-1d45-4646-903b-5c32f5d32317", "AQAAAAEAACcQAAAAEMtnrtZGLx6uTB2qmepeOQG3/VR8gbe02Jc/jpwgtQQJ/1chssww5ePguseorbglIA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_products_productSizes_idSize",
                table: "products",
                column: "idSize",
                principalTable: "productSizes",
                principalColumn: "idSize",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
