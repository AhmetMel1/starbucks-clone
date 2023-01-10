using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class OptionController : Controller
    {
        OptionManager om = new OptionManager(new EfOptionRepository());
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult ListOption()
        {
            var options=om.optionList();
            return View(options);
        }
        [HttpGet]
        public IActionResult AddOption() 
        {
            OptionTypeModel model = new OptionTypeModel();
            model.optionModel= om.optionList();
            model.optionTypeModel=otm.optionTypeList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddOption(Option option)
        {
            om.optionInsert(option);
            return RedirectToAction("ListOption");
        }
        public IActionResult DeleteOption(int id)
        {
            var option = om.optionGetById(id);
            option.optionDeleted = true;
            om.optionUpdate(option);
            return RedirectToAction("ListOption");
        }
        [HttpGet]
        public IActionResult UpdateOption(int id)
        {
            ViewBag.id = id;
            OptionTypeModel model = new OptionTypeModel();
            model.optionModel = om.optionList();
            model.optionTypeModel = otm.optionTypeList();
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateOption(Option option)
        {
            om.optionUpdate(option);
            return RedirectToAction("ListOption");
        }
    }
}
