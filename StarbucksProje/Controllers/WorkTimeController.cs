using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using BusinessLayer.Validaitons;
using System.Drawing;
using DataAccessLayer.ConCreate;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class WorkTimeController : Controller
    {
        WorkTimeManager wm = new WorkTimeManager(new EfWorkTimeRepository());

        public IActionResult ListWorkTime(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<WorkTime> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.WorkTimes.Where(workTime => workTime.openingTime.ToString().Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.WorkTimes.Where(workTime => workTime.openingTime.ToString().Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.WorkTimes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.WorkTimes.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "cargoProcess-list";
            ViewBag.contrName = "CargoProcess";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddWorkTime()
        {
            var workTime = new WorkTime();
            return View(workTime);
        }
        [HttpPost]
        public IActionResult AddWorkTime(WorkTime workTime)
        {
            WorkTimeValidator validations = new WorkTimeValidator();
            var result = validations.Validate(workTime);
            if (result.IsValid)
            {
                wm.WorkTimeInsert(workTime);
                return RedirectToAction("ListWorkTime");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(workTime);
            }
        }
        public IActionResult DeleteWorkTime(int id)
        {
            WorkTime workTime = wm.WorkTimeGetById(id);
            workTime.WorkTimeDeleted = true;
            wm.WorkTimeUpdate(workTime);
            return RedirectToAction("ListWorkTime");
        }
        [HttpGet]
        public IActionResult UpdateWorkTime(int id)
        {
            WorkTime workTime = wm.WorkTimeGetById(id);
            return View(workTime);

        }
        [HttpPost]
        public IActionResult UpdateWorkTime(WorkTime workTime)
        {
            WorkTimeValidator validations = new WorkTimeValidator();
            var result = validations.Validate(workTime);
            if (result.IsValid)
            {
                wm.WorkTimeUpdate(workTime);
                return RedirectToAction("ListWorkTime");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(workTime);
            }
        }

    }
}
