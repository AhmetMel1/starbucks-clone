using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace StarbucksProje.Controllers
{
    public class OptionTypeController : Controller
    {
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var optionTypes = otm.optionTypeList().ToPagedList(page,pageSize);
            return View(optionTypes);
        }
        [HttpGet]
        public IActionResult AddOptionType()
        {
            var optionType=new OptionType();
            return View(optionType);
        }

        [HttpPost]
        public IActionResult AddOptionType(OptionType optionType)
        {
            OptionTypeValidator validations = new OptionTypeValidator();
            var result = validations.Validate(optionType);
            if (result.IsValid)
            {
                otm.optionTypeInsert(optionType);
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
