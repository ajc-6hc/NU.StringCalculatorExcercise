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
        string singleNewLineDelimiterList;
        string correctCombinationOfDelimitersList;
        string incorrectCombinationOfDelimitersList;
        string inputOfDelimiterList;
        string negativeIntegerIncludedList;
        string largeIntegerIncludedList;
        string inputOfMultipleCharDelimiterList;
        string inputOfMultipleDelimiterList;
        string inputOfMultiplecharMultipleDelimiterList;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
            emptyString = "";
            oneIntegerString = "7";
            twoIntegerString = "6,5";
            tenIntegerString = "1,2,3,4,5,6,7,8,9,10";
            singleNewLineDelimiterList = "1\n2";
            correctCombinationOfDelimitersList = "1\n2,3";
            incorrectCombinationOfDelimitersList = "1,\n";
            inputOfDelimiterList = "//[:]\n1,2\n3:4";
            negativeIntegerIncludedList = "1,2,-3,-4";
            largeIntegerIncludedList = "1,2,3,1001";
            inputOfMultipleCharDelimiterList = "//[***]\n1***2***3";
            inputOfMultipleDelimiterList = "//[:][*]\n1*2:3";
            inputOfMultiplecharMultipleDelimiterList = "//[:)][(:]\n1:)2(:3";
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

        [Test]
        public void TestNewLineDelimiter()
        {
            Assert.AreEqual(3, calculator.Add(singleNewLineDelimiterList));
        }

        [Test]
        public void TestCorrectDelimiterCombination()
        {
            Assert.AreEqual(6, calculator.Add(correctCombinationOfDelimitersList));
        }

        [Test]
        public void TestIncorrectDelimiterCombination()
        {
            Assert.That(() => calculator.Add(incorrectCombinationOfDelimitersList), Throws.Exception);
        }

        [Test]
        public void TestInputOfDelimiter()
        {
            Assert.AreEqual(10, calculator.Add(inputOfDelimiterList));
        }

        [Test]
        public void TestNegativeNumbers()
        {
            Assert.That(() => calculator.Add(negativeIntegerIncludedList), Throws.Exception);

            try {
                calculator.Add(negativeIntegerIncludedList);
            }
            catch(Exception e)
            {
                Assert.That(() => e.Message.Contains("-3"));
                Assert.That(() => e.Message.Contains("-4"));
            }
        }

        [Test]
        public void TestLargeNumbers()
        {
            Assert.AreEqual(6, calculator.Add(largeIntegerIncludedList));
        }
        
        [Test]
        public void TestMultipleCharInputDelimiter()
        {
            Assert.AreEqual(6, calculator.Add(inputOfMultipleCharDelimiterList));
        }
        
        [Test]
        public void TestMultipleInputDelimiter()
        {
            Assert.AreEqual(6, calculator.Add(inputOfMultipleDelimiterList));
        }

        [Test]
        public void TestMultipleInputMultipleCharDelimiter()
        {
            Assert.AreEqual(6, calculator.Add(inputOfMultiplecharMultipleDelimiterList));
        }
    }
}
