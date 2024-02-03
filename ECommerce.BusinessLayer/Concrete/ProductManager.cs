using ECommerce.BusinessLayer.Abstract;
using ECommerce.Common;
using ECommerce.Common.Enums;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.DtoLayer.DTOS;
using ECommerce.EntityLayer.Concrete;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
       

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IEnumerable<ProductFilterDto>> GetProductFilter(Gender? gender,int? categoryId, int? colorId, string? size, decimal? startPrice, decimal? endPrice, string name)
        {
            var productPredicate = PredicateBuilder.New<Product>(x=>x.IsActive);
            Expression<Func<Product, object>>[] includeProperties = { p => p.Categories , s=>s.Size , c=>c.Color};

			if (gender != null)
                productPredicate.And(s => s.Genders.Equals(gender));

            if (categoryId != null)
                productPredicate.And(s => s.CategoryId.Equals(categoryId));

            if (colorId != null)
                productPredicate.And(s => s.ColorId.Equals(colorId));

            //if (size != null)
            //    productPredicate.And(s => s.Size.Equals(size));

            if (startPrice.HasValue)
                productPredicate.And(s => s.Price >= startPrice.Value); 

            if (endPrice.HasValue)
                productPredicate.And(s => s.Price <= endPrice.Value);

            if (!string.IsNullOrEmpty(name))
                productPredicate.And(s => s.ProductName.Contains(name));

            var maleRead = await _productDal.FilterAsync(productPredicate, includeProperties);

            var maleAndRedProductViewModels = maleRead.Select(p => new ProductFilterDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                CategoryId = p.CategoryId,
                Description = p.Description,
                CategoryName = p.Categories.CategoryName,
                Genders=p.Genders,
                Color = p.Color,
                Size = p.Size
                
              
              
            });

            return maleAndRedProductViewModels;
        }


		public void TCreate(Product entity)
        {
            _productDal.Create(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public async Task<IEnumerable<Product>> TFilterAsync(Expression<Func<Product, bool>> predicate)
        {

            return await _productDal.FilterAsync(predicate);
        }


        public async Task<IEnumerable<Product>> TFindByConditionAsync(Expression<Func<Product, bool>> expression, params Expression<Func<Product, object>>[] includeProperties)
        {



            return await _productDal.FindByConditionAsync(expression);
        }

		public List<Product> TGetAll()
		{
			return _productDal.GetAll();
		}

	

        public async Task<Product> TGetByIdAsync(object id)
        {
            return await _productDal.GetByIdAsync(id);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
