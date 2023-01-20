using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

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
            AddressValidator validations = new AddressValidator();
            var result = validations.Validate(address);
            if (result.IsValid)
            {
                addrsm.addressInsert(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(address);
            } 
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
            AddressValidator validations = new AddressValidator();
            var result = validations.Validate(address);
            if (result.IsValid)
            {
                addrsm.addressUpdate(address);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(address);
            }
        }
    }
}
