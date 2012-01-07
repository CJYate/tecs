using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMTranslator
{
    public class Parser
    {
        StreamReader _sr;

        public Parser(Stream s)
        {
            _sr = new StreamReader(s);
        }

        public void Parse()
        {
            throw new NotImplementedException();
        }
    }
}
