using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_number_factor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数:");
            int num = Int32.Parse(Console.ReadLine());               //得到用户输入的数据
            int[] factor = new int[num];                             //因子数组
            int[] prime_factor = new int[num];                       //素数因子数组
            bool[] is_prime = new bool[num];                         //是否为素数数组
            int j = 0, p = 0;
            for (int i = 0; i < num; i++)                            //初始化数组
                is_prime[i] = true;
            //先求出所有因子，不含1
            for (int i = 2; i <= num; i++)
                if (num % i == 0)
                {
                    factor[j++] = i;
                }
            //挑选出素数因子
            int max = j-1;                                          //记录因子个数
            for (j = 0; j <= max; j++)
            {
                for (int k = 2; k < factor[j]; k++)                 //for循环
                {
                    if (factor[j] % k == 0)
                    {
                        is_prime[j] = false;
                        break;                                      //可整除就不是素数，跳出for循环
                    }
                }
                if (is_prime[j])                                    //将素数填入素数因子数组
                    prime_factor[p++] = factor[j];
            }
            //输出所有的素数因子
            Console.WriteLine(num + "的所有素数因子如下：");
            for (int i = 0; i < p; i++)
                Console.WriteLine(prime_factor[i]);
            Console.ReadLine();
        }
    }
}
