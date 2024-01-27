using Microsoft.AspNetCore.Mvc;

namespace ECommerMVC.ViewComponents.Default
{
	public class _HeaderPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
