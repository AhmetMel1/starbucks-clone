using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using X.PagedList;

namespace StarbucksProje.Controllers
{
    public class ProductCustomizationController : Controller
    {
        ProductCustomizationManager pcm = new ProductCustomizationManager(new EfProductCustomizationRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        CustomizationManager cm = new CustomizationManager(new EfCustomizationRepository());
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var productCustomizations=pcm.productCustomizationList().ToPagedList(page, pageSize);
            return View(productCustomizations);
        }
        [HttpGet]
        public IActionResult AddProductCustomization()
        {
            ProductCustomizationModel model = new ProductCustomizationModel();
            model.productModel = pm.productList();
            model.customizationModel = cm.customizationList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProductCustomization(ProductCustomization productCustomization)
        {
            pcm.productCustomizationInsert(productCustomization);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProductCustomization(int id)
        {
            var productCustomization = pcm.productCustomizationGetById(id);
            productCustomization.productCustomizationDeleted = true;
            pcm.productCustomizationUpdate(productCustomization);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProductCustomization(int id)
        {
            ProductCustomizationModel model = new ProductCustomizationModel();
            model.productModel = pm.productList();
            model.customizationModel = cm.customizationList();
            model.productCustomizationModel = pcm.productCustomizationGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductCustomization(ProductCustomization productCustomization)
        {
            pcm.productCustomizationUpdate(productCustomization);
            return RedirectToAction("Index");
        }
    }
}
