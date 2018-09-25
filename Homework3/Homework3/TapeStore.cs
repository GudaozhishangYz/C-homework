using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class TapeStore
    {
        SimpleFactory _factory;
        public TapeStore(SimpleFactory factory)
        {
            this._factory = factory;
        }
        public Tape OrderTape(String tapeType)
        {
            Tape tape;
            tape = _factory.CreateTape(tapeType);
            tape.Get();
            tape.Getarea();

            return tape;
        }
    }
}
