using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OrderManage.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddorderTest()
        {
            OrderService os = new OrderService();
            Order order1 = new Order();
            List<Order> list1 = new List<Order>() { order1 };
            os.OrderList.Add(order1);
            Assert.IsTrue(os.OrderList.SequenceEqual(list1));
        }

        [TestMethod()]
        public void RemoveorderTest()
        {
            OrderService os = new OrderService();
            Order order1 = new Order();
            Order order2 = new Order();
            List<Order> list1 = new List<Order>() { order2 };
            os.OrderList.Add(order1);
            os.OrderList.Add(order2);
            os.OrderList.Remove(order1);
            Assert.IsTrue(os.OrderList.SequenceEqual(list1));
        }

        [TestMethod()]
        public void ExportTest()
        {
            Customer customer1 = new Customer(1, "customer1");
            Goods milk = new Goods("milk", 88);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 1);
            Order order1 = new Order(1, customer1);
            OrderService client = new OrderService();
            client.Addorder(order1);
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            client.Export(xmlser, "orderlist.xml");
            Assert.IsNotNull(FileStream fs);
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
    }
}