using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.Tests
{
    [TestClass]
    public class InputValidatorTest
    {
        [TestMethod]
        public void InputValidator_GivenInputOtherThanCharactersFBLR_ReturnsFalse()
        {
            var expected = false;

            var actual = InputValidator.InputContainsAuthorisedCommands("abcdas12f");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputValidator_GivenValidInputInUpperCase_ReturnsTrue()
        {
            var expected = true;

            var actual = InputValidator.InputContainsAuthorisedCommands("FBLR");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputValidator_GivenValidInputInLowerCase_ReturnsFalse()
        {
            var expected = false;

            var actual = InputValidator.InputContainsAuthorisedCommands("fblr");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputValidator_GivenValidInputInUpperCaseAndWhitespace_ReturnsFalse()
        {
            var expected = false;

            var actual = InputValidator.InputContainsAuthorisedCommands("FB LR");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputValidator_GivenInputWithSpace_ReturnsFalse()
        {
            var expected = false;

            var actual = InputValidator.IsValidInput(" ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputValidator_GivenInputOtherThanCharactersFBLRAndWhitespace_ReturnsFalse()
        {
            var expected = false;

            var actual = InputValidator.IsValidInput("asd123fb lr");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputValidator_GivenValidInput_ReturnsTrue()
        {
            var expected = true;

            var actual = InputValidator.IsValidInput("FBLR");

            Assert.AreEqual(expected, actual);
        }
    }
}
