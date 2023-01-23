using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class ProductCustomizationController : Controller
    {
        ProductCustomizationManager pcm = new ProductCustomizationManager(new EfProductCustomizationRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        CustomizationManager cm = new CustomizationManager(new EfCustomizationRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<ProductCustomization> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.ProductCustomizations.Where(productCustomization => productCustomization.product.productName.Contains(searchText) ||productCustomization.customization.customizationName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.ProductCustomizations.Where(productCustomization => productCustomization.product.productName.Contains(searchText) || productCustomization.customization.customizationName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.ProductCustomizations.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.ProductCustomizations.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "product-customization-list";
            ViewBag.contrName = "ProductCustomization";
            ViewBag.searchText = searchText;
            return View(data);
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
