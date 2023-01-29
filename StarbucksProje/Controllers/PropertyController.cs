using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class PropertyController : Controller
    {
        PropertyManager pm = new PropertyManager(new EfPropertyRepository());

        public IActionResult ListProperty(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Property> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Properties.Where(properties => properties.PropertyName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Properties.Where(properties => properties.PropertyName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Properties.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Properties.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "propertys-list";
            ViewBag.contrName = "Property";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddProperty()
        {
            var property = new Property();
            return View(property);
        }
        [HttpPost]
        public IActionResult AddProperty(Property property)
        {
            PropertyValidator validations = new PropertyValidator();
            var result = validations.Validate(property);
            if (result.IsValid)
            {
                pm.PropertyInsert(property);
                int page = (int)TempData["page"];
                return RedirectToAction("propertys-list", new { page, searchText = "" });
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
            int page = (int)TempData["page"];
            return RedirectToAction("propertys-list", new { page, searchText = "" });
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
                int page = (int)TempData["page"];
                return RedirectToAction("propertys-list", new { page, searchText = "" });
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
