
using ECommerce.DtoLayer.DTOS;
using ECommerceMVC.Models;
using ECommerceMVC.Models.ParamaterDefinitionModel;
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

			// Renk listesini alma
			var colorResponse = await client.GetAsync("http://localhost:53239/api/Default/ListColor");
			List<ParamaterDefinitionDto> colorList = new List<ParamaterDefinitionDto>();

			if (colorResponse.IsSuccessStatusCode)
			{
				var jsonData = await colorResponse.Content.ReadAsStringAsync();
				colorList = JsonConvert.DeserializeObject<List<ParamaterDefinitionDto>>(jsonData);
			}

			// Boyut listesini alma
			var sizeResponse = await client.GetAsync("http://localhost:53239/api/Default/ListSize");
			List<ParamaterDefinitionDto> sizeList = new List<ParamaterDefinitionDto>();

			if (sizeResponse.IsSuccessStatusCode)
			{
				var jsonData = await sizeResponse.Content.ReadAsStringAsync();
				sizeList = JsonConvert.DeserializeObject<List<ParamaterDefinitionDto>>(jsonData);
			}

			// ViewModel oluşturun
			var viewModel = new ParamaterDefinitionModel
			{
				ColorList = colorList,
				SizeList = sizeList
			};

			return View(viewModel);
		}

	}

}
