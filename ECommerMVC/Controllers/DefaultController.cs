using Microsoft.AspNetCore.Mvc;

namespace ECommerMVC.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
