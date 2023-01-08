using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class PropertyController : Controller
    {
        PropertyManager pm = new PropertyManager(new EfPropertyRepository());

        public IActionResult Index()
        {
            var property = pm.PropertyList();
            return View(property);
        }
        [HttpGet]
        public IActionResult AddProperty()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProperty(Property property)
        {
            pm.PropertyInsert(property);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProperty(int id)
        {
            Property property = pm.PropertyGetById(id);
            property.PropertyDeleted= true;
            pm.PropertyUpdate(property);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProperty(int id)
        {
            Property property = pm.PropertyGetById(id);
            return View(property);
        }

        [HttpPost]
        public IActionResult UpdateProperty(Property property)
        {
            pm.PropertyDelete(property);
            return RedirectToAction("Index");
        }

    }
}
