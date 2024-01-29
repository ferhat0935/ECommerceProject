using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class ProductViewManager : IProductViewService
    {
        private readonly IProductViewDal _productviewDal;

        public ProductViewManager(IProductViewDal productviewDal)
        {
            _productviewDal = productviewDal;
        }

        public void TDelete(ProductView t)
        {
            _productviewDal.Delete(t);
        }

        public ProductView TGetById(int id)
        {
          return _productviewDal.GetById(id);
        }

        public List<ProductView> TGetList()
        {
            return _productviewDal.GetList();
        }

        public void TInsert(ProductView t)
        {
            _productviewDal.Insert(t);
        }

        public void TUpdate(ProductView t)
        {
            _productviewDal.Update(t);
        }
    }
}
