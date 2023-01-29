using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class OptionController : Controller
    {
        OptionManager om = new OptionManager(new EfOptionRepository());
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Option> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Options.Where(option => option.optionName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Options.Where(option => option.optionName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Options.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Options.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "option-list";
            ViewBag.contrName = "Option";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddOption() 
        {
            OptionListAndTypeModel model = new OptionListAndTypeModel();
            model.optionListModel= om.optionList();
            model.optionTypeModel=otm.optionTypeList();
            model.optionModel = new Option();
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
                int page = (int)TempData["page"];
                return RedirectToAction("option-list", new { page, searchText = "" });
            }
            else
            {
                OptionListAndTypeModel model = new OptionListAndTypeModel();
                model.optionListModel = om.optionList();
                model.optionTypeModel = otm.optionTypeList();
                model.optionModel = option;
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
            int page = (int)TempData["page"];
            return RedirectToAction("option-list", new { page, searchText = "" });
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
                int page = (int)TempData["page"];
                return RedirectToAction("option-list", new { page, searchText = "" });
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
