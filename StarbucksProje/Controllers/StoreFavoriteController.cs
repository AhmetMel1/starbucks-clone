using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using StarbucksProje.Controllers;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class StoreFavoriteController : Controller
    {
        StoreFavoriteManager sfm = new StoreFavoriteManager(new EfStoreFavoriteRepository());
        StoreManager sm=new StoreManager(new EfStoreRepository());
        UserManager um=new UserManager(new EfUserRepository());
        public IActionResult ListStoreFavorite()
        {
            var storeFavorite = sfm.StoreFavoriteList();
            return View(storeFavorite);
        }
        [HttpGet]
        public IActionResult AddStoreFavorite() 
        {
            StoreFavoriteModel model = new StoreFavoriteModel();
            model.storeModel = sm.storeList();
            model.userModel=um.userList();
            return View(model); 
        }
        [HttpPost]
        public IActionResult AddStoreFavorite(StoreFavorite storeFavorite)
        {
            sfm.StoreFavoriteInsert(storeFavorite);
            return RedirectToAction("ListStoreFavorite");
        }
        public IActionResult DeleteStoreFavorite(int id)
        {
            var storeFavorite=sfm.StoreFavoriteGetById(id);
            storeFavorite.StoreFavoriteDeleted=true;
            sfm.StoreFavoriteUpdate(storeFavorite);
            return RedirectToAction("ListStoreFavorite");

        }
        [HttpGet]
        public IActionResult UpdateStoreFavorite(int id)
        {
            StoreFavoriteModel model =new StoreFavoriteModel();
            model.storeModel = sm.storeList();
            model.userModel=um.userList();
            model.storeFavoriteModel = sfm.StoreFavoriteGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateStoreFavorite(StoreFavorite storeFavorite)
        {
            sfm.StoreFavoriteUpdate(storeFavorite);
            return RedirectToAction("ListStoreFavorite");
        }
    }
}
