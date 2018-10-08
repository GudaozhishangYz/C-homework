using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework4
{
    public delegate void TimeHandler(object sender, TimeEventArgs args);

    public class TimeEventArgs : EventArgs
    {
    }

    public class MyClock
    {
        //定义事件，相当于申明一个委托实例，初值为null
        public event TimeHandler OnClock;

        public void Clock(int x, int y)
        {
            DateTime time = DateTime.Now;
            TimeSpan tm = TimeSpan.FromSeconds(1);
            TimeEventArgs args = new TimeEventArgs();
            while (time.Hour <= 24)  
            {
                Console.WriteLine(time);
                Thread.Sleep(1000);
                if (time.Hour == x && time.Minute == y)
                {
                    OnClock(this, args);
                }
                time = time + tm;
            }
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            MyClock clock = new MyClock();

            //为btn的OnClick事件添加两个处理方法
            clock.OnClock += new TimeHandler(clock_OnClock); //添加一个委托实例

            clock.Clock(22, 15);//模拟点击按钮
            Console.ReadLine();

        }

        static void clock_OnClock(object sender, TimeEventArgs args)
        {
            Console.WriteLine("Dinginging.....Dinginging.....");
            
        }

    }




}

