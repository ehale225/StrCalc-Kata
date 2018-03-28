using StringCalculator;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass()]
    public class UserInputUnitTests
    {
        [TestMethod()]
        public void GetUserInputTest()
        {
            string[] args = { "100", "%", "-1", "//", "1001", "10" };
            UserInput usrInput = new UserInput();
            Assert.AreEqual(usrInput.GetUserInput(args), string.Join(Environment.NewLine, args));
        }

        [TestMethod()]
        public void GetInfoFromUserTest_ReturnsString()
        {
            string[] args = { "100", "%", "-1", "//", "1001", "10" };
            UserInput usrInput = new UserInput();
            usrInput.GetUserInput(args);
            Assert.IsNotNull(usrInput.UserInputStr);
            Assert.AreEqual(usrInput.UserInputStr, string.Join(Environment.NewLine, args));
        }
    }
}