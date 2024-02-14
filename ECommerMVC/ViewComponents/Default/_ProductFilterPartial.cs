

using ECommerce.DtoLayer.DTOS.ProductDtos;
using ECommerceMVC.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceMVC.ViewComponents.Default
{
    public class _ProductFilterPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ProductFilterPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			
			var responseProductFilter = await client.GetAsync("http://localhost:53239/api/Default/Filter");
			List<ProductFilterDto> productFilterDtos = new List<ProductFilterDto>();
			if (responseProductFilter.IsSuccessStatusCode)
			{
				var productFilterData = await responseProductFilter.Content.ReadAsStringAsync();
				productFilterDtos = JsonConvert.DeserializeObject<List<ProductFilterDto>>(productFilterData);
			}

			
			var responseCategory = await client.GetAsync("http://localhost:53239/api/Category");
			List<ResultCategoryDto> categoryDtos = new List<ResultCategoryDto>();
			if (responseCategory.IsSuccessStatusCode)
			{
				var categoryData = await responseCategory.Content.ReadAsStringAsync();
				categoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
			}

			
			var viewModel = new Tuple<List<ProductFilterDto>, List<ResultCategoryDto>>(productFilterDtos, categoryDtos);

			return View(viewModel);
		}

	}
}
