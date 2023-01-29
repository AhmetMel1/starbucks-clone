using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;
using System;

namespace StarbucksProje.Controllers
{
    public class UserController : Controller
    {
        AddressManager adrsm = new AddressManager(new EfAddressRepository());
        UserManager um= new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<User> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Users.Where(user => user.name.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Users.Where(user => user.name.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Users.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "user-list";
            ViewBag.contrName = "User";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            UseraddressIdModel model = new UseraddressIdModel();
            model.addressModel = adrsm.addresslist();
            model.userModel = new User();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            UserValidator validations = new UserValidator();
            var result = validations.Validate(user);
            if (result.IsValid)
            {
                um.userInsert(user);
                int page = (int)TempData["page"];
                return RedirectToAction("user-list", new { page, searchText = "" });
            }
            else
            {
                UseraddressIdModel model = new UseraddressIdModel();
                model.addressModel = adrsm.addresslist();
                model.userModel = user;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
        public IActionResult DeleteUser(int id)
        {
            var user = um.UserGetById(id);
            user.userDeleted = true;
            um.userUpdate(user);
            int page = (int)TempData["page"];
            return RedirectToAction("user-list", new { page, searchText = "" });
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            UseraddressIdModel model = new UseraddressIdModel();
            model.addressModel = adrsm.addresslist();
            model.userModel = um.UserGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            UserValidator validations = new UserValidator();
            var result = validations.Validate(user);
            if (result.IsValid)
            {
                um.userUpdate(user);
                int page = (int)TempData["page"];
                return RedirectToAction("user-list", new { page, searchText = "" });
            }
            else
            {
                UseraddressIdModel model = new UseraddressIdModel();
                model.addressModel = adrsm.addresslist();
                model.userModel = user;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
