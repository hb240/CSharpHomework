using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Client
{
    public class OrderService
    {
        public List<Order> OrderList { get; set; }
        
        public OrderService()
        {
            OrderList = new List<Order>();
        }

        //添加订单
        public void Addorder(Order order)
        {
            if (OrderList.Contains(order))
                throw new Exception("该订单已存在！");
            OrderList.Add(order);
        }

        //删除订单
        public void Removeorder(uint orderId)
        {
            //var targetorder = from n in orderList
            //                  where n.Id == orderId
            //                  select n;
            //foreach (var n in targetorder)
            //    orderList.Remove(n);                 //这里不能这么写，按下一行的写法
            OrderList.RemoveAll(n => n.Id == orderId);
        }

        //查询所有订单
        public List<Order> Queryallorders()
        {
            return OrderList;
        }

        //通过订单号来查询
        public List<Order> Querybyid(uint orderId)
        {
            var targetorder = OrderList.Where(n => n.Id == orderId).ToList();
            return targetorder;
            //return orderList.Where(n => n.Id == orderId).ToList();
        }

        //通过客户名字来查询
        public List<Order> Querybycustomername(string customerName)
        {
            return OrderList.Where(order => order.Customer.Name == customerName).ToList();
        }

        //通过货物名称来查询
        public List<Order> Querybygoodsname(string goodsName)
        {
            return OrderList.Where(order => order.Details.Where(d => d.Goods.Name == goodsName).Count() > 0).ToList();
        }

        //通过订单金额来查询
        public List<Order> Querybymoney(double money)
        {
            return OrderList.Where(order => order.Money > money).ToList();
        }

        //序列化
        /*public void Export()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("orderlist.xml", FileMode.Create))
            {
                xmlser.Serialize(fs, OrderList);
            }
        }*/
        public void Export(XmlSerializer xmlser,string fileName)
        {
            FileStream fs = new FileStream(fileName , FileMode.Create);
            xmlser.Serialize(fs, OrderList);
            fs.Close();
            string xml = File.ReadAllText(fileName);
            Console.WriteLine(xml);
        }

        //反序列化
        public void Import(XmlSerializer xmlser, string fileName)
        {
            using (FileStream fs=new FileStream(fileName , FileMode.Open))
            {
                List<Order> orders = (List<Order>)xmlser.Deserialize(fs);
                orders.ForEach(or => Console.WriteLine(or.ToString()));
            }
        }
    }
}
