using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _CardPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
