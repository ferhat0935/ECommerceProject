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
    public class EfParameterDefinition : GenericRepository<ParameterDefinition>,IParameterDefinitonDal
    {
        public EfParameterDefinition(ECommerceDbContext context):base(context)
        {

        }



    }
}
