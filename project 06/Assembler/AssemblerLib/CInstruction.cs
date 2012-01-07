using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerLib
{
    internal struct Cinstruction : Instruction
    {
        static Dictionary<string, string> _jumpCodes;
        static Dictionary<string, string> _compCodes;

        string _dest;
        string _comp;
        string _jump;

        public string Encode()
        {
            return string.Format("111{0}{1}{2}", _comp, _dest, _jump);
        }

        static void SetupCompCodes()
        {
            _compCodes = new Dictionary<string, string>();
            _compCodes["0"]  = "0101010";
            _compCodes["1"]  = "0111111";
            _compCodes["-1"] = "0111010";
            _compCodes["D"]  = "0001100";
            _compCodes["A"]  = "0110000";
            _compCodes["M"]  = "1110000";
            _compCodes["!D"] = "0001101";
            _compCodes["!A"] = "0110001";
            _compCodes["!M"] = "1110001";
            _compCodes["-D"] = "0001111";
            _compCodes["-A"] = "0110011";
            _compCodes["-M"] = "1110011";
            _compCodes["D+1"] = "0011111";
            _compCodes["A+1"] = "0110111";
            _compCodes["M+1"] = "1110111";
            _compCodes["D-1"] = "0001110";
            _compCodes["A-1"] = "0110010";
            _compCodes["M-1"] = "1110010";
            _compCodes["D+A"] = "0000010";
            _compCodes["D+M"] = "1000010";
            _compCodes["D-A"] = "0010011";
            _compCodes["D-M"] = "1010011";
            _compCodes["A-D"] = "0000111";
            _compCodes["M-D"] = "1000111";

            _compCodes["D&A"] = "0000000";
            _compCodes["D&M"] = "1000000";
            _compCodes["D|A"] = "0010101";
            _compCodes["D|M"] = "1010101";                    
            
        }

        static void SetupJumpCodes()
        {
            _jumpCodes = new Dictionary<string, string>();
            _jumpCodes[""] = "000";
            _jumpCodes["JGT"] = "001";
            _jumpCodes["JEQ"] = "010";
            _jumpCodes["JGE"] = "011";
            _jumpCodes["JLT"] = "100";
            _jumpCodes["JNE"] = "101";
            _jumpCodes["JLE"] = "110";
            _jumpCodes["JMP"] = "111";
        }
        
        static Cinstruction()
        {
            SetupCompCodes();
            SetupJumpCodes();
        }

        static string ParseJump(string input)
        {            
            if (!_jumpCodes.Keys.Contains(input))
            {
                throw new FormatException("Invalid jump specification!");
            }
            return _jumpCodes[input];
        }

        static string ParseDest(string input)
        {
            if (input != string.Empty && input.Length >= 3)
            {
                throw new FormatException("Input to ParseDest should be no longer than 3, or empty!");
            }

            int isM = input.Contains("M") ? 1 : 0;
            int isD = input.Contains("D") ? 1 : 0;
            int isA = input.Contains("A") ? 1 : 0;
            
            return string.Format("{0}{1}{2}", isA, isD, isM);
        }

        static string ParseComp(string input)
        {
            if (!_compCodes.Keys.Contains(input))
            {
                throw new FormatException("Invalid comp specification!");
            }
            return _compCodes[input];
        }

        static string GetInstruction(string input)
        {
            int eqPos = input.IndexOf('=');            
            // if = not found this takes substring from 0 (-1 + 1)
            string temp = input.Substring(eqPos + 1);
            int scPos = temp.IndexOf(';');
            if (scPos == -1)
            {
                // no semicolon! Just an instruction
                return temp;
            }
            return temp.Substring(0, scPos);
        }

        static string GetDestination(string input)
        {
            if (input.Contains('='))
            {
                string[] splitByEquals = input.Split('=');

                if (splitByEquals.Length > 2)
                {
                    throw new FormatException("too many ='s in input");
                }
                if (splitByEquals.Length == 2)
                {
                    // input has dest=comp
                    return splitByEquals[0];
                }
            }

            return "";
        }

        static string GetJump(string input)
        {
            if (input.Contains(';'))
            {
                string[] splitBySemicolon = input.Split(';');
                if (splitBySemicolon.Length > 2)
                {
                    throw new FormatException("too many ;'s in input");
                }
                if (splitBySemicolon.Length == 2)
                {
                    // the first part
                    return splitBySemicolon[1];
                }
            }
            return "";
        }

        public static Instruction Parse(string input)
        {
            var inst = new Cinstruction();            

            inst._comp = ParseComp(GetInstruction(input));
            inst._dest = ParseDest(GetDestination(input));
            inst._jump = ParseJump(GetJump(input));

            return inst;
        }
    }
}
