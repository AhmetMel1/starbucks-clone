using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using BusinessLayer.Validaitons;

namespace StarbucksProje.Controllers
{
	public class SizeController : Controller
	{
		SizeManager sm = new SizeManager(new EfSizeRepository());
		public IActionResult Index()
		{
			var sizes = sm.sizeList();
			return View(sizes);
		}
        [HttpGet]
        public IActionResult AddSize()
        {
            var size = new Size();
            return View(size);
        }

        [HttpPost]
        public IActionResult AddSize(Size size)
        {
            SizeValidator validations = new SizeValidator();
            var result = validations.Validate(size);
            if (result.IsValid)
            {
                sm.sizeInsert(size);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(size);
            }
        }
        public IActionResult DeleteSize(int id)
        {
            Size size = sm.sizeGetById(id);
            size.sizeDeleted = true;
            sm.sizeUpdate(size);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSize(int id)
        {
            Size size = sm.sizeGetById(id); 
            return View(size);
        }
        [HttpPost]
        public IActionResult UpdateSize(Size size)
        {
            SizeValidator validations = new SizeValidator();
            var result = validations.Validate(size);
            if (result.IsValid)
            {
                sm.sizeUpdate(size);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(size);
            }           
        }
    }
}
