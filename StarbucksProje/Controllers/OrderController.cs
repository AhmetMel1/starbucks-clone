using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.ConCreate.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using StarbucksProje.Models;
using StarbucksProje.PagedList;
using System;

namespace StarbucksProje.Controllers
{
    public class OrderController : Controller
    {

        OrderManager om = new OrderManager(new EfOrderRepository());
        UserManager um = new UserManager(new EfUserRepository());
        ProductSizeManager psm = new ProductSizeManager(new EfProductSizeRepository());
        CargoProccessManager cpm = new CargoProccessManager(new EfCargoProccessRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 3;
            Context c = new Context();
            Pager pager;
            List<Order> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Order.Where(order => order.orderName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Order.Where(order => order.orderName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Order.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Order.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "order-list";
            ViewBag.contrName = "Order";
            ViewBag.searchText = searchText;
            return View(data);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            OrderProductSizeCargoProccessIdUserIdModel model = new OrderProductSizeCargoProccessIdUserIdModel();
            model.productSizeModel = psm.productSizeList();
            model.userModel = um.userList();
            model.cargoProcessesModel = cpm.cargoProccessList();
            model.orderModel = new Order();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            OrderValidator validations = new OrderValidator();
            var result = validations.Validate(order);
            if (result.IsValid)
            {
                om.orderInsert(order);
                return RedirectToAction("Index");
            }
            else
            {
                OrderProductSizeCargoProccessIdUserIdModel model = new OrderProductSizeCargoProccessIdUserIdModel();
                model.productSizeModel = psm.productSizeList();
                model.userModel = um.userList();
                model.cargoProcessesModel = cpm.cargoProccessList();
                model.orderModel = order;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
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
            OrderValidator validations = new OrderValidator();
            var result = validations.Validate(order);
            if (result.IsValid)
            {
                om.orderUpdate(order);
                return RedirectToAction("Index");
            }
            else
            {
                OrderProductSizeCargoProccessIdUserIdModel model = new OrderProductSizeCargoProccessIdUserIdModel();
                model.productSizeModel = psm.productSizeList();
                model.userModel = um.userList();
                model.cargoProcessesModel = cpm.cargoProccessList();
                model.orderModel = order;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}
