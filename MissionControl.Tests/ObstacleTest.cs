using NUnit.Framework;

namespace MissionControl.Tests
{
    [TestFixture]
    public class ObstacleTest
    {
        IPosition _mapBoundary = new MapPosition
        {
            XCoordinate = 100,
            YCoordinate = 100
        };

        [Test]
        public void Obstacle_GivenInputLessThanOrEqualToZero_ReturnsNull()
        {
            var obstacle = new Obstacle();

            var actual = obstacle.GetObstacleList(0, _mapBoundary);

            Assert.IsNull(actual);
        }

        [Test]
        public void Obstacle_GivenInputEqualToFive_ReturnsFiveObstaclePositions()
        {
            var expected = 5;

            var obstacle = new Obstacle();

            var actual = obstacle.GetObstacleList(5, _mapBoundary);

            Assert.AreEqual(expected, actual.Count);
        }
    }
}
