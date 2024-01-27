using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _BannerPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
