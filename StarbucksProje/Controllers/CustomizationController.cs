using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using StarbucksProje.Models;
using X.PagedList;

namespace StarbucksProje.Controllers
{
    public class CustomizationController : Controller
    {
        CustomizationManager cm = new CustomizationManager(new EfCustomizationRepository());
        OptionManager om= new OptionManager(new EfOptionRepository());
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var customizations = cm.customizationList().ToPagedList(page,pageSize);
            return View(customizations);
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
                return RedirectToAction("Index");
            }
            else
            {
                CustomizationOptionModel model = new CustomizationOptionModel();
                model.optionModel = om.optionList();
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
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
