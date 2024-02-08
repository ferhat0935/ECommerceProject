using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
