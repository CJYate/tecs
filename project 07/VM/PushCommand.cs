using System;
using System.Text;

namespace VM
{
    public class PushCommand : MemoryCommand
    {
        public PushCommand(MemorySegment segment, int index)
            : base("push", segment, index)
        {
        }

        public override string Assembly()
        {            
            if(Segment == MemorySegment.nullSegment)
            {
                throw new ArgumentException("Segment not initialised!");
            }

            var sb = new StringBuilder();
            if(Segment == MemorySegment.constantSegment)
            {
                sb.AppendLine(string.Format("@{0}", Index));
            }
            else
            {
                throw new NotImplementedException();
            }

            sb.AppendLine("D=A");
            sb.AppendLine("@SP");
            sb.AppendLine("A=M");
            sb.AppendLine("M=D");
            sb.AppendLine("@SP");
            sb.AppendLine("M=M+1");

            return sb.ToString();
        }
    }
}
