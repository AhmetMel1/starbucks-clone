using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class StoreOpeningHourController : Controller
    {
        StoreOpeningHourManager shm = new StoreOpeningHourManager(new EfStoreOpeningHourRepository());
        WorkTimeManager wtm = new WorkTimeManager(new EfWorkTimeRepository());
        StoreManager sm = new StoreManager(new EfStoreRepository());
        public IActionResult Index()
        {
            var storeOpeningHour = shm.StoreOpeningHourList();
            return View(storeOpeningHour);
        }
        [HttpGet]
        public IActionResult AddStoreOpeningHour()
        {
            StoreOpeningHourModel model = new StoreOpeningHourModel();
            model.workTimeModel = wtm.WorkTimeList();
            model.storeModel = sm.storeList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStoreOpeningHour(StoreOpeningHour storeOpeningHour)
        {
            shm.StoreOpeningHourInsert(storeOpeningHour);
            return RedirectToAction("Index");
        }
        public IActionResult DeletetoreOpeningHour(int id)
        {
            var storeOpeningHour = shm.StoreOpeningHourGetById(id);
            storeOpeningHour.StoreOpeningHourDeleted = true;
            shm.StoreOpeningHourUpdate(storeOpeningHour);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStoreOpeningHour(int id)
        {
            StoreOpeningHourModel model = new StoreOpeningHourModel();
            model.workTimeModel = wtm.WorkTimeList();
            model.storeModel = sm.storeList();
            model.storeOpeningHourModel = shm.StoreOpeningHourGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateStoreOpeningHour(StoreOpeningHour storeOpeningHour)
        {
            shm.StoreOpeningHourUpdate(storeOpeningHour);
            return RedirectToAction("Index");
        }
    }
}
