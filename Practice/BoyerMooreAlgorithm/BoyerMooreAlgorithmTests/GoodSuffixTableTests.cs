using ApprovalTests;
using ApprovalTests.Reporters;
using BoyerMooreAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoyerMooreAlgorithmTests
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class GoodSuffixTableTests
    {
        [TestMethod]
        public void B00001()
        {
            GoodSuffixTableTest("00001");
        }

        [TestMethod]
        public void B01010()
        {
            GoodSuffixTableTest("01010");
        }

        [TestMethod]
        public void B10000()
        {
            GoodSuffixTableTest("10000");
        }

        [TestMethod]
        public void BAOBAB()
        {
            GoodSuffixTableTest("BAOBAB");
        }

        [TestMethod]
        public void Case1()
        {
            GoodSuffixTableTest("ABABAB");
        }

        [TestMethod]
        [UseReporter(typeof(TortoiseDiffReporter))]
        public void Case2()
        {
            GoodSuffixTableTest("XBABAB");
        }

        [TestMethod]
        public void Case3()
        {
            GoodSuffixTableTest("ABCBAB");
        }

        private static void GoodSuffixTableTest(string pattern)
        {
            Approvals.VerifyAll(Program.GoodSuffixTable(pattern));
        }
    }
}