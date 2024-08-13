using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
