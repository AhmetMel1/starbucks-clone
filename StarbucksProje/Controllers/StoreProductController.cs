using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class StoreProductController : Controller
    {
        StoreProductManager spm = new StoreProductManager(new EfStoreProductRepository());
        StoreManager sm=new StoreManager(new EfStoreRepository());
        ProductManager pm=new ProductManager(new EfProductRepository());

        public IActionResult ListStoreProduct()
        {
            var storeProduct = spm.StoreProductsList();
            return View(storeProduct);
        }
        [HttpGet]
        public IActionResult AddStoreProduct()
        {
            StoreProductModel model = new StoreProductModel();
            model.storeModel = sm.storeList();
            model.productModel=pm.productList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStoreProduct(StoreProduct storeProduct)
        {
            spm.StoreProductUpdate(storeProduct);
            return RedirectToAction("ListStoreProduct");
        }
        public IActionResult DeleteStoreProduct(int id)
        {
            StoreProduct storeProduct=spm.StoreProductGetById(id);
            storeProduct.StoreProductDeleted=true;
            spm.StoreProductUpdate(storeProduct);
            return RedirectToAction("ListStoreProduct");
        }
        [HttpGet]
        public IActionResult UpdateStoreProduct(int id)
        {
            StoreProductModel model=new StoreProductModel();
            model.storeModel = sm.storeList();
            model.productModel=pm.productList();
            model.storeProductModel = spm.StoreProductGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateStoreProduct(StoreProduct storeProduct)
        {
            spm.StoreProductUpdate(storeProduct);
            return RedirectToAction("ListStoreProduct");
        }
    }
}
