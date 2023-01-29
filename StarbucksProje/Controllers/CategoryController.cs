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
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoryController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1,string searchText="")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Category> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Categories.Where(category => category.categoryName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Categories.Where(category => category.categoryName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Categories.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "category-list";
            ViewBag.contrName = "Category";
            ViewBag.searchText = searchText;
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
                category.categoryLogoUrl = FileUpload(category);
                cm.categoryInsert(category);
                int page = (int)TempData["page"];
                return RedirectToAction("category-list", new { page, searchText = "" });
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
            int page = (int)TempData["page"];
            return RedirectToAction("category-list", new { page, searchText = "" });
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
                category.categoryLogoUrl = FileUpload(category);
                cm.categoryUpdate(category);
                int page = (int)TempData["page"];
                return RedirectToAction("category-list", new { page, searchText = "" });
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
        private string FileUpload(Category category)
        {
            string uniquefileName = "";
            if (category.imgFile != null)
            {
                uniquefileName = Guid.NewGuid().ToString() + "_" + category.imgFile.FileName;
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "category_images");
                string filePath = Path.Combine(uploadfolder, uniquefileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    category.imgFile.CopyTo(stream);
                }
            }
            return uniquefileName;
        }
    }
}
