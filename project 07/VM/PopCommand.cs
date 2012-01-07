using System;
using System.Text;

namespace VM
{
    public class PopCommand : MemoryCommand
    {
        public PopCommand(MemorySegment segment, int index)
            : base("pop", segment, index)
        {
        }

        public override string Assembly()
        {
            throw new NotImplementedException();
            
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
            // THIS IS PUSH
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
