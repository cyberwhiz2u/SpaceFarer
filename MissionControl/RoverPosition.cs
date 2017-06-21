namespace MissionControl
{
    public class RoverPosition : IPositionWithDirection
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public char CardinalDirection { get; set; }
    }
}
