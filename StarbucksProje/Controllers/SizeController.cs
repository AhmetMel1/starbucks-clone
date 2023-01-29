using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
	public class SizeController : Controller
	{
		SizeManager sm = new SizeManager(new EfSizeRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Size> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Sizes.Where(size => size.sizeName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Sizes.Where(size => size.sizeName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Sizes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Sizes.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "sizes-list";
            ViewBag.contrName = "Size";
            ViewBag.searchText = searchText;
            return View(data);
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
                int page = (int)TempData["page"];
                return RedirectToAction("sizes-list", new { page, searchText = "" });
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
            int page = (int)TempData["page"];
            return RedirectToAction("sizes-list", new { page, searchText = "" });
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
                int page = (int)TempData["page"];
                return RedirectToAction("sizes-list", new { page, searchText = "" });
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
