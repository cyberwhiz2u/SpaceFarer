using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.Tests
{
    [TestClass]
    public class DirectionFinderTest
    {
        [TestMethod]
        public void DirectionFinder_GivenMoveRightCommand_WhenCurrentlyFacingNorth_ReturnsE()
        {
            var expected = 'E';

            var actual = DirectionFinder.CalculateDirection('N', 'R');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DirectionFinder_GivenMoveLeftCommand_WhenCurrentlyFacingNorth_ReturnsW()
        {
            var expected = 'W';

            var actual = DirectionFinder.CalculateDirection('N', 'L');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DirectionFinder_GivenMoveLeftCommand_WhenCurrentlyFacingSouth_ReturnsE()
        {
            var expected = 'E';

            var actual = DirectionFinder.CalculateDirection('S', 'L');

            Assert.AreEqual(expected, actual);
        }
    }
}
