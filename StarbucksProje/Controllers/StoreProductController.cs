using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class StoreProductController : Controller
    {
        StoreProductManager spm = new StoreProductManager(new EfStoreProductRepository());
        StoreManager sm=new StoreManager(new EfStoreRepository());
        ProductManager pm=new ProductManager(new EfProductRepository());

        public IActionResult ListStoreProduct(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<StoreProduct> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.StoreProducts.Where(storeProduct => storeProduct.Store.StoreName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreProducts.Where(storeProduct => storeProduct.Store.StoreName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.StoreProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreProducts.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "store-list";
            ViewBag.contrName = "Store";
            ViewBag.searchText = searchText;
            return View(data);
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
