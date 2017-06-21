using System;

namespace Utility
{
    public static class DirectionFinder
    {
        private enum CardinalDirection { N = 0, E = 90, S = 180, W = 270 };

        public static char CalculateDirection(char currentDirection, char command)
        {
            int currentDirectionValue = (int)((CardinalDirection)Enum.Parse(typeof(CardinalDirection), currentDirection.ToString()));

            int commandValue = (command == 'L') ? -90 : 90;

            int newDirectionValue = (currentDirectionValue + commandValue) < 0 ? (360 + (currentDirectionValue + commandValue)) % 360 :
                                                                                    (currentDirectionValue + commandValue) % 360;

            return (((CardinalDirection)newDirectionValue).ToString().ToCharArray())[0];
        }
    }
}
