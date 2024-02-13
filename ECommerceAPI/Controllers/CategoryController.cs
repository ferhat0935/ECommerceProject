using ECommerce.BusinessLayer.Abstract;

using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
		public IActionResult GetCategory()
		{
			var values=_categoryService.TGetAll();
          
			return Ok(values);
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _categoryService.TGetByIdAsync(id);

            return Ok(values);
        }


        [HttpGet("GetCategoryCount")]
        public IActionResult CategoryCount()
        {
            var values = _categoryService.TGetCategoryCount();
            return Ok(values);
        }
		
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
            var values = await _categoryService.TGetByIdAsync(id);
            bool canDelete = await _categoryService.CanDeleteCategory(id);

            try
            {
                if (!canDelete)
                {
                    
                    return RedirectToAction("GetCategories", "AdminCategory");
                }

                _categoryService.TDelete(values);
                return Ok();
            }
            catch (Exception ex)
            {

                return RedirectToAction("GetCategories", "AdminCategory");
            }

        }


        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok();
        }


		[HttpPost("AddCategory")]
		public IActionResult AddCategory(Category category)
		{
			_categoryService.TCreate(category);
			return Ok();
		}
	}
}
