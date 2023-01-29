using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class StoreOpeningHourController : Controller
    {
        StoreOpeningHourManager shm = new StoreOpeningHourManager(new EfStoreOpeningHourRepository());
        WorkTimeManager wtm = new WorkTimeManager(new EfWorkTimeRepository());
        StoreManager sm = new StoreManager(new EfStoreRepository());
        public IActionResult ListStoreOpeningHour(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<StoreOpeningHour> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.StoreOpeningHours.Where(storeOpeningHour => storeOpeningHour.Store.StoreName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreOpeningHours.Where(storeOpeningHour => storeOpeningHour.Store.StoreName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.StoreOpeningHours.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.StoreOpeningHours.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "store-opening-hour-list";
            ViewBag.contrName = "StoreOpeningHour";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddStoreOpeningHour()
        {
            StoreOpeningHourModel model = new StoreOpeningHourModel();
            model.workTimeModel = wtm.WorkTimeList();
            model.storeModel = sm.storeList();
            model.storeOpeningHourModel = new StoreOpeningHour();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStoreOpeningHour(StoreOpeningHour storeOpeningHour)
        {
            shm.StoreOpeningHourInsert(storeOpeningHour);
            return RedirectToAction("ListStoreOpeningHour");
        }
        public IActionResult DeleteStoreOpeningHour(int id)
        {
            var storeOpeningHour = shm.StoreOpeningHourGetById(id);
            storeOpeningHour.StoreOpeningHourDeleted = true;
            shm.StoreOpeningHourUpdate(storeOpeningHour);
            return RedirectToAction("ListStoreOpeningHour");
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
            return RedirectToAction("ListStoreOpeningHour");
        }
    }
}
