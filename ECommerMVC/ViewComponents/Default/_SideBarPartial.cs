using Microsoft.AspNetCore.Mvc;

namespace ECommerMVC.ViewComponents.Default
{
	public class _SideBarPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
