using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using X.PagedList;

namespace StarbucksProje.Controllers
{
    public class OptionController : Controller
    {
        OptionManager om = new OptionManager(new EfOptionRepository());
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var options=om.optionList().ToPagedList(page,pageSize);
            return View(options);
        }
        [HttpGet]
        public IActionResult AddOption() 
        {
            OptionListAndTypeModel model = new OptionListAndTypeModel();
            model.optionListModel= om.optionList();
            model.optionTypeModel=otm.optionTypeList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddOption(Option option)
        {
            OptionValidator validations = new OptionValidator();
            var result = validations.Validate(option);
            if (result.IsValid)
            {
                om.optionInsert(option);
                return RedirectToAction("Index");
            }
            else
            {
                OptionListAndTypeModel model = new OptionListAndTypeModel();
                model.optionListModel = om.optionList();
                model.optionTypeModel = otm.optionTypeList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            
        }
        public IActionResult DeleteOption(int id)
        {
            var option = om.optionGetById(id);
            option.optionDeleted = true;
            om.optionUpdate(option);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateOption(int id)
        {
            OptionListAndTypeModel model = new OptionListAndTypeModel();
            model.optionListModel = om.optionList();
            model.optionTypeModel = otm.optionTypeList();
            model.optionModel = om.optionGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateOption(Option option)
        {
            OptionValidator validations = new OptionValidator();
            var result = validations.Validate(option);
            if (result.IsValid)
            {
                om.optionUpdate(option);
                return RedirectToAction("Index");
            }
            else
            {
                OptionListAndTypeModel model = new OptionListAndTypeModel();
                model.optionListModel = om.optionList();
                model.optionTypeModel = otm.optionTypeList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
