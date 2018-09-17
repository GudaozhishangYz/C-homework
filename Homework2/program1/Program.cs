using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a number:");
            String s = Console.ReadLine();
            int n = Int32.Parse(s);
            Console.WriteLine("the prime factors are:");
            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                {
                    int x = 0;
                    for (int j = 1; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            x++;
                        }
                    }
                    if (x < 2) 
                    {
                        Console.WriteLine(i+"\t");
                    }
                    n = n / i;
                    i = 1;
                }
            }
            Console.ReadLine();
        }
    }
    
}
