using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using StarbucksProje.Models;
>>>>>>> a8bc19fe68808101e9989993b00009f5aba77f4a

namespace StarbucksProje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
<<<<<<< HEAD
=======
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
>>>>>>> a8bc19fe68808101e9989993b00009f5aba77f4a
        public IActionResult Index()
        {
            var products=pm.productList();
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
<<<<<<< HEAD
            return View();
=======
            CategoryProductModel model= new CategoryProductModel();
            model.categoryModel=cm.categoryList();
            return View(model);
>>>>>>> a8bc19fe68808101e9989993b00009f5aba77f4a
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            pm.productInsert(product);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = pm.productGetById(id);
            product.productDeleted = true;
            pm.productUpdate(product);
            return RedirectToAction("Index");
        }
<<<<<<< HEAD
=======
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
            return RedirectToAction("Index");
        }
>>>>>>> a8bc19fe68808101e9989993b00009f5aba77f4a
    }
}
