using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.DataAccessLayer.Repository;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfProductDal:GenericRepository<Product>,IProductDal
    {
        public EfProductDal(ECommerceDbContext context):base(context)
        {

        }

        public async Task<int> GetProductCountByCategoryIdAsync(int categoryId)
        {
            var context = new ECommerceDbContext();
            int productCount = await context.Products
            .Where(p => p.CategoryId == categoryId)
            .CountAsync();
            return productCount;
        }
    

    }
}
