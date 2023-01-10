using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult ListProduct()
        {
            var products=pm.productList();
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            CategoryProductModel model= new CategoryProductModel();
            model.categoryModel=cm.categoryList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            pm.productInsert(product);
            return RedirectToAction("ListProduct");
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = pm.productGetById(id);
            product.productDeleted = true;
            pm.productUpdate(product);
            return RedirectToAction("ListProduct");
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
            pm.productUpdate(product);
            return RedirectToAction("ListProduct");
        }
    }
}
