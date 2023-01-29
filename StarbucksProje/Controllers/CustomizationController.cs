using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class CustomizationController : Controller
    {
        CustomizationManager cm = new CustomizationManager(new EfCustomizationRepository());
        OptionManager om= new OptionManager(new EfOptionRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Customization> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Customizations.Where(customization => customization.customizationName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Customizations.Where(customization => customization.customizationName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Customizations.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Customizations.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "customizations-list";
            ViewBag.contrName = "Customization";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddCustomization() 
        {
            CustomizationOptionModel model=new CustomizationOptionModel();
            model.optionModel=om.optionList();
            model.customizationModel = new Customization();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCustomization(Customization customization)
        {
            CustomizationValidator validations = new CustomizationValidator();
            var result = validations.Validate(customization);
            if (result.IsValid)
            {
                cm.customizationInsert(customization);
                int page = (int)TempData["page"];
                return RedirectToAction("customizations-list", new { page, searchText = "" });
            }
            else
            {
                CustomizationOptionModel model = new CustomizationOptionModel();
                model.optionModel = om.optionList();
                model.customizationModel = customization;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        public IActionResult DeleteCustomization(int id)
        {
            var customization=cm.customizationGetById(id);
            customization.customizationDeleted = true;
            cm.customizationUpdate(customization);
            int page = (int)TempData["page"];
            return RedirectToAction("customizations-list", new { page, searchText = "" });
        }
        [HttpGet]
        public IActionResult UpdateCustomization(int id)
        {
            CustomizationOptionModel model = new CustomizationOptionModel();
            model.optionModel = om.optionList();
            model.customizationModel = cm.customizationGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCustomization(Customization customization)
        {
            CustomizationValidator validations = new CustomizationValidator();
            var result = validations.Validate(customization);
            if (result.IsValid)
            {
                cm.customizationUpdate(customization);
                int page = (int)TempData["page"];
                return RedirectToAction("customizations-list", new { page, searchText = "" });
            }
            else
            {
                CustomizationOptionModel model = new CustomizationOptionModel();
                model.optionModel = om.optionList();
                model.customizationModel = customization;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
