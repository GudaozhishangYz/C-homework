using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class Triangle : Tape
    {
        public override void Get()
        {
            Console.WriteLine("This is a triangle.");
        }
        public override void Getarea()
        {
            Console.WriteLine("area=s * h ");
        }
    }
}
