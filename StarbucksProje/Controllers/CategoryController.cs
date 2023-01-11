using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

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
            CategoryListModel model = new CategoryListModel();
            model.categoryListModel = cm.categoryList();
            return View(model);
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
            CategoryListModel model = new CategoryListModel();
            model.categoryListModel = cm.categoryList();
            model.categoryModel = cm.categoryGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            cm.categoryUpdate(category);
            return RedirectToAction("ListCategory");
        }
    }
}
