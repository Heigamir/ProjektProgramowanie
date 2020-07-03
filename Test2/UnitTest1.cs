using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "Plik zapisany";
        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ProjektProgramowanie.Program.Main();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
    }
}
