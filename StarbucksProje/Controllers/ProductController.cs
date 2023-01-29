using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Product> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Products.Where(product => product.productName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Products.Where(product => product.productName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Products.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "products-list";
            ViewBag.contrName = "Product";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            CategoryProductModel model= new CategoryProductModel();
            model.categoryModel=cm.categoryList();
            model.productModel = new Product();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator validations = new ProductValidator();
            var result = validations.Validate(product);
            if (result.IsValid)
            {
                product.productLogoUrl = FileUpload(product);
                pm.productInsert(product);
                int page = (int)TempData["page"];
                return RedirectToAction("products-list", new { page, searchText = "" });
            }
            else
            {
                CategoryProductModel model = new CategoryProductModel();
                model.categoryModel = cm.categoryList();
                model.productModel = product;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = pm.productGetById(id);
            product.productDeleted = true;
            pm.productUpdate(product);
            int page = (int)TempData["page"];
            return RedirectToAction("products-list", new { page, searchText = "" });
        }
        public IActionResult UpdateProduct(int id)
        {
            CategoryProductModel model = new CategoryProductModel();
            model.categoryModel = cm.categoryList();
            model.productModel = pm.productGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            ProductValidator validations = new ProductValidator();
            var result = validations.Validate(product);
            if (result.IsValid)
            {
                product.productLogoUrl = FileUpload(product);
                pm.productUpdate(product);
                int page = (int)TempData["page"];
                return RedirectToAction("products-list", new { page, searchText = "" });
            }
            else
            {
                CategoryProductModel model = new CategoryProductModel();
                model.categoryModel = cm.categoryList();
                model.productModel = product;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        private string FileUpload(Product product)
        {
            string uniquefileName = "";
            if (product.imgFile != null)
            {
                uniquefileName = Guid.NewGuid().ToString() + "_" + product.imgFile.FileName;
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "product_images");
                string filePath = Path.Combine(uploadfolder, uniquefileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    product.imgFile.CopyTo(stream);
                }
            }
            return uniquefileName;
        }
    }
}
