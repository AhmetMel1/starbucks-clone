using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;

namespace StarbucksProje.Controllers
{
    public class AddressController : Controller
    {
        AddressManager addrsm = new AddressManager(new EfAddressRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Address> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Addresses.Where(address => address.city.Contains(searchText) || address.district.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Addresses.Where(address => address.city.Contains(searchText) || address.district.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Addresses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Addresses.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "address-list";
            ViewBag.contrName = "Address";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddAddress()
        {
            var address=new Address();
            return View(address);
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
