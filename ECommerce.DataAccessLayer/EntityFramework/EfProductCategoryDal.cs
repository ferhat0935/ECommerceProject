using ECommerce.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfProductCategoryDal
    {
       private readonly ECommerceDbContext _context;

        public EfProductCategoryDal(ECommerceDbContext context)
        {
            _context = context;
        }

     
    }
}
