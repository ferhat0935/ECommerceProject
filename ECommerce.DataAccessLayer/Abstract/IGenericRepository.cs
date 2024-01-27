using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Insert(T t);

        void Delete(T t);

        void Update(T t);

        List<T> GetList();

        T GetById(int id);
    }
}
