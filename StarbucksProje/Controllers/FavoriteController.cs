using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class FavoriteController : Controller
    {
        FavoriteManager fm = new FavoriteManager(new EfFavoriteRepository());
        UserManager um= new UserManager(new EfUserRepository());
        ProductManager pm= new ProductManager(new EfProductRepository());
        public IActionResult Index()
        {
            var Favorite = fm.favoriteList();
            return View(Favorite);
        }
        [HttpGet]
        public IActionResult AddFavorite()
        {
            FavoriteUserProductModel model = new FavoriteUserProductModel();
            model.productModel=pm.productList();
            model.userModel=um.userList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddFavorite(Favorite favorite)
        {
            fm.favoriteInsert(favorite);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFavorite(int id)
        {
            var favorite = fm.FavoriteGetById(id);
            favorite.favoriteDeleted = true;
            fm.favoriteUpdate(favorite);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFavorite(int id)
        {
            FavoriteUserProductModel model = new FavoriteUserProductModel();
            model.productModel = pm.productList();
            model.userModel = um.userList();
            model.favoriteModel = fm.FavoriteGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateFavorite(Favorite favorite)
        {
            fm.favoriteUpdate(favorite);
            return RedirectToAction("Index");
        }
    }
}
