using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

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
            MenuParentMenuIdModel model = new MenuParentMenuIdModel();
            model.menuParentModel = menum.menuList();
            return View(model);
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
            MenuParentMenuIdModel model = new MenuParentMenuIdModel();
            model.menuParentModel = menum.menuList();
            model.menuModel = menum.MenuGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateMenu(Menu menu)
        {
            menum.menuUpdate(menu);
            return RedirectToAction("Index");
        }

    }
}
