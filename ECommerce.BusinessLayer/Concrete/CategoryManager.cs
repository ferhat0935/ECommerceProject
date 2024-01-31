using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TCreate(Category entity)
        {
           _categoryDal.Create(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public async Task<IEnumerable<Category>> TFilterAsync(Expression<Func<Category, bool>> predicate)
        {
           return await _categoryDal.FilterAsync(predicate);    
        }

       

        public async Task<IEnumerable<Category>> TFindByConditionAsync(Expression<Func<Category, bool>> expression, params Expression<Func<Category, object>>[] includeProperties)
        {
            return await _categoryDal.FindByConditionAsync(expression);
        }

        public async Task<IEnumerable<Category>> TGetAllAsync()
        {
            return await _categoryDal.GetAllAsync();
        }

        public async Task<Category> TGetByIdAsync(object id)
        {
           return await _categoryDal.GetByIdAsync(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
