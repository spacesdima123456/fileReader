using FileReader;
using FileReader.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace FileReaderTest
{
    [TestClass]
    public class FileIniTests
    {
        private string path = "../../../file.ini";
        private readonly TestIniObj _testIniObj;

        public FileIniTests()
        {
            var iniFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
            _testIniObj = Program.ToObjIniFile<TestIniObj>(lines: Program.ReadIniFile(iniFile));
        }

        [TestMethod]
        public void DecTest()
        {
            Assert.AreEqual(expected: 10, actual: _testIniObj.TestInt);
        }

        [TestMethod]
        public void BoolTest()
        {
            Assert.AreEqual(expected: true, actual: _testIniObj.TestBool);
        }


        [TestMethod]
        public void CheckInputParamEmpty()
        {
            try
            {
                Program.Main(new string[] { path });
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Argument exception: " + ex.ParamName);
            }
        }
    }
}
