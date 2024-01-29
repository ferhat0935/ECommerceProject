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

        private readonly IProductViewService _productviewservice;

        private readonly ECommerceDbContext _context;

        public DefaultController(IProductService productservice, ICategoryService categoryservice, ECommerceDbContext context, IProductViewService productviewservice)
        {
            _productservice = productservice;
            _categoryservice = categoryservice;
            _context = context;
            _productviewservice = productviewservice;
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
            
            var values = _categoryservice.TGetList();
            return Ok(values);
        }

        [HttpGet("View")]
        public IActionResult MyView()
        {
            var myViewData = _productviewservice.TGetList();
            return Ok(myViewData);
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productservice.TInsert(product);
            return Ok();
        }

        [HttpPut("updateproduct")]

        public IActionResult UpdateProduct(Product product)
        {
            _productservice.TUpdate(product);
            return Ok();
        }


      
    
    }
}
