namespace MissionControl
{
    public interface IPositionWithDirection
    {
        int XCoordinate { get; set; }

        int YCoordinate { get; set; }

        char CardinalDirection { get; set; }
    }
}
