using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StarbucksProje.Controllers
{
    public class UserController : Controller
    {
        UserManager um= new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var users = um.userList();
            return View(users);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            um.userInsert(user);
            return RedirectToAction("Index");
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
            var user = um.UserGetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            um.userUpdate(user);
            return RedirectToAction("Index");
        }
    }
}
