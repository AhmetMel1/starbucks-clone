using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class FavoriteController : Controller
    {
        FavoriteManager fm = new FavoriteManager(new EfFavoriteRepository());
        public IActionResult Index()
        {
            var Favorite = fm.favoriteList();
            return View(Favorite);
        }
        [HttpGet]
        public IActionResult AddFavorite()
        {
            return View();
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
            var favorite = fm.FavoriteGetById(id);
            return View(favorite);
        }
        [HttpPost]
        public IActionResult UpdateFavorite(Favorite favorite)
        {
            fm.favoriteUpdate(favorite);
            return RedirectToAction("Index");
        }
    }
}
