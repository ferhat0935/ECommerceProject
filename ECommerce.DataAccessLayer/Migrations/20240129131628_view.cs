using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccessLayer.Migrations
{
    public partial class view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Create View View_ProductsDetail as 
select P.Id,ProductName,CategoryName,P.Description,GenderName,Price,UploadedQuantity,CurrentQuantity,GenderId,CategoryId,P.IsActive from Products P INNER JOIN Categories C ON P.CategoryId=C.Id INNER JOIN Genders G ON P.GenderId=G.Id
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
