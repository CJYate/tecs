using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VM
{
    class CommandCollection : KeyedCollection<string, Type>
    {
        protected override string GetKeyForItem(Type item)
        {
            if(item.IsInstanceOfType(typeof(Command)))
            {
                //(item as Command).T
            }
            System.IO.Path.gett
            throw new ArgumentOutOfRangeException();
        }
    }

    public static class Commands
    {
        static CommandCollection _commands;

        static Commands()
        {
            _commands = new CommandCollection();

            _commands.Add(typeof(AddCommand));
            _commands.Add(typeof(PushCommand));
        }

        public static Type Get(string name)
        {
            return _commands[name];
        }
    }
}
