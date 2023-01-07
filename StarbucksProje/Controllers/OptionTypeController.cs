using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class OptionTypeController : Controller
    {
        OptionTypeManager otm = new OptionTypeManager(new EfOptionTypeRepository());
        public IActionResult Index()
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
            otm.optionTypeInsert(optionType);
            return RedirectToAction("Index");
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

            otm.optionTypeUpdate(optionType);
            return RedirectToAction("Index");
        }
    }
}
