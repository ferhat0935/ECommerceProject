using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.DataAccessLayer.Repository;
using ECommerce.EntityLayer.Concrete;
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

    }
}
