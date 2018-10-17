using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderService
    {
        private List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }

        //添加订单
        public void Addorder(Order order)
        {
            if (orderList.Contains(order))
                throw new Exception("该订单已存在！");
            orderList.Add(order);
        }

        //删除订单
        public void Removeorder(uint orderId)
        {
            //var targetorder = from n in orderList
            //                  where n.Id == orderId
            //                  select n;
            //foreach (var n in targetorder)
            //    orderList.Remove(n);                 //这里不能这么写，按下一行的写法
            orderList.RemoveAll(n => n.Id == orderId);
        }

        //查询所有订单
        public List<Order> Queryallorders()
        {
            return orderList;
        }

        //通过订单号来查询
        public List<Order> Querybyid(uint orderId)
        {
            var targetorder = orderList.Where(n => n.Id == orderId).ToList();
            return targetorder;
            //return orderList.Where(n => n.Id == orderId).ToList();
        }

        //通过客户名字来查询
        public List<Order> Querybycustomername(string customerName)
        {
            return orderList.Where(order => order.Customer.Name == customerName).ToList();
        }

        //通过货物名称来查询
        public List<Order> Querybygoodsname(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderList)
                foreach (OrderDetail detail in order.Details)
                    if (detail.Goods.Name == goodsName)
                    {
                        result.Add(order);
                        break;
                    }
            return result;
        }
    }
}
