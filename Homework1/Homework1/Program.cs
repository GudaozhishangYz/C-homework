using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s, n;
            int num1, num2;
            s = Console.ReadLine();
            num1 = Int32.Parse(s);
            n = Console.ReadLine();
            num2 = Int32.Parse(n);

            Console.WriteLine("num1*num2=" + num1 * num2);
            Console.ReadLine();
        }
    }
}
