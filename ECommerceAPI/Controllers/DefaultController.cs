using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IProductService _productservice;

        private readonly ICategoryService _categoryservice;

        private readonly ECommerceDbContext _context;

        public DefaultController(IProductService productservice, ICategoryService categoryservice, ECommerceDbContext context)
        {
            _productservice = productservice;
            _categoryservice = categoryservice;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var values = _productservice.TGetList();
            return Ok(values);
        }

        [HttpGet("category")]

        public IActionResult GetCategory()
        {
            _context.Set<ProductCategory>().ToList();
            var values = _categoryservice.TGetList();
            return Ok(values);
        }

        [HttpGet("View")]
        public IActionResult MyView()
        {
            var myViewData = _context.ProductCategories.ToList();
            return Ok(myViewData);
        }
      
    
    }
}
