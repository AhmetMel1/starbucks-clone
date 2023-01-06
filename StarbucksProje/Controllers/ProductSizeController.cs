using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class ProductSizeController : Controller
    {
        ProductSizeManager psm=new ProductSizeManager(new EfProductSizeRepository());
        ProductManager pm=new ProductManager(new EfProductRepository());
        SizeManager sm=new SizeManager(new EfSizeRepository());
        public IActionResult Index()
        {
            var pruductSizes=psm.productSizeList();
            return View(pruductSizes);
        }
        [HttpGet]
        public IActionResult AddProductSize()
        {
            ProductSizeModel model=new ProductSizeModel();
            model.productModel=pm.productList();
            model.sizeModel = sm.sizeList();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProductSize(ProductSize productSize)
        {
            psm.productSizeUpdate(productSize);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProductSize(int id)
        {
            ProductSize productSize = psm.productSizeGetById(id);
            productSize.productSizeDeleted = true;
            psm.productSizeUpdate(productSize);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProductSize(int id)
        {
            ProductSizeModel model = new ProductSizeModel();
            model.productModel = pm.productList();
            model.sizeModel = sm.sizeList();
            model.productSizeModel=psm.productSizeGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductSize(ProductSize productSize)
        {
            psm.productSizeUpdate(productSize);
            return RedirectToAction("Index");
        }
    }
}
