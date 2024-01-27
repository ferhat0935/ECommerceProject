using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _FooterPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
