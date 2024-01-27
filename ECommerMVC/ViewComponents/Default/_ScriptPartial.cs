using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents.Default
{
	public class _ScriptPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}


}
