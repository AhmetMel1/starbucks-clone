using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
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
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            adm.adminInsert(admin);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAdmin(int id)
        {
            var admin = adm.adminGetById(id);
            admin.adminDeleted = true;
            adm.adminUpdate(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var admin = adm.adminGetById(id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(Admin admin)
        {
            adm.adminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}
