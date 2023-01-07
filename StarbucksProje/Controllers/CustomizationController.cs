using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class CustomizationController : Controller
    {
        CustomizationManager cm = new CustomizationManager(new EfCustomizationRepository());
        OptionManager om= new OptionManager(new EfOptionRepository());
        public IActionResult Index()
        {
            var customizations = cm.customizationList();
            return View(customizations);
        }
        [HttpGet]
        public IActionResult AddCustomization() 
        {
            CustomizationOptionModel model=new CustomizationOptionModel();
            model.optionModel=om.optionList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCustomization(Customization customization)
        {
            cm.customizationInsert(customization);
            return RedirectToAction("Index");
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
            cm.customizationUpdate(customization);
            return RedirectToAction("Index");
        }
    }
}
