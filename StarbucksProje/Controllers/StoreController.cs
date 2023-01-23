using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StarbucksProje.Controllers
{
    public class StoreController : Controller
    {
        StoreManager sm = new StoreManager(new EfStoreRepository());
        public IActionResult ListStore()
        {
            var Stories = sm.storeList();
            return View(Stories);
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
                return RedirectToAction("ListStore");
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
            return RedirectToAction("ListStore");
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
                return RedirectToAction("ListStore");

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
