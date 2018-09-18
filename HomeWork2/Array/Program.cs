using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array= {2,45,4,7,9,-99,6,78,56,12,488,456,-4,-61,-45 };       //定义并初始化数组
            int max, min, average, sum = 0;                                     //定义数组的最大值，最小值，平均值，和
            min = max = array[0];                                               //给最大最小值赋初值
            //用for循环求最大最小值以及和
            /*
             * min = array.Min();
             * max = array.Max();
             */
            for (int i=0; i<14;i++)
            {
                if (min > array[i + 1])
                    min = array[i + 1];
                if (max < array[i + 1])
                    max = array[i + 1];
                sum += array[i];                                                //求和
            }
            average = sum / 15;                                                 //求平均值
            //输出
            Console.WriteLine("最大值：" + max +"\n"+ "最小值：" + min + "\n" + "平均值：" + average + "\n" + "和:" + sum);
            Console.ReadLine();
        }
    }
}
