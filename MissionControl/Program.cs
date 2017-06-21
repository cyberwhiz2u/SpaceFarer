using System;
using System.Collections.Generic;
using System.Text;

namespace MissionControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandLine = "";

            Console.WriteLine("\nMission Control - Allowed Commands (Case Senstive): " +
                              "\nF >> Move 1 Position Forward" +
                              "\nB >> Move 1 Position Back" + 
                              "\nL >> Turn Left, R >> Turn Right" +
                              "\nEND >> to complete the Mission");

            IPositionWithDirection _roverPosition = new RoverPosition
            {
                XCoordinate = 0,
                YCoordinate = 0,
                CardinalDirection = 'N'
            };

            IPosition _mapBoundary = new MapPosition
            {
                XCoordinate = 100,
                YCoordinate = 100
            };

            Rover rover = new Rover(_roverPosition);

            Obstacle obstacle = new Obstacle();

            int numberOfObstacles = 50;

            IList<IPosition> obstacles = obstacle.GetObstacleList(numberOfObstacles, _mapBoundary);

            while (commandLine != "END")
            {
                Console.WriteLine("\nEnter Command: ");
                commandLine = Console.ReadLine();

                if (commandLine == "END")
                    break;

                Console.WriteLine($"The command entered was: {commandLine}");

                var result = rover.InputCommand(commandLine, _mapBoundary, obstacles);

                if (result != null)
                {
                    var position = "(" + result.Item1[0,0].ToString() +
                                    ", " + result.Item1[0, 1].ToString() +
                                    ", " + result.Item2.ToString() + ")";

                    Console.WriteLine($"The rover position is now: {position}");

                    if (result.Item3)
                    {
                        Console.WriteLine($"The rover has encountered obstacles: {result.Item3}");
                        var obstaclePosition = "(" + result.Item4[0, 0].ToString() +
                                        ", " + result.Item4[0, 1].ToString() + ")";

                        Console.WriteLine($"The rover encountered an obstacle at : {obstaclePosition}");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR - Invalid command. Try Again.");
                }

                commandLine = "";
            }

            Console.WriteLine("\nMission Ended!!");
            Console.ReadLine();
        }
    }
}
