using ECommerce.Common.Helpers;
using ECommerce.DtoLayer.DTOS.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceMVC.ViewComponents.Default
{
    public class _Modal1Partial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _Modal1Partial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();


			var responseMessage = await client.GetAsync("http://localhost:53239/api/Default/FilterProducts");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ProductFilterDto>>(jsonData);

				return View(values);
			}
			return View();
		}
	}
	

}
