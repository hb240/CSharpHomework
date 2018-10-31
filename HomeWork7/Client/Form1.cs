using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public List<Order> orders = new List<Order>();
        public List<OrderDetail> orderDetails = new List<OrderDetail>();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();

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
            order1.AddDetails(orderDetails6);
            order1.AddDetails(orderDetails7);
            order2.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails5);
            order3.AddDetails(orderDetails6);

            OrderService client = new OrderService();
            client.Addorder(order1);
            client.Addorder(order2);
            client.Addorder(order3);
            
            orders = client.OrderList;
            orderBindingSource.DataSource = orders;
            //绑定查询条件
            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }

        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orders.Where(n => n.Id == uint.Parse(KeyWord));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }
    }
}
