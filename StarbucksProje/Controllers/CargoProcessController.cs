using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
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
        public IActionResult AddCargoProcess() 
        {
            return View();
        }

    }
}
