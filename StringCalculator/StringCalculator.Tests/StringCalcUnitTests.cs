using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalcUnitTests
    {
        internal string Numbers { get; set; }
        internal StringCalc StrCalc { get; set; } = new StringCalc();

        [TestMethod]
        public void AssertEmptyStringIsZero()
        {
            Numbers = "";
            Assert.AreEqual(StrCalc.AddStrings(Numbers), 0);
        }

        [TestMethod]
        public void AssertAddingNumbers()
        {
            Numbers = "1,2";
            Assert.AreEqual(StrCalc.AddStrings(Numbers), 3);
        }

        [TestMethod]
        public void AssertAddingMultipleNumbers()
        {
            Numbers = "1,2,3,4,5,6,7,8,9";
            Assert.AreEqual(StrCalc.AddStrings(Numbers), 45);
        }

        [TestMethod]
        public void AssertAddingMultipleNumbers_NewLine()
        {
            string newLine = Environment.NewLine;
            Numbers = string.Format("1{0}2{0}3{0}4{0}5{0}6{0}7{0}8{0}9",newLine);
            Assert.AreEqual(StrCalc.AddStrings(Numbers), 45);
        }

        [TestMethod]
        public void AssertAddingMultipleNumbers_DifferentDelimeters()
        {
            string[] diffDelimeters = new string[]{$"{Environment.NewLine}",",","\\","//","%",":",";","|","***","  ","**"};
            Numbers =
                $"1{diffDelimeters[0]}2{diffDelimeters[1]}3{diffDelimeters[2]}4{diffDelimeters[3]}5{diffDelimeters[4]}6{diffDelimeters[5]}7{diffDelimeters[6]}8{diffDelimeters[7]}9{diffDelimeters[8]}10{diffDelimeters[9]}11";
            Assert.AreEqual(StrCalc.AddStrings(Numbers), 66);
        }

        [TestMethod]
        public void AssertExceptionForNumbers_GreaterThanOneK()
        {
            Numbers = $"1001 {Environment.NewLine} 1002 % 3000";
            Assert.AreEqual(StrCalc.AddStrings(Numbers),0);
        }

        [TestMethod]
        public void AssertExceptionForNumbers_LessThanZero()
        {
            Numbers = "-1 ; -1000 % -5";
            Assert.AreEqual(StrCalc.AddStrings(Numbers),0);
        }
    }
}
