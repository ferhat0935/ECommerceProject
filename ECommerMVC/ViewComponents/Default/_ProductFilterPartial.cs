using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _ProductFilterPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
