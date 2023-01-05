using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
