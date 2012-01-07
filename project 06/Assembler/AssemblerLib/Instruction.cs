using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerLib
{
    internal interface Instruction
    {
        string Encode();
    }
}
