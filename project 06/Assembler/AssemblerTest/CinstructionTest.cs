using System.IO;
using System.Collections.Generic;
using AssemblerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblerTest
{        
    /// <summary>
    ///This is a test class for CinstructionTest and is intended
    ///to contain all CinstructionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CinstructionTest
    {
        /// <summary>
        ///A test for ParseComp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseCompTestInvalid()
        {
            try
            {
                Cinstruction_Accessor.ParseComp("abcd");
                Assert.Fail();
            }
            catch (System.FormatException fe)
            {
            }
        }

        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseComp()
        {
            foreach (var val in Cinstruction_Accessor._compCodes)
            {
                string contents = Cinstruction_Accessor.ParseComp(val.Key);
                Assert.AreEqual(val.Value, contents);
            }
        }


        int ToInt(string binary)
        {
            int acc = 0;
            for (int i = binary.Length - 1, j = 1; i >= 0; --i, j*=2)
            {
                acc += (binary[i] == '1') ? j : 0;
            }
            return acc;
        }

        /// <summary>
        ///A test for ParseDest
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseDestTest()
        {
            int Mbit = 1;
            int Dbit = 2;
            int Abit = 4;

            Assert.AreEqual(Mbit, ToInt(Cinstruction_Accessor.ParseDest("M")));
            Assert.AreEqual(Dbit, ToInt(Cinstruction_Accessor.ParseDest("D")));
            Assert.AreEqual(Abit, ToInt(Cinstruction_Accessor.ParseDest("A")));            
        }

        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseJumpInvalidLongVal()
        {
            try
            {
                Cinstruction_Accessor.ParseJump("abcd");
                Assert.Fail();
            }
            catch (System.FormatException fe)
            {
            }
        }
        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseJumpInvalidShortVal()
        {
        
            try
            {
                Cinstruction_Accessor.ParseJump("ab");
                Assert.Fail();
            }
            catch (System.FormatException fe)
            {
            }
        }

        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseDestInvalidLong()
        {
            try
            {
                Cinstruction_Accessor.ParseDest("ADDAM");
                Assert.Fail();
            }
            catch (System.FormatException fe)
            {
            }
        }

        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseDestInvalidValLowercase()
        {
            try
            {
                Cinstruction_Accessor.ParseDest("mda");
                Assert.Fail();
            }
            catch (System.FormatException fe)
            {
            }
        }

        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseDestInvalidVal()
        {        
            try
            {
                Cinstruction_Accessor.ParseDest("abc");
                Assert.Fail();
            }
            catch(System.FormatException fe)
            {
            }
        }

        [TestMethod()]
        [DeploymentItem("AssemblerLib.dll")]
        public void ParseJump()
        {
            foreach (var val in Cinstruction_Accessor._jumpCodes)
            {                
                string contents = Cinstruction_Accessor.ParseJump(val.Key);
                Assert.AreEqual(val.Value, contents);
            }
       }
    
    }
}
