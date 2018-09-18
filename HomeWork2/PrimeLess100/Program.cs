using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLess100
{
    class Program
    {
        public const int SIZE = 99;                                                  //常量SIZE=99，2-100共99个数
        static void Main(string[] args)
        {
            Console.WriteLine("####2-100之间的素数####");
            int num = 0;                                                            //素数个数
            int[] prime = new int[SIZE];                                            //定义素数数组
            bool[] is_prime = new bool[SIZE];                                       //定义是否为素数数组
            for (int n = 0; n < SIZE; n++)
                is_prime[n] = true;                                                 //初始化数组
            for(int i=2;i<=100;i++)
            {
                if (is_prime[i-2])
                {
                    prime[num] = i;                                                 //记录素数个数与素数
                    for (int j = 2 * i; j <= 100; j += i)
                        is_prime[j - 2] = false;                                    //埃氏筛选
                    num++;
                }
            }
            //输出2-100之间的素数
            for (int k = 0; k < num; k++)
                Console.WriteLine(prime[k]);
            Console.ReadLine();
        }
    }
}
