using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerLib
{
    public static class Assembler
    {
        static Dictionary<string, int> symbols;

        static void SetupPredefinedSymbols()
        {
            symbols = new Dictionary<string, int>();
            symbols.Add("SP", 0);
            symbols.Add("LCL", 1);
            symbols.Add("ARG", 2);
            symbols.Add("THIS", 3);
            symbols.Add("THAT", 4);
            symbols.Add("R0", 0);
            symbols.Add("R1", 1);
            symbols.Add("R2", 2);
            symbols.Add("R3", 3);
            symbols.Add("R4", 4);
            symbols.Add("R5", 5);
            symbols.Add("R6", 6);
            symbols.Add("R7", 7);
            symbols.Add("R8", 8);
            symbols.Add("R9", 9);
            symbols.Add("R10", 10);
            symbols.Add("R11", 11);
            symbols.Add("R12", 12);
            symbols.Add("R13", 13);
            symbols.Add("R14", 14);
            symbols.Add("R15", 15);
            symbols.Add("SCREEN", 16384);
            symbols.Add("KEYB", 24576);
        }

        static Assembler()
        {
            SetupPredefinedSymbols();
        }

        static List<Instruction> GetInstructions(List<string> lines)
        {
            var instructions = new List<Instruction>();
            //var _predefSymbols = new Dictionary<string, int>();
            int lineNo = 0;
            // second pass
            foreach (var line in lines)
            {
                if (line.StartsWith("(") && line.EndsWith(")"))
                {
                    // a symbol
                    symbols.Add(line.Substring(1, line.Length - 2), lineNo);
                    // continue; don't increment the line number (this is a label, not an instruction)!
                    continue;
                }
                
                ++lineNo;
            }

            // second pass
            int variableNo = 16;

            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    continue;
                }
                if (line.StartsWith("(") && line.EndsWith(")"))
                {
                    continue;
                }
                if (line.StartsWith("@"))
                {
                    string valueString = line.Substring(1);
                    try
                    {
                        System.Convert.ToInt32(valueString);
                    }
                    catch (System.FormatException)
                    {
                        // string!
                        if (!symbols.ContainsKey(valueString))
                        {
                            // a symbol
                            symbols.Add(valueString, variableNo);
                            ++variableNo;
                            // continue; don't increment the line number (this is a label, not an instruction)!                                
                        }
                    }

                    instructions.Add(Ainstruction.Parse(line, symbols));
                }
                else
                {
                    instructions.Add(Cinstruction.Parse(line));
                }
            }

            return instructions;
        }

        static List<string> ReadLines(Stream input)
        {
            var linesTemp = new List<string>();
            using (var sr = new StreamReader(input))
            {
                string line = sr.ReadLine();
                linesTemp.Add(line);
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    linesTemp.Add(line);
                }
            }

            var lines = new List<string>();
            foreach (var l in linesTemp)
            {
                string temp = l;
                if (temp.Contains("//"))
                {
                    temp = temp.Substring(0, temp.IndexOf("//"));
                }
                temp = temp.Trim();
                if (temp != string.Empty)
                {
                    lines.Add(temp);
                }
            }
            return lines;
        }

        public static void Assemble(Stream input, Stream output)
        {
            var instructions = GetInstructions(ReadLines(input));

            using (var sw = new StreamWriter(output))
            {
                foreach (var i in instructions)
                {
                    sw.WriteLine(i.Encode());
                }
            }
        }
    }
}

