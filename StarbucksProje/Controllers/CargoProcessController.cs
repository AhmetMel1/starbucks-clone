using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

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
            cpm.cargoProccessInsert(cargoProcess);
            return RedirectToAction("Index");
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
            cpm.cargoProccessUpdate(cargoProcess);
            return RedirectToAction("Index");
        }

    }
}
