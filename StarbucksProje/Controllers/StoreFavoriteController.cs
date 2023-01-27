using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using StarbucksProje.Controllers;
using StarbucksProje.Models;
using DataAccessLayer.ConCreate;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class StoreFavoriteController : Controller
    {
        StoreFavoriteManager sfm = new StoreFavoriteManager(new EfStoreFavoriteRepository());
        StoreManager sm=new StoreManager(new EfStoreRepository());
        UserManager um=new UserManager(new EfUserRepository());
        public IActionResult ListStoreFavorite(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<StoreFavorite> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.StoreFavorites.Where(storeFavorite => storeFavorite.Store.StoreName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreFavorites.Where(storeFavorite => storeFavorite.Store.StoreName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.StoreFavorites.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreFavorites.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "store-opening-hour-list";
            ViewBag.contrName = "StoreOpeningHour";
            ViewBag.searchText = searchText;
            return View(data);
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
