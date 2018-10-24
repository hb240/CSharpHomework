using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
    }
}