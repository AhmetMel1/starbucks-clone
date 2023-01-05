using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        public IActionResult Index()
        {
            var admin = adm.adminList();
            return View(admin);
        }
    }
}
