using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using BusinessLayer.Validaitons;
using System.Drawing;

namespace StarbucksProje.Controllers
{
    public class WorkTimeController : Controller
    {
        WorkTimeManager wm = new WorkTimeManager(new EfWorkTimeRepository());

        public IActionResult ListWorkTime()
        {
            var WorkTime = wm.WorkTimeList();
            return View(WorkTime);
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
