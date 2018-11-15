using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService os = new OrderService();

        [TestInitialize()]
        public void init()
        {
            Customer customer1 = new Customer(1, "liuwang");
            Customer customer2 = new Customer(2, "jams");

            Goods apple = new Goods(3, "apple", 5.59);
            Goods egg = new Goods(2, "egg", 4.99);
            Goods milk = new Goods(1, "milk", 69.9);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, egg, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Goods milk = new Goods(1, "milk", 69.9);
            Customer customer2 = new Customer(2, "jams");
            Order order3 = new Order(3, customer2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            order3.AddDetails(orderDetails3);

            try
            {
                os.AddOrder(order3);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Order is already existed!");
            }
        }


        [TestMethod()]
        public void RemoveOrderTest()
        {
            os.RemoveOrder(3);
            Assert.AreEqual(os.QueryAllOrders().Count, 2);
            os.RemoveOrder(100);
            Assert.AreEqual(os.QueryAllOrders().Count, 2);
        }

        [TestMethod()]
        public void QueryOrderByIdTest()
        {
            Assert.IsNotNull(os.GetById(2));
            Assert.IsNull(os.GetById(100));
        }

        [TestMethod()]
        public void QueryOrdersByGoodsNameTest()
        {
            Assert.AreEqual(os.QueryByGoodsName("apple").Count, 1);
            Assert.AreEqual(os.QueryByGoodsName("egg").Count, 2);
            Assert.AreEqual(os.QueryByGoodsName("milk").Count, 3);
            Assert.AreEqual(os.QueryByGoodsName("orange").Count, 0);
        }

        [TestMethod()]
        public void QueryOrdersByCustomerNameTest()
        {
            Assert.AreEqual(os.QueryByCustomerName("liuwang").Count, 1);
            Assert.AreEqual(os.QueryByCustomerName("jams").Count, 2);
            Assert.AreEqual(os.QueryByCustomerName("Lysa").Count, 0);
        }

        [TestMethod()]
        public void ExportTest()
        {
            string output = os.Export();
            Assert.IsTrue(File.Exists(output));
            string[] expectStr = File.ReadAllLines("../../ordersTarget.xml");
            string[] outputStr = File.ReadAllLines(output);
            Assert.AreEqual(expectStr.Length, outputStr.Length);
            for (int i = 0; i < expectStr.Length; i++)
            {
                Assert.AreEqual(expectStr[i].Trim(), outputStr[i].Trim());
            }

        }

        [TestMethod()]
        public void ImportTest1()
        {
            OrderService os = new OrderService();
            os.Import("../../ordersTarget.xml");
            Assert.AreEqual(os.QueryAllOrders().Count, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ImportTest2()
        {
            OrderService os = new OrderService();
            os.Import("../../OrderSerializeTests.dll");
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ImportTest3()
        {
            OrderService os = new OrderService();
            os.Import("../../ordersNotExist.xml");
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ImportTest4()
        {
            OrderService os = new OrderService();
            os.Import("../../ordersErrorContain.xml");
        }
    }
}