using System;
using System.Collections.Generic;
using Utility;

namespace MissionControl
{
    public class Rover
    {
        public IPositionWithDirection Position { get; set; }

        public Rover(IPositionWithDirection position)
        {
            Position = position;
        }

        public Tuple<int[,], char, bool, int[,]> InputCommand(string input, IPosition mapBoundary, IList<IPosition> obstacles)
        {
            if (!InputValidator.IsValidInput(input)) return null;

            return Move(input.ToCharArray(), mapBoundary, obstacles);
        }

        private Tuple<int[,], char, bool, int[,]> Move(char[] commands, IPosition mapBoundary, IList<IPosition> obstacles)
        {
            Tuple<int[,], char, bool, int[,]> result = null;

            foreach (char command in commands)
            {
                int[,] coordinates = new int[,] { { Position.XCoordinate, Position.YCoordinate } };

                char direction = Position.CardinalDirection;

                if (command == 'F' || command == 'B') //move forward or backward
                {
                    result = CalculateXYCoordinates(coordinates[0, 0], coordinates[0, 1], direction, command,
                                                    mapBoundary.XCoordinate, mapBoundary.YCoordinate,
                                                    obstacles);
                }
                else if (command == 'L' || command == 'R') //change direction
                {
                    result = new Tuple<int[,], char, bool, int[,]>(coordinates, DirectionFinder.CalculateDirection(direction, command), false, null);
                }

                Position.XCoordinate = result.Item1[0, 0];

                Position.YCoordinate = result.Item1[0, 1];

                Position.CardinalDirection = result.Item2;

                if (result.Item3) //if hit an obstacle progress no further
                    break;
            }

            return result;
        }

        private Tuple<int[,], char, bool, int[,]> CalculateXYCoordinates(int xCoordinate, int yCoordinate, char cardinalDirection, char command,
                                                    int mapXCoordinate, int mapYCoordinate,
                                                    IList<IPosition> obstacles)
        {
            int? value = null;

            int[,] currentCoordinates = new int[,] { { xCoordinate, yCoordinate } };

            int[,] newCoordinates = new int[1, 2];

            Tuple<bool, int[,]> result = null;

            switch (cardinalDirection)
            {
                case 'N':
                    if (command == 'F')
                    {
                        value = (++yCoordinate >= mapYCoordinate) ? yCoordinate % mapYCoordinate : yCoordinate;
                    }
                    else if (command == 'B')
                    {
                        value = (--yCoordinate < 0) ? mapYCoordinate + yCoordinate : yCoordinate;
                    }
                    newCoordinates = new int[,] { { xCoordinate, Convert.ToInt32(value) } };
                    break;
                case 'E':
                    if (command == 'F')
                    {
                        value = (++xCoordinate >= mapXCoordinate) ? xCoordinate % mapXCoordinate : xCoordinate;
                    }
                    else if (command == 'B')
                    {
                        value = (--xCoordinate < 0) ? mapXCoordinate + xCoordinate : xCoordinate;
                    }
                    newCoordinates = new int[,] { { Convert.ToInt32(value), yCoordinate } };
                    break;
                case 'S':
                    if (command == 'F')
                    {
                        value = (--yCoordinate < 0) ? mapYCoordinate + yCoordinate : yCoordinate;
                    }
                    else if (command == 'B')
                    {
                        value = (++yCoordinate >= mapYCoordinate) ? yCoordinate % mapYCoordinate : yCoordinate;
                    }
                    newCoordinates = new int[,] { { xCoordinate, Convert.ToInt32(value) } };
                    break;
                case 'W':
                    if (command == 'F')
                    {
                        value = (--xCoordinate < 0) ? mapXCoordinate + xCoordinate : xCoordinate;
                    }
                    else if (command == 'B')
                    {
                        value = (++xCoordinate >= mapXCoordinate) ? xCoordinate % mapXCoordinate : xCoordinate;
                    }
                    newCoordinates = new int[,] { { Convert.ToInt32(value), yCoordinate } };
                    break;
            }

            result = CalculateObstructedByObstacle(newCoordinates, obstacles);

            if (result.Item1)
                newCoordinates = currentCoordinates;

            return new Tuple<int[,], char, bool, int[,]>(newCoordinates, cardinalDirection, result.Item1, result.Item2);
        }

        private Tuple<bool, int[,]> CalculateObstructedByObstacle(int[,] newCoordinates, IList<IPosition> obstacles)
        {
            bool obstructionEncountered = false;

            int[,] obstructionEncounteredAt = null;

            foreach (var obstacle in obstacles)
            {
                if ((obstacle.XCoordinate == newCoordinates[0,0]) || (obstacle.YCoordinate == newCoordinates[0, 1]))
                {
                    obstructionEncountered = true;
                    obstructionEncounteredAt = new int[,] { { obstacle.XCoordinate, obstacle.YCoordinate } };
                    break;
                }
            }

            return new Tuple<bool, int[,]>(obstructionEncountered, obstructionEncounteredAt);
        }
    }
}
