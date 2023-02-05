using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using System.Diagnostics;

namespace StarbucksProje.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

        private List<Menu> menuList;
        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;

            MenuManager mm = new MenuManager(new EfMenuRepository());
			menuList = mm.menuList();
        }
		ProductManager pm = new ProductManager(new EfProductRepository());
		public ActionResult Index()
		{
            ViewBag.menu = menuList;
            return View();
		}

		public ActionResult ProductPage()
		{
            ViewBag.menu = menuList;
			var products = pm.productList();
            return View(products);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}