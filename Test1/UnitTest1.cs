using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "Plik wczytany";
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
