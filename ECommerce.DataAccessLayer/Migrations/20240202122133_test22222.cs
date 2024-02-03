using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccessLayer.Migrations
{
    public partial class test22222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDefinitions_Products_ColorId",
                table: "ParameterDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDefinitions_Products_SizeId",
                table: "ParameterDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDefinitions_ColorId",
                table: "ParameterDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDefinitions_SizeId",
                table: "ParameterDefinitions");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ParameterDefinitions");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ParameterDefinitions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ParameterDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ParameterDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDefinitions_ColorId",
                table: "ParameterDefinitions",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDefinitions_SizeId",
                table: "ParameterDefinitions",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDefinitions_Products_ColorId",
                table: "ParameterDefinitions",
                column: "ColorId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDefinitions_Products_SizeId",
                table: "ParameterDefinitions",
                column: "SizeId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
