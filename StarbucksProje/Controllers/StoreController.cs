using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.PagedList;
using System.Net;

namespace StarbucksProje.Controllers
{
    public class StoreController : Controller
    {
        StoreManager sm = new StoreManager(new EfStoreRepository());
        public IActionResult ListStore(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Store> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Stores.Where(store => store.StoreName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Stores.Where(store => store.StoreName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Stores.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Stores.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "store-list";
            ViewBag.contrName = "Store";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddStore()
        {
            var store=new Store();
            return View(store);
        }
        [HttpPost]
        public IActionResult AddStore(Store store)
        {
            StoreValidator validations = new StoreValidator();
            var result = validations.Validate(store);
            if (result.IsValid)
            {
                sm.StoreInsert(store);
                int page = (int)TempData["page"];
                return RedirectToAction("store-list", new { page, searchText = "" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(store);
            }

        }
        public IActionResult DeleteStore(int id )
        {
            Store store = sm.StorestoreGetById(id);
            store.StoreDeleted=true;
            sm.StoreUpdate(store);
            int page = (int)TempData["page"];
            return RedirectToAction("store-list", new { page, searchText = "" });
        }
        [HttpGet]
        public IActionResult UpdateStore(int id)
        {
            Store store = sm.StorestoreGetById(id);
            return View(store);
        }
        [HttpPost]
        public IActionResult UpdateStore(Store store)
        {

            StoreValidator validations = new StoreValidator();
            var result = validations.Validate(store);
            if (result.IsValid)
            {
                sm.StoreUpdate(store);
                int page = (int)TempData["page"];
                return RedirectToAction("store-list", new { page, searchText = "" });

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(store);
            }
        }
    }
}
