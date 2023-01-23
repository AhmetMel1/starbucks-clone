using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class PropertyController : Controller
    {
        PropertyManager pm = new PropertyManager(new EfPropertyRepository());

        public IActionResult ListProperty()
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
            PropertyValidator validations = new PropertyValidator();
            var result = validations.Validate(property);
            if (result.IsValid)
            {
                pm.PropertyInsert(property);
                return RedirectToAction("ListProperty");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(property);
            }
        }
        public IActionResult DeleteProperty(int id)
        {
            Property property = pm.PropertyGetById(id);
            property.PropertyDeleted= true;
            pm.PropertyUpdate(property);
            return RedirectToAction("ListProperty");
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
            PropertyValidator validations = new PropertyValidator();
            var result = validations.Validate(property);
            if (result.IsValid)
            {
                pm.PropertyUpdate(property);
                return RedirectToAction("ListProperty");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(property);
            }
        }

    }
}
