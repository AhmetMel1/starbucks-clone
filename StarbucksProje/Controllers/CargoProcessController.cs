using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.PagedList;
using System.Net;

namespace StarbucksProje.Controllers
{
    public class CargoProcessController : Controller
    {
        CargoProccessManager cpm = new CargoProccessManager(new EfCargoProccessRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<CargoProcess> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.CargoProcess.Where(cargoProcess => cargoProcess.cargoProcessName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.CargoProcess.Where(cargoProcess => cargoProcess.cargoProcessName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.CargoProcess.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.CargoProcess.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "cargoProcess-list";
            ViewBag.contrName = "CargoProcess";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddCargoProcess() 
        {
            var cargoProcess=new CargoProcess();
            return View(cargoProcess);
        }
        [HttpPost]
        public IActionResult AddCargoProcess(CargoProcess cargoProcess)
        {
            CargoProccessValidator validations = new CargoProccessValidator();
            var result = validations.Validate(cargoProcess);
            if (result.IsValid)
            {
                cpm.cargoProccessInsert(cargoProcess);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(cargoProcess);
            }
        }
        public IActionResult DeleteCargoProcess(int id)
        {
            var cargoProcess=cpm.CargoProccessGetById(id);
            cargoProcess.cargoProcessDeleted=true;
            cpm.cargoProccessUpdate(cargoProcess);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCargoProcess(int id)
        {
            var cargoProcess = cpm.CargoProccessGetById(id);
            return View(cargoProcess);
        }
        [HttpPost]
        public IActionResult UpdateCargoProcess(CargoProcess cargoProcess)
        {
            CargoProccessValidator validations = new CargoProccessValidator();
            var result = validations.Validate(cargoProcess);
            if (result.IsValid)
            {
                cpm.cargoProccessUpdate(cargoProcess);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(cargoProcess);
            }
        }

    }
}
