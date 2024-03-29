﻿using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class FavoriteController : Controller
    {
        FavoriteManager fm = new FavoriteManager(new EfFavoriteRepository());
        UserManager um= new UserManager(new EfUserRepository());
        ProductManager pm= new ProductManager(new EfProductRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Favorite> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Favorites.Where(favorite => favorite.user.name.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Favorites.Where(favorite => favorite.user.name.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Favorites.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Favorites.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "favorites-list";
            ViewBag.contrName = "Favorite";
            ViewBag.searchText = searchText;
            return View(data);
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
                int page = (int)TempData["page"];
                return RedirectToAction("favorites-list", new { page, searchText = "" });
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
            int page = (int)TempData["page"];
            return RedirectToAction("favorites-list", new { page, searchText = "" });
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
                int page = (int)TempData["page"];
                return RedirectToAction("favorites-list", new { page, searchText = "" });
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
