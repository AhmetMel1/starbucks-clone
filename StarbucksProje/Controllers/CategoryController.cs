﻿using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult ListCategory()
        {
            var categories=cm.categoryList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            var categories = cm.categoryList();
            return View(categories);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            cm.categoryInsert(category);
            return RedirectToAction("ListCategory");
        }
        public IActionResult DeleteCategory(int id)
        {
            var category=cm.categoryGetById(id);
            category.categoryDeleted = true;
            cm.categoryUpdate(category);
            return RedirectToAction("ListCategory");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            ViewBag.id = id;
            var categories = cm.categoryList();
            return View(categories);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            cm.categoryUpdate(category);
            return RedirectToAction("ListCategory");
        }
    }
}
