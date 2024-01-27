using Microsoft.AspNetCore.Mvc;

namespace ECommerMVC.ViewComponents.Default
{
	public class _HeadPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
