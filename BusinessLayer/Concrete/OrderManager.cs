using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            this.orderDal = orderDal;
        }
        public void orderDelete(Order order)
        {
            orderDal.delete(order);
        }

        public Order OrderGetById(int id)
        {
            return orderDal.get(x => x.orderId == id);
        }

        public void orderInsert(Order order)
        {
            orderDal.insert(order);
        }

        public List<Order> orderList()
        {
            return orderDal.list();
        }

        public void orderUpdate(Order order)
        {
            orderDal.update(order);
        }
    }
}
