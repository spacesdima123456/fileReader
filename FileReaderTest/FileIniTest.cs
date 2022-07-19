using FileReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileReaderTest
{
    [TestClass]
    public class FileIniTest
    {
        private  string[] _args = new[] { "file.ini" };

        [TestMethod]
        public void CheckInputParamEmpty()
        {
            try
            {
                Program.Main(_args);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Argument exception: " + ex.ParamName);
            }
        }
    }
}
