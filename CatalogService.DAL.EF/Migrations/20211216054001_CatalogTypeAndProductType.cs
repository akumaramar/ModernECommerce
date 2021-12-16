using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogService.DAL.EF.Migrations
{
    public partial class CatalogTypeAndProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_PTypeID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PTypeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PTypeID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductType",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableStocks",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxStockThreshold",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestockThreshold",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarkDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "AvailableStocks",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxStockThreshold",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RestockThreshold",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<Guid>(
                name: "PTypeID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PTypeID",
                table: "Products",
                column: "PTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_PTypeID",
                table: "Products",
                column: "PTypeID",
                principalTable: "ProductType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
