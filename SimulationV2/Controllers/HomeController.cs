using Microsoft.AspNetCore.Mvc;

namespace SimulationV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
