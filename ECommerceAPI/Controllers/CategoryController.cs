using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
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
	}
}
