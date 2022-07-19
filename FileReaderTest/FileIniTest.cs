using FileReader;
using FileReader.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileReaderTest
{
    [TestClass]
    public class FileIniTest
    {
        private  string[] _args = new[] { "file.ini" };
        private TestIniObj _testIniObj = new TestIniObj();
        private TestIniObj _result = (TestIniObj)Program.MakeObject("file.ini" );

        [TestMethod]
        public void CheckInputParamInt()
        {
            Assert.AreNotEqual(_testIniObj.TestInt, _result.TestInt);
        }

        [TestMethod]
        public void CheckInputParamString()
        {
            Assert.AreNotEqual(_testIniObj.TestStr, _result.TestStr);
        }

        [TestMethod]
        public void CheckInputParamBool()
        {
            Assert.AreNotEqual(_testIniObj.TestBool, _result.TestBool);
        }
    }
}
