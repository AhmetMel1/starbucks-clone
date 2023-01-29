using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
