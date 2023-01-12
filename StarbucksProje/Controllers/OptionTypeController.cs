using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class OptionTypeController : Controller
    {
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult ListOptionType()
        {
            var optionTypes = otm.optionTypeList();
            return View(optionTypes);
        }
        [HttpGet]
        public IActionResult AddOptionType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOptionType(OptionType optionType)
        {
            OptionTypeValidator validations = new OptionTypeValidator();
            var result = validations.Validate(optionType);
            if (result.IsValid)
            {
                otm.optionTypeInsert(optionType);
                return RedirectToAction("ListOptionType");
            }
            else 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(optionType);
            }
        }
        public IActionResult DeleteOptionType(int id)
        {
            OptionType optionType = otm.optionTypeGetById(id);
            optionType.optionTypeDeleted = true;
            otm.optionTypeUpdate(optionType);
            return RedirectToAction("ListOptionType");
        }
        [HttpGet]
        public IActionResult UpdateOptionType(int id)
        {
            OptionType optionType = otm.optionTypeGetById(id);
            return View(optionType);
        }
        [HttpPost]
        public IActionResult UpdateOptionType(OptionType optionType)
        {
            OptionTypeValidator validations = new OptionTypeValidator();
            var result = validations.Validate(optionType);
            if (result.IsValid)
            {
                otm.optionTypeUpdate(optionType);
                return RedirectToAction("ListOptionType");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(optionType);
            }
            
        }
    }
}
