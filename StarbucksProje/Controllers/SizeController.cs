using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;

namespace StarbucksProje.Controllers
{
	public class SizeController : Controller
	{
		SizeManager sm = new SizeManager(new EfSizeRepository());
		public IActionResult ListSize()
		{
			var sizes = sm.sizeList();
			return View(sizes);
		}
        [HttpGet]
        public IActionResult AddSize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSize(Size size)
        {
            sm.sizeInsert(size);
            return RedirectToAction("ListSize");
        }
        public IActionResult DeleteSize(int id)
        {
            Size size = sm.sizeGetById(id);
            size.sizeDeleted = true;
            sm.sizeUpdate(size);
            return RedirectToAction("ListSize");
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
            
                sm.sizeUpdate(size);
                return RedirectToAction("ListSize");           
        }
    }
}
