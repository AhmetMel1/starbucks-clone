using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class SliderController: Controller
    {
        SliderManager sliderManager = new SliderManager(new EfSliderRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Slider> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Sliders.Where(slider => slider.sliderName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Sliders.Where(slider => slider.sliderName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Sliders.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Sliders.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "slider-list";
            ViewBag.contrName = "Slider";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddSlider()
        {
            var slider = new Slider();
            return View(slider);
        }
        [HttpPost]
        public IActionResult AddSlider(Slider slider)
        {
            SliderValidator validations = new SliderValidator();
            var result = validations.Validate(slider);
            if (result.IsValid)
            {
                sliderManager.sliderInsert(slider);
                int page = (int)TempData["page"];
                return RedirectToAction("slider-list", new { page, searchText = "" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(slider);
            }
        }

          public IActionResult DeleteSlider(int id)
        {
            var slider=sliderManager.SliderGetById(id);
            slider.sliderDeleted=true;
            sliderManager.sliderUpdate(slider);
            int page = (int)TempData["page"];
            return RedirectToAction("slider-list", new { page, searchText = "" });
        }
        [HttpGet]
        public IActionResult UpdateSlider(int id)
        {
            var slider = sliderManager.SliderGetById(id);
            return View(slider);
        }
        [HttpPost]
        public IActionResult UpdateSlider(Slider slider)
        {
            SliderValidator validations = new SliderValidator();
            var result = validations.Validate(slider);
            if (result.IsValid)
            {
                sliderManager.sliderUpdate(slider);
                int page = (int)TempData["page"];
                return RedirectToAction("slider-list", new { page, searchText = "" });

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(slider);
            }
        }
    }
}
