using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogService.DAL.EF.Migrations
{
    public partial class AddProductTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CatalogID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PTypeID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatalogID",
                table: "Products",
                column: "CatalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PTypeID",
                table: "Products",
                column: "PTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CatalogBrand_CatalogID",
                table: "Products",
                column: "CatalogID",
                principalTable: "CatalogBrand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_PTypeID",
                table: "Products",
                column: "PTypeID",
                principalTable: "ProductType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CatalogBrand_CatalogID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_PTypeID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatalogID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PTypeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatalogID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PTypeID",
                table: "Products");
        }
    }
}
