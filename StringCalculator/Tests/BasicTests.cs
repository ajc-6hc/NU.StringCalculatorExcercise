using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class BasicTests
    {
        Calculator calculator;

        string emptyString;
        string oneIntegerString;
        string twoIntegerString;
        string tenIntegerString;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
            emptyString = "";
            oneIntegerString = "7";
            twoIntegerString = "6,5";
            tenIntegerString = "1,2,3,4,5,6,7,8,9,10";
        }

        [Test]
        public void TestEmptyString()
        {
            Assert.AreEqual(0, calculator.Add(emptyString));
        }

        [Test]
        public void TestOneIntegerString()
        {
            Assert.AreEqual(7, calculator.Add(oneIntegerString));
        }

        [Test]
        public void TestTwoIntegerString()
        {
            Assert.AreEqual(11, calculator.Add(twoIntegerString));
        }

        [Test]
        public void TestTenIntegerString()
        {
            Assert.AreEqual(55, calculator.Add(tenIntegerString));
        }
    }
}
