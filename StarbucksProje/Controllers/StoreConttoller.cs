using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class StoreConttoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
