﻿using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        [HttpPost]
        public IActionResult AddStore(Store store)
        {
           sm.StoreInsert(store);
            return RedirectToAction("Index"); 
        }
        public IActionResult DeleteStore(int id )
        {
            Store store = sm.StorestoreGetById(id);
            store.StoreDeleted=true;
            sm.StoreUpdate(store);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStore(int id)
        {
            Store store = sm.StorestoreGetById(id);
            return View(store);
        }
        [HttpPost]
        public IActionResult StoreUpdate(Store store)
        {

            sm.StoreUpdate(store);
            return RedirectToAction("Index");
        }
    }
}
