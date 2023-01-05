using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
