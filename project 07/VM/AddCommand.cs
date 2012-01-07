using System.Text;
namespace VM
{
    public class AddCommand : ArithmeticCommand
    {
        public AddCommand()
            : base("add")
        { }

        public override string Assembly()
        {
            var sb = new StringBuilder();

            sb.AppendLine("@SP");
            sb.AppendLine("@D=A");
            sb.AppendLine("A=A+1");
            sb.AppendLine("A=A+D");
            sb.AppendLine("A=M");
            sb.AppendLine("M=D");
            sb.AppendLine("@SP");
            sb.AppendLine("M=M+1");

            return sb.ToString();
        }
    }
}
