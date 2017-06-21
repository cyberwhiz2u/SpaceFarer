using System;
using System.Collections.Generic;

namespace MissionControl
{
    public class Obstacle
    {
        public IList<IPosition> GetObstacleList(int total, IPosition mapBounds)
        {
            if (total <= 0) return null;

            Random randomValue = new Random();

            var obstacles = new List<IPosition>();

            for (int count = 0; count < total; count++)
            {
                var obstacle = new ObstaclePosition { XCoordinate = randomValue.Next(0, mapBounds.XCoordinate), YCoordinate = randomValue.Next(0, mapBounds.YCoordinate) };

                obstacles.Add(obstacle);
            }

            return obstacles;
        }
    }
}
