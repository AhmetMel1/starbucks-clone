using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using EntityLayer;

namespace StarbucksProje.Controllers
{
    public class StorePropertyController : Controller
    {
        StorePropertyManager spm = new StorePropertyManager(new EfStorePropertyRepository());
        PropertyManager pm = new PropertyManager(new EfPropertyRepository());
        StoreManager sm = new StoreManager(new EfStoreRepository());

        public IActionResult Index()
        {
            var StoreProperty = spm.StorePropertyList();
            return View(StoreProperty);
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
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStoreProperty(int id)
        {
            StoreProperty storeProperty = spm.StorePropertyGetById(id);
            storeProperty.StorePropertyDeleted=true;
            spm.StorePropertyUpdate(storeProperty);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
