using ECommerceMVC.DTO.ProducrDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerMVC.Controllers
{
	public class DefaultController : Controller
	{
		

		public async Task<IActionResult> Index()
		{

			return View();
		}
	}
}
