using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;

namespace StarbucksProje.Controllers
{
    public class OrderController : Controller
    {

        OrderManager om = new OrderManager(new EfOrderRepository());
        UserManager um = new UserManager(new EfUserRepository());
        ProductSizeManager psm = new ProductSizeManager(new EfProductSizeRepository());
        CargoProccessManager cpm = new CargoProccessManager(new EfCargoProccessRepository());
        public IActionResult Index()
        {
            var Order = om.orderList();
            return View(Order);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            OrderProductSizeCargoProccessIdUserIdModel model = new OrderProductSizeCargoProccessIdUserIdModel();
            model.productSizeModel = psm.productSizeList();
            model.userModel = um.userList();
            model.cargoProcessesModel = cpm.cargoProccessList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            om.orderInsert(order);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteOrder(int id)
        {
            var order = om.OrderGetById(id);
            order.orderDeleted = true;
            om.orderUpdate(order);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            OrderProductSizeCargoProccessIdUserIdModel model = new OrderProductSizeCargoProccessIdUserIdModel();
            model.productSizeModel = psm.productSizeList();
            model.userModel = um.userList();
            model.cargoProcessesModel = cpm.cargoProccessList();
            model.orderModel = om.OrderGetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            om.orderUpdate(order);
            return RedirectToAction("Index");
        }
    }
}
