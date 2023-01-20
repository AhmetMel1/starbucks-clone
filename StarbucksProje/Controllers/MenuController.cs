using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using System.Net;

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
            model.menuModel = new Menu();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddMenu(Menu menu)
        {
            MenuValidator validations = new MenuValidator();
            var result = validations.Validate(menu);
            if (result.IsValid)
            {
                menum.menuInsert(menu);
                return RedirectToAction("Index");
            }
            else
            {
                MenuParentMenuIdModel model = new MenuParentMenuIdModel();
                model.menuParentModel = menum.menuList();
                model.menuModel = menu;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
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
            MenuValidator validations = new MenuValidator();
            var result = validations.Validate(menu);
            if (result.IsValid)
            {
                menum.menuUpdate(menu);
                return RedirectToAction("Index");
            }
            else
            {
                MenuParentMenuIdModel model = new MenuParentMenuIdModel();
                model.menuParentModel = menum.menuList();
                model.menuModel = menu;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }

    }
}
