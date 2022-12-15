using System.Drawing;
using Common;

namespace Day15
{
    internal class Part2 : ISolution
    {
        private const int DistressBeaconMinimumCoordinates = 0;
        private const int DistressBeaconMaximumCoordinates = 4000000;

        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var relations = new List<SensorBeaconRelation>();

            foreach (var line in lines)
            {
                var relation = Part1.GetRelation(line);
                relations.Add(relation);
            }

            var distressBeaconPosition = GetDistressBeaconPosition(relations);
            var tuningFrequency = distressBeaconPosition.X * 4000000L + distressBeaconPosition.Y;
            Console.WriteLine(tuningFrequency);
        }

        private static Point GetDistressBeaconPosition(IReadOnlyList<SensorBeaconRelation> relations)
        {
            foreach (var relation in relations)
            {
                var adjacentPositions = GetPositionsAdjacentToSensorReachAreaInsideValidRange(
                    relation,
                    DistressBeaconMinimumCoordinates,
                    DistressBeaconMaximumCoordinates);

                foreach (var position in adjacentPositions)
                {
                    var positionCanBeReached = false;
                    foreach (var relationToCompare in relations)
                    {
                        var manhattanDistanceFromPositionToSensor = Math.Abs(position.X - relationToCompare.SensorPosition.X)
                            + Math.Abs(position.Y - relationToCompare.SensorPosition.Y);
                        if (manhattanDistanceFromPositionToSensor <= relationToCompare.ManhattanDistance)
                        {
                            positionCanBeReached = true;
                            break;
                        }
                    }

                    if (!positionCanBeReached)
                    {
                        return new Point(position.X, position.Y);
                    }
                }
            }

            throw new Exception("Distress beacon could not be found");
        }

        private static ISet<Point> GetPositionsAdjacentToSensorReachAreaInsideValidRange(SensorBeaconRelation relation, int minimumCoordinates, int maximumCoordinates)
        {
            var sensorX = relation.SensorPosition.X;
            var sensorY = relation.SensorPosition.Y;
            var adjacentPositions = new HashSet<Point>();

            var distanceToAdjacentPositions = relation.ManhattanDistance + 1;
            for (var deltaY = -distanceToAdjacentPositions; deltaY <= distanceToAdjacentPositions; deltaY++)
            {
                var deltaX = distanceToAdjacentPositions - Math.Abs(deltaY);
                var position1X = sensorX - deltaX;
                var position2X = sensorX + deltaX;
                var positionsY = sensorY + deltaY;

                if (positionsY >= minimumCoordinates && positionsY <= maximumCoordinates)
                {
                    if (position1X >= minimumCoordinates && position1X <= maximumCoordinates)
                    {
                        adjacentPositions.Add(new Point(position1X, positionsY));
                    }

                    if (position2X >= minimumCoordinates && position2X <= maximumCoordinates)
                    {
                        adjacentPositions.Add(new Point(position2X, positionsY));
                    }
                }
            }

            return adjacentPositions;
        }
    }
}
