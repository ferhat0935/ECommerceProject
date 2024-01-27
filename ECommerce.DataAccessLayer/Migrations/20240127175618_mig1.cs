using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Create view pr2_view as Select c.Id,c.CategoryName,p.ProductName,p.CreatedDate,P.Price  from Categories c
left join Products p
on c.Id=p.CategoryId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
