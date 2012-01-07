using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblerLib;

namespace Assemble
{
    class Program
    {
        static void Usage()
        {
            Console.WriteLine("Usage:\nAssemble <file.asm>\n\n");
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Usage();
                Environment.Exit(1);
            }
            if (!args[0].EndsWith(".asm"))
            {
                Usage();
                Environment.Exit(1);
            }

            try
            {
                string inputFile = args[0];
                string outputFile = System.IO.Path.ChangeExtension(inputFile, ".hack");

                var inStream = new FileStream(inputFile, FileMode.Open);
                var outStream = new FileStream(outputFile, FileMode.Create);

                Assembler.Assemble(inStream, outStream);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
