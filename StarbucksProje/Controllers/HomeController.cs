using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.Models.InterfaceModel;
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

		ProductSizeManager psm = new ProductSizeManager(new EfProductSizeRepository());
		CategoryManager cm=new CategoryManager(new EfCategoryRepository());
		public ActionResult Index()
		{
            ViewBag.menu = menuList;
            return View();
		}

		public ActionResult MenuPage()
		{
            ViewBag.menu = menuList;
			MenuPageModel model = new MenuPageModel();
			model.productSizeModel = psm.productSizeList();
			model.categoryModel = cm.categoryList();
            return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}