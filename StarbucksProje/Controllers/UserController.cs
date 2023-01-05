using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;

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
    }
}
