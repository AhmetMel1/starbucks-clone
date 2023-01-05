using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
