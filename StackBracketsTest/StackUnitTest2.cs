
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Применение_стеков;

namespace StackBracketsTest
{
    class StackUnitTest2
    {
        // Тестирование вычисления польской записи
        [TestClass]
        public class UnitTest2
        {
            private void Test2(int result, string str)
            {
                Assert.AreEqual(result, ReversePolishNotation.Compute(str));
            }

            private void Test3(int result, string str)
            {
                Assert.AreEqual(result, ReversePolishNotation.Compute1(str));
            }

            [TestMethod]
            public void SimpleTest()
            {
                Test2(25, "23+5*");
                Test3(25, "23+5*");
            }
        }
    }
}
