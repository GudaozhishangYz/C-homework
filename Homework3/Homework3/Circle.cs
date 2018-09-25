using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class Circle : Tape
    {
        public override void Get()
        {
            Console.WriteLine("This is a circle.");
        }
        public override void Getarea()
        {
            Console.WriteLine("area= pi * r^2 ");
        }
    }
}
