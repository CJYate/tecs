using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM
{
    public abstract class MemoryCommand : Command
    {
        MemorySegment _segment;

        protected MemorySegment Segment
        {
            get { return _segment; }
        //    set { _segment = value; }
        }

        int _index;

        protected int Index
        {
            get { return _index; }
        //    set { _index = value; }
        }

        protected MemoryCommand(string name, MemorySegment segment, int index) : 
            base(name, CommandType.Memory)
        {
            _segment = segment;
            _index = index;
        }
    } 
}
