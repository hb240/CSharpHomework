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
        public string Order_num { get; set; }//订单编号
        public string Cus_name { get; set; }//客户名字

    }

    //订单细节类
    public class OrderDetails : Order
    {
        public string goods_name;//商品名
        private int goods_number;//商品数量
        private double goods_price;//商品价格

        //构造方法
        public OrderDetails(string cus_goods_name,int cus_goods_num, string order_num,string cus_name)
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

            this.Order_num = order_num;
            this.Cus_name = cus_name;
        }

        //显示详细信息
        public void Showdetails()
        {
            Console.WriteLine("客户："+this.Cus_name+"订单编号："+this.Order_num+"商品：" + this.goods_name + "\t" + "数量：" + this.goods_number + "\t" + "单价：" + this.goods_price);
        }
        
    }

    //订单服务类
    public class OrderService
    {
        public static List<OrderDetails>cus_order = new List<OrderDetails>();

    }

    //异常处理类
    public class MyAppException : ApplicationException
    {
        private int idnumber;
        public MyAppException(string message,int id) : base(message)
        {
            this.idnumber = id;
        }

        public int GetId()
        {
            return idnumber;
        }
    }

    //客户端
    class Client
    {
        //异常处理1
        public static void Test1(bool iscontain)
        {
            if (iscontain == false)
            {
                throw new MyAppException("不存在该订单！", 1);
            }
        }
        public static void Test2(int num)
        {
            if (num < 0)
            {
                throw new MyAppException("商品数量必须为正整数", 2);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("订单管理");
            start: Console.WriteLine("请选择：1、添加订单 2、删除订单 3、修改订单 4、查询订单");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1://添加订单
                    {
                        List<string[]> str = new List<string[]>();
                        int len = 0;
                        string name;  //客户名
                        string number;//订单编号：自动生成

                        //多行输入，给用户一个例子，输入ok后结束订单输入
                        Console.WriteLine("请输入要购买的商品名及数量（结束输入请换行输入ok）：");
                        Console.WriteLine("例：薯片 2");
                        
                        while (true)
                        {
                            string[] input = Console.ReadLine().Split();//input[]里包含一行的数据，input[0]为名称，input[1]为数量
                            if (input[0].Equals("ok") == false)
                                str.Insert(len++, input);
                            else
                                break;
                        }

                        Console.WriteLine("请输入你的名字：");//获取客户名
                        name = Console.ReadLine();

                        number = System.DateTime.Now.ToString("yyyyMMddHHmmss");//根据下单时间生成订单号
                        Console.WriteLine("尊敬的" + name + "，你的订单编号为：" + number);
                        //一行一个条目，逐条入列
                        for (int i = 0;i <len; i++)
                        {
                            OrderDetails item = new OrderDetails(str[i][0], int.Parse(str[i][1]),number,name);
                            OrderService.cus_order.Add(item);//条目入列
                        }
                        
                        break;
                    }
                case 2://删除订单
                    {
                        Console.WriteLine("请输入你的姓名：");
                        string deleteinput = Console.ReadLine();

                        bool is_contain = OrderService.cus_order.Exists(x => x.Cus_name == deleteinput);
                        try
                        {
                            Test1(is_contain);
                        }catch(MyAppException e)
                        {
                            Console.WriteLine("出现异常：{0}",e.Message);
                        }

                        for (int i = 0;i<OrderService.cus_order.Count;i++)
                        {
                            OrderDetails x = OrderService.cus_order[i];

                            if (x.Cus_name == deleteinput)
                            {
                                OrderService.cus_order.Remove(x);
                                i--;
                            }
                        }
                        
                        break;
                    }
                case 3://修改订单
                    {
                        Console.WriteLine("请选择：1、删除某一商品 2、修改某一商品");

                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1://删除某订单的某一条目
                                {
                                    Console.WriteLine("请输入你的名字及商品名：");
                                    string[] name_goods = Console.ReadLine().Split();
                                    
                                    for (int i = 0; i < OrderService.cus_order.Count; i++)
                                    {
                                        OrderDetails x = OrderService.cus_order[i];

                                        if (x.Cus_name == name_goods[0] && x.goods_name == name_goods[1])
                                        {
                                            OrderService.cus_order.Remove(x);
                                            i--;
                                        }
                                    }

                                    break;
                                }
                            case 2://修改某订单的某一条目
                                {
                                    Console.WriteLine("请输入你的名字、商品名及修改后的数量：");
                                    string[] input = Console.ReadLine().Split();
                                    string order_num = OrderService.cus_order.FirstOrDefault(x => x.Cus_name == input[0]).Order_num;

                                    for (int i = 0; i < OrderService.cus_order.Count; i++)
                                    {
                                        OrderDetails x = OrderService.cus_order[i];

                                        if (x.Cus_name == input[0] && x.goods_name == input[1])
                                        {
                                            OrderService.cus_order.Remove(x);
                                            i--;
                                        }
                                    }

                                    try
                                    {
                                        Test2(int.Parse(input[2]));
                                    }
                                    catch (MyAppException e)
                                    {
                                        Console.WriteLine("出现异常：{0}", e.Message);
                                    }

                                    OrderDetails item = new OrderDetails(input[1], int.Parse(input[2]), order_num, input[0]);
                                    OrderService.cus_order.Add(item);
                                    break;
                                }
                            
                        }

                        break;
                    }
                case 4://查询订单
                    {
                        Console.WriteLine("查询：1、订单号 2、商品名称 3、客户名");

                        switch(int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                {
                                    Console.WriteLine("请输入要查询的订单号：");
                                    string searchinput = Console.ReadLine();
                                    foreach(var x in OrderService.cus_order)
                                    {
                                        if (x.Order_num == searchinput)
                                        {
                                            x.Showdetails();
                                        }
                                    }
                                    
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("请输入要查询的商品名称：");
                                    string searchinput = Console.ReadLine();

                                    foreach (var x in OrderService.cus_order)
                                    {
                                        if (x.goods_name == searchinput)
                                        {
                                            x.Showdetails();
                                        }
                                    }

                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("请输入要查询的客户名：");
                                    string searchinput = Console.ReadLine();

                                    foreach (var x in OrderService.cus_order)
                                    {
                                        if (x.Cus_name == searchinput)
                                        {
                                            x.Showdetails();
                                        }
                                    }

                                    break;
                                }
                        }

                        break;
                    }
                default:Console.WriteLine("请输入正确的数字！"); break;
            }
            goto start;
        }
    }
}
