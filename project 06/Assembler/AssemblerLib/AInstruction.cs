using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblerLib
{
    internal struct Ainstruction : Instruction
    {        
        int _value;
        
        private Ainstruction(int value)
        {
            _value = value;
        }

        public string Encode()
        {
            return Convert.ToString(_value, 2).PadLeft(16, '0');
            
        }

        public static Instruction Parse(string input, Dictionary<string, int> symbols)
        {
            string value = input.Substring(1);
            
            if (symbols.ContainsKey(value))
            {
                return new Ainstruction(symbols[value]);
            }
            
            int val = Convert.ToInt16(value);
            return new Ainstruction(val);
        }
    }
}
