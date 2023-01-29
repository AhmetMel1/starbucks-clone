using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class OptionTypeController : Controller
    {
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<OptionType> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.OptionTypes.Where(optionType => optionType.optionTypeName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.OptionTypes.Where(optionType => optionType.optionTypeName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.OptionTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.OptionTypes.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "option-type-list";
            ViewBag.contrName = "OptionType";
            ViewBag.searchText = searchText;
            return View(data);
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
                int page = (int)TempData["page"];
                return RedirectToAction("option-type-list", new { page, searchText = "" });
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
            int page = (int)TempData["page"];
            return RedirectToAction("option-type-list", new { page, searchText = "" });
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
                int page = (int)TempData["page"];
                return RedirectToAction("option-type-list", new { page, searchText = "" });
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
