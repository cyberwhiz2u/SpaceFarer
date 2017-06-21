using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MissionControl.Tests
{
    [TestFixture]
    public class RoverTest
    {
        static IPosition _mapBoundary = new MapPosition
        {
            XCoordinate = 100,
            YCoordinate = 100
        };

        static IList<IPosition> _obstacles = new Obstacle().GetObstacleList(50, _mapBoundary);

        [Test]
        public void Rover_GivenEmptyInput_ReturnsNull()
        {
            IPositionWithDirection _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("", _mapBoundary, _obstacles);

            Assert.IsNull(actual);
        }

        [Test]
        public void Rover_GivenOnlyWhitespaceInput_ReturnsNull()
        {
            IPositionWithDirection _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("  ", _mapBoundary, _obstacles);

            Assert.IsNull(actual);
        }

        [Test]
        public void Rover_GivenValidInputWithWhitespace_ReturnsNull()
        {
            IPositionWithDirection _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("FF R FF", _mapBoundary, _obstacles);

            Assert.IsNull(actual);
        }

        [Test]
        public void Rover_GivenValidInput_ReturnsLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 2,
                YCoordinate = 2,
                CardinalDirection = 'E'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            Tuple<int[,], char, bool, int[,]> actual = rover.InputCommand("FFRFF", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputFromOrigin_ReturnsLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 1,
                CardinalDirection = 'N'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("F", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputPast100By100GridYBounds_ReturnsWrappedLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 88,
                YCoordinate = 1,
                CardinalDirection = 'S'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 88,
                YCoordinate = 99,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("FFRLRR", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputPast100By100GridXBounds_ReturnsWrappedLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 1,
                YCoordinate = 88,
                CardinalDirection = 'W'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 99,
                YCoordinate = 88,
                CardinalDirection = 'E'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("FFRLRR", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputPast100By100GridNegativeYBounds_ReturnsWrappedLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 99,
                CardinalDirection = 'N'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("B", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputPast100By100GridNegativeXBounds_ReturnsWrappedLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 99,
                YCoordinate = 0,
                CardinalDirection = 'E'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'E'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("B", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputPast100By1_ReturnsWrappedLocation()
        {
            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 98,
                CardinalDirection = 'N'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("BB", _mapBoundary, _obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
        }

        [Test]
        public void Rover_GivenValidInputAndObstacleEncountered_ThenReportObstacle()
        {
            IList<IPosition> obstacles = new List<IPosition>();
            var obstacle = new ObstaclePosition { XCoordinate = 2, YCoordinate = 88 };
            obstacles.Add(obstacle);

            IPositionWithDirection _position;

            _position = new RoverPosition
            {
                XCoordinate = 1,
                YCoordinate = 77,
                CardinalDirection = 'E'
            };

            Rover expected = new Rover(_position);

            _position = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 77,
                CardinalDirection = 'E'
            };

            var rover = new Rover(_position);

            var actual = rover.InputCommand("FF", _mapBoundary, obstacles);

            Assert.AreEqual(expected.Position.XCoordinate, actual.Item1[0, 0]);
            Assert.AreEqual(expected.Position.YCoordinate, actual.Item1[0, 1]);
            Assert.AreEqual(expected.Position.CardinalDirection, actual.Item2);
            Assert.IsTrue(actual.Item3);
            Assert.AreEqual(obstacle.XCoordinate, actual.Item4[0, 0]);
            Assert.AreEqual(obstacle.YCoordinate, actual.Item4[0, 1]);
        }
    }
}
