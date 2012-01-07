using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || !args[0].EndsWith(".vm"))
            {
                Console.WriteLine("Usage: VMTranslator <file>.vm");
                return;
            }

            string inputFile = args[0];            
            string outputFile = Path.ChangeExtension(inputFile, "hack");
            var parser = new Parser(new FileStream(inputFile, FileMode.Open));
            var writer = new CodeWriter(new FileStream(outputFile, FileMode.Create));
        }
    }
}
