using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HomeWork4
{
    //定义一个委托，申明事件处理函数的格式
    public delegate void ElapsedEventHandler(object source, ElapsedEventArgs e);

    public class ElapsedEventArgs : EventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
    }

    public class Alarm
    {
        //定义事件，相当于委托实例，初值为null
        public event ElapsedEventHandler TimeOut;

        public void Time(int hour,int minute)
        {
            //触发闹钟事件，即闹钟响起
            ElapsedEventArgs args = new ElapsedEventArgs();
            args.Hour = hour;
            args.Minute = minute;
            while (!(args.Hour == DateTime.Now.Hour) || !(args.Minute == DateTime.Now.Minute)) { }//时间不到不往下执行
            TimeOut(this, args);
        }
    }

    class Program
    {
        private static Timer aTimer;
        private static int alhour;
        private static int alminute;

        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();

            alarm.TimeOut += new ElapsedEventHandler(OnTimedEvent);//添加第一个委托实例

            Console.WriteLine("请输入闹钟时间（时，分）：");
            string timestring = Console.ReadLine();
            string[] times = timestring.Split();

            alhour = Int32.Parse(times[0]);
            alminute = Int32.Parse(times[1]);

            alarm.Time(alhour, alminute);

            Console.ReadLine();
        }
        
        //处理方法1：闹铃时间到，显示提示
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("时间已到！"+"\a");
        }
    }
}
