using ECommerce.Common.Helpers;
using ECommerce.DtoLayer.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _FooterPartial : ViewComponent
	{
	
			private readonly IHttpClientFactory _httpClientFactory;

		public _FooterPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var color = new ECommerce.Common.Enums.Color();

			var responseMessage = await client.GetAsync("http://localhost:53239/api/Default/Filter");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ProductFilterDto>>(jsonData);

				string displayName = EnumHelper.GetColorDisplayName(color);
				return View(values);
			}
			return View();
		}
	}
	
}
