using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class AddressController : Controller
    {
        AddressManager addrsm = new AddressManager(new EfAddressRepository());
        public IActionResult Index()
        {
            var Address = addrsm.addresslist();
            return View(Address);
        }
        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            addrsm.addressInsert(address);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAddress(int id)
        {
            var address = addrsm.AddressGetById(id);
            address.addressDeleted = true;
            addrsm.addressUpdate(address);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var address = addrsm.AddressGetById(id);
            return View(address);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {
            addrsm.addressUpdate(address);
            return RedirectToAction("Index");
        }
    }
}
