using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;

namespace StarbucksProje.Controllers
{
    public class WorkTimeController : Controller
    {
        WorkTimeManager wm = new WorkTimeManager(new EfWorkTimeRepository());

        public IActionResult Index()
        {
            var WorkTime = wm.WorkTimeList();
            return View(WorkTime);
        }
        [HttpGet]
        public IActionResult AddWorkTime()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWorkTime(WorkTime workTime)
        {
            wm.WorkTimeInsert(workTime);
                return RedirectToAction("Index");
        }
        public IActionResult DeleteWorkTime(int id)
        {
            WorkTime workTime = wm.WorkTimeGetById(id);
            workTime.WorkTimeDeleted = true;
            wm.WorkTimeUpdate(workTime);
            return RedirectToAction("Index");
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
            wm.WorkTimeUpdate(workTime);
            return RedirectToAction("Index");
        }

    }
}
