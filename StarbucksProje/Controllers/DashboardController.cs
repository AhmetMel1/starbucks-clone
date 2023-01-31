using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class DashboardController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        UserManager um = new UserManager(new EfUserRepository());
        OrderManager om = new OrderManager(new EfOrderRepository());
        public IActionResult Dashboard()
        {
            DashboardModel model= new DashboardModel();
            model.adminModel = adm.adminlist();
            model.userModel = um.userList();
            model.orderModel = om.orderList();

            return View(model);
        }
    }
}
