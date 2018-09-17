using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[100];
            int n = 2;
            for (int i = 0; i < 99; i++)
            {
                num[i] = n;
                n++;
            }
            for (int i = 0; i < 100; i++)
            {
                for (int j = 2; j < 101; j++)
                {
                    if (num[i] % j == 0 && num[i] / j > 1)
                    {
                        num[i] = 0;
                        continue;
                    }
                }
            }
            for (int i = 0; i < 100; i++)
            {
                if (num[i] != 0)
                {
                    Console.WriteLine(num[i]);
                }
            }
            Console.ReadLine();
        }
    }
}
