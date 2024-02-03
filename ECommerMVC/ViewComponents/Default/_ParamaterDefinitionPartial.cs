using ECommerce.Common.Helpers;
using ECommerce.DtoLayer.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _ParamaterDefinitionPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _ParamaterDefinitionPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var color = new ECommerce.Common.Enums.Color();

			var responseMessage = await client.GetAsync("http://localhost:53239/api/Default/ListColor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ParamaterDefinitionDto>>(jsonData);

				return View(values);
			}
			return View();
		}
	}

}
