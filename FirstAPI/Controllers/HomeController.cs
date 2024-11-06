using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
