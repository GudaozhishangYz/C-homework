using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactory fac = new SimpleFactory();
            TapeStore store = new TapeStore(fac);
            store.OrderTape("circle");
            store.OrderTape("square");
            Console.ReadLine();
        }
    }
}
