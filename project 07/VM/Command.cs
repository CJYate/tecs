using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM
{
    public abstract class Command
    {
        static string _name;

        public static string Name
        {
            get { return _name; }
        }

        CommandType _type;

        public Type Type
        {
            get { return _type.GetType(); }
        }

        protected Command(string name, CommandType type)
        {
            _name = name;
            _type = type;            
        }

        public abstract string Assembly();
    }
}
