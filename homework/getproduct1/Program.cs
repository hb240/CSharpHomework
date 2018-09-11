using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getproduct1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个数：");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("乘积为：");
            Console.WriteLine(num1 * num2);                //输出乘积
            Console.ReadLine();                            //暂停
        }
    }
}
