using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using EntityLayer;
using DataAccessLayer.ConCreate;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class StorePropertyController : Controller
    {
        StorePropertyManager spm = new StorePropertyManager(new EfStorePropertyRepository());
        PropertyManager pm = new PropertyManager(new EfPropertyRepository());
        StoreManager sm = new StoreManager(new EfStoreRepository());

        public IActionResult ListStoreProperty(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<StoreProperty> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.StoreProperties.Where(storeProperty => storeProperty.Store.StoreName.Contains(searchText) || storeProperty.Property.PropertyName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreProperties.Where(storeProperty => storeProperty.Store.StoreName.Contains(searchText) || storeProperty.Property.PropertyName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.StoreProperties.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreProperties.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "store-propety-list";
            ViewBag.contrName = "StoreProperty";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddStoreProperty()
        {
            StorePropertyModel model = new StorePropertyModel();
            model.storeModel = sm.storeList();
            model.propertyModel = pm.PropertyList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStoreProperty(StoreProperty storeProperty)
        {
            spm.StorePropertyUpdate(storeProperty);
            int page = (int)TempData["page"];
            return RedirectToAction("store-property-list", new { page, searchText = "" });
        }
        public IActionResult DeleteStoreProperty(int id)
        {
            StoreProperty storeProperty = spm.StorePropertyGetById(id);
            storeProperty.StorePropertyDeleted=true;
            spm.StorePropertyUpdate(storeProperty);
            int page = (int)TempData["page"];
            return RedirectToAction("store-property-list", new { page, searchText = "" });
        }
        [HttpGet]
        public IActionResult UpdateStoreProperty(int id)
        {
            StorePropertyModel model=new StorePropertyModel();
            model.storeModel = sm.storeList();
            model.propertyModel = pm.PropertyList();
            model.storePropertyModel = spm.StorePropertyGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateStoreProperty(StoreProperty storeProperty)
        {
            spm.StorePropertyUpdate(storeProperty);
            int page = (int)TempData["page"];
            return RedirectToAction("store-property-list", new { page, searchText = "" });
        }
    }
}
