using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _SlidePartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
