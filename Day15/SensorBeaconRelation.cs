using System.Drawing;

namespace Day15
{
    internal class SensorBeaconRelation
    {
        public Point SensorPosition { get; }
        public Point BeaconPosition { get; }
        public int ManhattanDistance { get; }

        public SensorBeaconRelation(Point sensorPosition, Point beaconPosition)
        {
            SensorPosition = sensorPosition;
            BeaconPosition = beaconPosition;
            ManhattanDistance = Math.Abs(beaconPosition.X - sensorPosition.X) + Math.Abs(beaconPosition.Y - sensorPosition.Y);
        }
    }
}
