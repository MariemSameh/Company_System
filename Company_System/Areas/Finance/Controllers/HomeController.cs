using Microsoft.AspNetCore.Mvc;

namespace Company_System.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
