using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
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
            model.favoriteModel = new Favorite();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddFavorite(Favorite favorite)
        {
            FavoriteValidator validations = new FavoriteValidator();
            var result = validations.Validate(favorite);
            if (result.IsValid)
            {
                fm.favoriteInsert(favorite);
                return RedirectToAction("Index");
            }
            else
            {
                FavoriteUserProductModel model = new FavoriteUserProductModel();
                model.productModel = pm.productList();
                model.userModel = um.userList();
                model.favoriteModel = favorite;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
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
            FavoriteValidator validations = new FavoriteValidator();
            var result = validations.Validate(favorite);
            if (result.IsValid)
            {
                fm.favoriteUpdate(favorite);
                return RedirectToAction("Index");
            }
            else
            {
                FavoriteUserProductModel model = new FavoriteUserProductModel();
                model.productModel = pm.productList();
                model.userModel = um.userList();
                model.favoriteModel = favorite;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
