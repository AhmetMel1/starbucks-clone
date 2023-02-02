using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using System.Diagnostics;

namespace StarbucksProje.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		MenuManager mm = new MenuManager(new EfMenuRepository());

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var menus = mm.menuList();
            return View(menus);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}