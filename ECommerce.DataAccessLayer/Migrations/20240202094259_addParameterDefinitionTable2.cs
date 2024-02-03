using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccessLayer.Migrations
{
    public partial class addParameterDefinitionTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sizes",
                table: "Products",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "Colors",
                table: "Products",
                newName: "ColorId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ParameterDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ParameterDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDefinitions_ProductId",
                table: "ParameterDefinitions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDefinitions_ProductId1",
                table: "ParameterDefinitions",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDefinitions_Products_ProductId",
                table: "ParameterDefinitions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDefinitions_Products_ProductId1",
                table: "ParameterDefinitions",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDefinitions_Products_ProductId",
                table: "ParameterDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDefinitions_Products_ProductId1",
                table: "ParameterDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDefinitions_ProductId",
                table: "ParameterDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDefinitions_ProductId1",
                table: "ParameterDefinitions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ParameterDefinitions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ParameterDefinitions");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Products",
                newName: "Sizes");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Products",
                newName: "Colors");
        }
    }
}
