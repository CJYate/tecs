using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM
{
    public enum MemorySegment
    {
        nullSegment,
        argumentSegment,
        localSegment,
        staticSegment,
        constantSegment,
        thisSegment,
        thatSegment,
        pointerSegment,
        tempSegment
    }
}
