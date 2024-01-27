using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _Modal1Partial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
