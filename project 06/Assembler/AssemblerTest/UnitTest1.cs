using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AssemblerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblerTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AssemblerTests
    {        

        [TestMethod]
        public void CInstruction()
        {
            string inst = "MD=A-1;JGE";            
            var inStream = StreamHelpers.CreateStream(inst);
            var outStream = new MemoryStream();

            Assembler.Assemble(inStream, outStream);
            string contents = StreamHelpers.GetSingleLine(outStream);

            Assert.AreEqual("1110110010011011", contents);            
        }

        [TestMethod]
        public void AInstruction()
        {
            string inst = "@12345";

            var inStream = StreamHelpers.CreateStream(inst);
            var outStream = new MemoryStream();

            Assembler.Assemble(inStream, outStream);

            string contents = StreamHelpers.GetSingleLine(outStream);
            Assert.AreEqual("0011000000111001", contents);

        }



        [TestMethod]
        public void Comment()
        {
            string inst = "// this is a comment";

            try
            {
                var inStream = StreamHelpers.CreateStream(inst);
                var outStream = new MemoryStream();

                Assembler.Assemble(inStream, outStream);
            }
            catch (System.FormatException fe)
            {
                Assert.Fail();
            }
        }



        [TestMethod]
        public void Empty()
        {
            string inst = "";

            try
            {
                var inStream = StreamHelpers.CreateStream(inst);
                var outStream = new MemoryStream();

                Assembler.Assemble(inStream, outStream);
            }
            catch (System.FormatException fe)
            {
                Assert.Fail();
            }
        }


    }
}
