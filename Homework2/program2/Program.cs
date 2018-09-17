using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the length of this array:");
            String x = Console.ReadLine();
            int n = Int32.Parse(x);
            double[] a = new double[n];
            double sum  = 0;
            Console.WriteLine("Please input the element:");
            for (int i = 0; i < n; i++)
            {
                String s = Console.ReadLine();
                a[i] = Double.Parse(s);
                sum = sum + a[i];
            }
            double max = a[0];
            double min = a[0];
            for (int i = 0; i < n; i++)
            {
                if (max < a[i])
                {
                    max = a[i];
                }
                if (min > a[i])
                {
                    min = a[i];
                }
            }
            Console.WriteLine("the max of this array is:"+ max);
            Console.WriteLine("the min of this array is:"+ min);
            Console.WriteLine("the sum of this array is:"+ sum);
            Console.WriteLine("the mean of this array is:" + (sum / n));
            Console.ReadLine();
        }
    }
}
