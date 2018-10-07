using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    //订单类
    public class Order
    {
        private string order_number;//订单编号
        private string customer;//客户名字

        public  Order(string order_num,string cus_name)
        {
            this.order_number = order_num;
            this.customer = cus_name;
        }

        public string Asa { get; set; }
    }

    //订单细节类
    public class OrderDetails
    {
        private string goods_name;//商品名
        private int goods_number;//商品数量
        private double goods_price;//商品价格

        //构造方法
        public OrderDetails(string cus_goods_name,int cus_goods_num)
        {
            this.goods_name = cus_goods_name;
            this.goods_number = cus_goods_num;

            if (goods_name == "方便面")
                this.goods_price = 5;
            else if (goods_name == "矿泉水")
                this.goods_price = 2;
            else if (goods_name == "面包")
                this.goods_price = 4.5;
            else if (goods_name == "脉动")
                this.goods_price = 4;
            else if (goods_name == "纸巾")
                this.goods_price = 2;
            else if (goods_name == "薯片")
                this.goods_price = 3.8;
            else if (goods_name == "饼干")
                this.goods_price = 3;
            else if (goods_name == "苹果")
                this.goods_price = 2;
        }

        //显示详细信息
        public void Showdetails()
        {
            Console.WriteLine("商品名称：" + this.goods_name + "\t" + "数量：" + this.goods_number + "\t" + "单价：" + this.goods_price);
        }

    }

    //订单服务类
    public class OrderService
    {
        public static List<OrderDetails>cus_order = new List<OrderDetails>();

    }

    class Client
    {
        public static int itemnum = OrderService.cus_order.Count;

        static void Main(string[] args)
        {
            Console.WriteLine("订单管理");
            start: Console.WriteLine("请选择：1、添加订单 2、删除订单 3、修改订单 4、查询订单");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1://添加订单
                    {
                        Console.WriteLine("请输入商品名及数量（结束输入请换行输入ok）：");
                        Console.WriteLine("例：薯片 2");//多行输入，给用户一个例子，输入ok后结束订单输入
                        
                        List<string[]> str = new List<string[]>();
                        int len = 0;
                        while (true)
                        {
                            string[] input = Console.ReadLine().Split();//input[]里包含一行的数据，input[0]为名称，input[1]为数量
                            if (input[0].Equals("ok") == false)
                                str.Insert(len++, input);
                            else
                                break;
                        }
                        
                        //一行一个条目，逐条入列
                        for(int i = 0;i <len; i++)
                        {
                            OrderDetails item = new OrderDetails(str[i][0], int.Parse(str[i][1]));
                            OrderService.cus_order.Add(item);                                            //条目入列
                        }

                        OrderService.cus_order[0].Showdetails();
                        break;
                    }
                case 2://删除订单
                    {

                        break;
                    }
                case 3://修改订单
                    {
                        Console.WriteLine(OrderService.cus_order.Count+"\n");
                        break;
                    }
                case 4://查询订单
                    {
                        Console.WriteLine("请输入商品名称：");
                        string[] search_goods_name = new string[itemnum];
                        string searchinput = Console.ReadLine();
                        break;
                    }
                default:Console.WriteLine("请输入正确的数字！"); break;
            }
            goto start;
            Console.ReadLine();
        }
    }
}
