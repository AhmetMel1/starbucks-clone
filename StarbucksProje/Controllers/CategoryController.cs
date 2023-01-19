using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            int pageSize = 2;
            Context c = new Context();
            Pager pager;

            var itemCounts = c.Categories.ToList().Count;
            pager = new Pager(pageSize, itemCounts, page);
            var data = c.Categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "Category";
            return View(data);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            CategoryListModel model = new CategoryListModel();
            model.categoryListModel = cm.categoryList();
            model.categoryModel = new Category();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            var result = validations.Validate(category);
            if (result.IsValid)
            {
                cm.categoryInsert(category);
                return RedirectToAction("Index");
            }
            else
            {
                CategoryListModel model = new CategoryListModel();
                model.categoryListModel = cm.categoryList();
                model.categoryModel = category;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        public IActionResult DeleteCategory(int id)
        {
            var category=cm.categoryGetById(id);
            category.categoryDeleted = true;
            cm.categoryUpdate(category);
            return RedirectToAction("Index");
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
            CategoryValidator validations = new CategoryValidator();
            var result = validations.Validate(category);
            if (result.IsValid)
            {
                cm.categoryUpdate(category);
                return RedirectToAction("Index");
            }
            else
            {
                CategoryListModel model = new CategoryListModel();
                model.categoryListModel = cm.categoryList();
                model.categoryModel = category;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
 
        }
    }
}
