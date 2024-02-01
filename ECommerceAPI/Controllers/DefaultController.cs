using ECommerce.BusinessLayer.Abstract;
using ECommerce.Common.Enums;
using ECommerce.DataAccessLayer.Context;
using ECommerce.DtoLayer.DTOS;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
     
      private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

     
       
        //[HttpGet("Filter")]
        //public async Task<IEnumerable<ProductFilterDto>> GetAllProducts(string gender, Color? color, Size? size, decimal? startPrice, decimal? endPrice, string name)
        //{ 

        //    var filteredProducts = await _productService.GetProductFilter(gender, color, size, startPrice, endPrice, name);
  		    //return filteredProducts;
        //}

		[HttpGet("Filter")]
		public async Task<IActionResult> FilterProducts([FromQuery] string gender, [FromQuery] Color? color, [FromQuery] Size? size, [FromQuery] decimal? startPrice, [FromQuery] decimal? endPrice, [FromQuery] string name)
		{
			// Gender parametresine göre ürünleri filtreleme
		
			var filteredProducts = await _productService.GetProductFilter(ParseGender(gender), color, size, startPrice, endPrice, name);

			return Ok(filteredProducts);
		}

		private Gender? ParseGender(string gender)
		{
			// İlgili string değeri Gender enum değerine çevirme
			if (Enum.TryParse<Gender>(gender, true, out var parsedGender))
			{
				return parsedGender;
			}

			
			return null;
		}



	}

}
