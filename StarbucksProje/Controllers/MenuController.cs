using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class MenuController : Controller
    {
        MenuManager menum = new MenuManager(new EfMenuRepository());
        public IActionResult Index()
        {
            var Menu = menum.menuList();
            return View(Menu);
        }
        [HttpGet]
        public IActionResult AddMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMenu(Menu menu)
        {
            menum.menuInsert(menu);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMenu(int id)
        {
            var menu = menum.MenuGetById(id);
            menu.menuDeleted = true;
            menum.menuUpdate(menu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateMenu(int id)
        {
            var menu = menum.MenuGetById(id);
            return View(menu);
        }
        [HttpPost]
        public IActionResult UpdateMenu(Menu menu)
        {
            menum.menuUpdate(menu);
            return RedirectToAction("Index");
        }

    }
}
