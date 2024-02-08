using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
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

		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			//Category entity = new Category()
			//{
			//	CategoryName = "mert",
			//	Description = category.Description,
				
			//};
			_categoryService.TCreate(category);
			return Ok();
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
                // Hata durumunu loglama veya başka bir işlem yapabilirsiniz.
               
                return RedirectToAction("GetCategories", "AdminCategory");
            }

        }
	}
}
