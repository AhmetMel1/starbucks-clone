using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using System;

namespace StarbucksProje.Controllers
{
    public class UserController : Controller
    {
        AddressManager adrsm = new AddressManager(new EfAddressRepository());
        UserManager um= new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var users = um.userList();
            return View(users);
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
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
