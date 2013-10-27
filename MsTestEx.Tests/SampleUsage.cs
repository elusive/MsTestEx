using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestEx.Tests
{
    /// <summary>
    /// Normal test class
    /// </summary>
    [TestClass]
    public class NormalTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(2 == 2);
        }
    }

    [TestClassEx]
    public class SampleUsage
    {
        [TestMethod]
        [TestCase(1, 1, 2)]
        [TestCase(1, -1, 0)]
        [TestCase(2, 2, 4)]
        public void TestParameterizedAdd(int value1, int value2, int expected)
        {
            var actual = value1 + value2;

            Assert.AreEqual(expected, actual);
        }
    }

}
