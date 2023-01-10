using BusinessLayer.Concrete;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace StarbucksProje.Controllers
{
    public class OrderController : Controller
    {
        OrderManager om = new OrderManager(new EfOrderRepository());
        public IActionResult Index()
        {
            var Order = om.orderList();
            return View(Order);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
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
            var order = om.OrderGetById(id);
            return View(order);
        }
        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            om.orderUpdate(order);
            return RedirectToAction("Index");
        }
    }
}
