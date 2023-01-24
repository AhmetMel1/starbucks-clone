using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;
using System.Net;

namespace StarbucksProje.Controllers
{
    public class MenuController : Controller
    {
       
        MenuManager menum = new MenuManager(new EfMenuRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Menu> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Menu.Where(menu => menu.menuName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Menu.Where(menu => menu.menuName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Menu.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Menu.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "menu-list";
            ViewBag.contrName = "Menu";
            ViewBag.searchText = searchText;
            return View(data);
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
