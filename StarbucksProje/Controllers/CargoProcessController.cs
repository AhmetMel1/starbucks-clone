using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StarbucksProje.Controllers
{
    public class CargoProcessController : Controller
    {
        CargoProccessManager cpm = new CargoProccessManager(new EfCargoProccessRepository());
        public IActionResult Index()
        {
            var cargoProceceses=cpm.cargoProccessList();
            return View(cargoProceceses);
        }
        [HttpGet]
        public IActionResult AddCargoProcess() 
        {
            return View();
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
