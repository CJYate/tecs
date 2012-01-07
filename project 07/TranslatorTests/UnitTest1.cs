using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM;

namespace TranslatorTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUninitialisedMemoryCommand()
        {
            MemoryCommand c = new PushCommand();
            try
            {
                string s = c.Assembly(MemorySegment.nullSegment, 0);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual(ae.Message, "Segment not initialised!");
            }
        }

        string ExpectedPush8()
        {
            return "@8\r\n" +
             "D=A\r\n" +
             "@SP\r\n" +
             "A=M\r\n" +
             "M=D\r\n" +
             "@SP\r\n" +
             "M=M+1\r\n";
        }

        [TestMethod]
        public void TestCommandPush()
        {
            Command c = Commands.Get("push");

            MemoryCommand mc = c as MemoryCommand;
            Assert.IsNotNull(mc, "Mc should not be null");

            string expected = ExpectedPush8();
            string actual = mc.Assembly(MemorySegment.constantSegment, 8);
            Assert.AreEqual(expected, actual);

            /* push <segment> <value>  (segment = constant === @<value>)
             * 
             * push constant xxx
             * =>
             * @xxx
             * D=A
             * @SP
             * A=M
             * M=D
             * @SP
             * M=M+1
             * 
             * push segment index
             * =>
             * @segment
             * D=A
             * @index
             * D=D+A
             * @SP
             * A=M
             * M=D
             * @SP
             * M=M+1
             */
        }

        [TestMethod]
        public void TestCommandAdd()
        {
            Command c = Commands.Get("add");
            Assert.IsTrue(c is ArithmeticCommand);
            ArithmeticCommand ac = c as ArithmeticCommand;
            Assert.AreEqual(ac.Assembly(), "bum");
        }
    }
}
