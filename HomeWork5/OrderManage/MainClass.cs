using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "customer1");
            Customer customer2 = new Customer(2, "customer2");

            Goods milk = new Goods("milk", 88);
            Goods fruit = new Goods("fruit", 5);
            Goods chips = new Goods("chips", 4);
            Goods cookies = new Goods("cookies", 5);
            Goods laptop = new Goods("laptop", 9999);

            OrderDetail orderDetails1 = new OrderDetail(1, milk, 1);
            OrderDetail orderDetails2 = new OrderDetail(2, fruit, 4);
            OrderDetail orderDetails3 = new OrderDetail(3, fruit, 3);
            OrderDetail orderDetails4 = new OrderDetail(4, chips, 4);
            OrderDetail orderDetails5 = new OrderDetail(5, chips, 3);
            OrderDetail orderDetails6 = new OrderDetail(6, cookies, 2);
            OrderDetail orderDetails7 = new OrderDetail(7, laptop, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails4);
            order1.AddDetails(orderDetails7);
            //order1.AddDetails(orderDetails6);
            order2.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails5);
            order3.AddDetails(orderDetails6);

            OrderService client = new OrderService();
            client.Addorder(order1);
            client.Addorder(order2);
            client.Addorder(order3);

            Console.WriteLine("GetAllOrders:");
            List<Order> orders = client.Queryallorders();
            foreach (Order order in orders)
                Console.WriteLine(order.ToString());

            Console.WriteLine("GetOrdersByCustomerName:'customer2'");
            orders = client.Querybycustomername("c ustomer2");
            foreach (Order order in orders)
                Console.WriteLine(order.ToString());

            Console.WriteLine("GetOrdersByGoodsName:'apple'");
            orders = client.Querybygoodsname("fruit");
            foreach (Order order in orders)
                Console.WriteLine(order.ToString());

            Console.WriteLine("Remove order(id=2) and qurey all");
            client.Removeorder(2);
            client.Queryallorders().ForEach(order => Console.WriteLine(order));

            Console.WriteLine("GetOrderByOrderMoney price>10000");
            client.Querybymoney().ForEach(order => Console.WriteLine(order));

            Console.ReadLine();
        }
    }
}
