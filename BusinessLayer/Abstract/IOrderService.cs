using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService
    {
        void orderInsert(Order order);
        void orderDelete(Order order);
        void orderUpdate(Order order);
        List<Order> orderList();
        Order OrderGetById(int id);
    }
}
