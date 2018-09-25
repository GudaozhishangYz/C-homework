using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class Rectangle : Tape
    {
        public override void Get()
        {
            Console.WriteLine("This is a rectangle.");
        }
        public override void Getarea()
        {
            Console.WriteLine("area=a * b ");
        }
    }
}
