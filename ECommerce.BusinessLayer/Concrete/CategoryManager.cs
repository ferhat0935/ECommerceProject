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
        private readonly IProductDal _productDal;

        public async Task<bool> CanDeleteCategory(int categoryId)
        {
            // Kategoriye bağlı ürün sayısını kontrol et
            int productCount = await _productDal.GetProductCountByCategoryIdAsync(categoryId);

            // Eğer kategoriye bağlı ürün varsa, silme işlemini engelle
            return productCount == 0;
        }

        public CategoryManager(ICategoryDal categoryDal, IProductDal productDal)
        {
            _categoryDal = categoryDal;
            _productDal = productDal;
        }

        public List<Category> TGetAll()
		{
			return  _categoryDal.GetAll();
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

       

        public async Task<Category> TGetByIdAsync(object id)
        {
           return await _categoryDal.GetByIdAsync(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public int TGetCategoryCount()
        {
            return _categoryDal.GetCategoryCount();
        }
    }
}
