using Microsoft.VisualStudio.TestTools.UnitTesting;
using Применение_стеков;

namespace StackBracketsTest
{
    //Текстирование анализа скобочных выражений,
    // реализованных с помощью стека
    [TestClass]
    public class StackUnitTest1
    {
        private void Test(string str, bool result)
        {
            Assert.AreEqual(result, BracketsAnalysis.IsCorrectStringDRYok(str));
        }

        [TestMethod]
        public void RightSequence()
        {
            Test("(([])([][]()))", true);
        }

        [TestMethod]
        public void TooMuchOpenBrackets()
        {
            Test("(()", false);
        }

        [TestMethod]
        public void TooMuchClosingBrackets()
        {
            Test("(())))", false);
        }

        [TestMethod]
        public void BracketsNotMatch()
        {
            Test("(]", false);
        }

        [TestMethod]
        public void EmptyString()
        {
            Test("", true);
        }

        [TestMethod]
        public void WrongSymbols()
        {
            Test("ab", false);
        }

        [TestMethod]
        public void DifferentSymbols()
        {
            Test("()<>{}[]", true);
        }

        
    }
}