using ECommerce.BusinessLayer.Abstract;
using ECommerce.Common;

using ECommerce.Common.Enums;
using ECommerce.Common.Helpers;
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
      private readonly IParametersDefinitionService _parametersDefinitionService;

		public DefaultController(IProductService productService, IParametersDefinitionService parametersDefinitionService)
		{
			_productService = productService;
			_parametersDefinitionService = parametersDefinitionService;
		}



		[HttpGet("Filter")]
		public async Task<IActionResult> FilterProducts([FromQuery] string gender, [FromQuery] int? categoryId, [FromQuery] int? colorId, [FromQuery] int? sizeId)
		{
			// Gender parametresine göre ürünleri filtreleme
			
			var filteredProducts = await _productService.GetProductFilter(ParseGender(gender),categoryId,colorId, sizeId, null,null,null);

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
		[HttpGet("ListColor")]
		public async Task<List<ParameterDefinition>> GetColors()
		{
			var listColor= await _parametersDefinitionService.GetParameters(Constant.Color);
			return listColor;
			
		}
		[HttpGet("ListSize")]
		public async Task<List<ParameterDefinition>> GetSize()
		{
			var listSize = await _parametersDefinitionService.GetParameters(Constant.Size);
			return listSize;

		}

	}

	//gerekli apiler
	//1-GetColors servici
	//2-sizeservice yukardaki gibi
	//int?sizeID
	//İNT*colorId
}
