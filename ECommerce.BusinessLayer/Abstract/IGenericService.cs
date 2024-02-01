using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
            List<T> TGetAll();
            Task<IEnumerable<T>> TFindByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties);
            Task<T> TGetByIdAsync(object id);
            void TCreate(T entity);
            void TUpdate(T entity);
            void TDelete(T entity);
            Task<IEnumerable<T>> TFilterAsync(Expression<Func<T, bool>> predicate);
   

    }
}
