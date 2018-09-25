using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class SimpleFactory
    {
        public Tape CreateTape(string tapeType)
        {
            Tape tape = null;
            if (tapeType.Equals("triangle"))
            {
                tape = new Triangle();
            }
            else if (tapeType.Equals("circle"))
            {
                tape = new Circle();
            }
            else if (tapeType.Equals("rectangle"))
            {
                tape = new Rectangle();
            }
            else if (tapeType.Equals("square"))
            {
                tape = new Square();
            }

            return tape;
        }

    }
}
