using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMTranslator
{
    public class CodeWriter
    {
        StreamWriter _sw;

        public CodeWriter(Stream s)
        {
            _sw = new StreamWriter(s);
        }
    }
}
