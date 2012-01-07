using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM
{
    public abstract class ArithmeticCommand : Command
    {
        protected ArithmeticCommand(string name)
            : base(name, CommandType.Arithmetic)
        { }
    }
}
