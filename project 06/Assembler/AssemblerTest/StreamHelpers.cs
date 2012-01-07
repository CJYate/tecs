using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerTest
{
    internal class StreamHelpers
    {
        public static MemoryStream CreateStream(string input)
        {
            var streamSetup = new MemoryStream();
            using (var sw = new StreamWriter(streamSetup))
            {
                sw.WriteLine(input);
            }

            return new MemoryStream(streamSetup.GetBuffer());
        }

        public static string GetSingleLine(MemoryStream stream)
        {
            var streamRead = new MemoryStream(stream.GetBuffer());
            using (var sr = new StreamReader(streamRead))
            {
                string res = sr.ReadLine();
                return ( res == null ) ? string.Empty : res;
            }
        }        

    }
}
