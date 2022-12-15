using System.Drawing;
using Common;

namespace Day15
{
    internal class Part1 : ISolution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Input.txt");
            var yCoordinateOfTargetRow = 2000000;
            var xCoordinatesOfBeaconsInTargetRow = new HashSet<int>();
            var relations = new List<SensorBeaconRelation>();

            foreach (var line in lines)
            {
                var relation = GetRelation(line);
                relations.Add(relation);
                if (relation.BeaconPosition.Y == yCoordinateOfTargetRow)
                {
                    xCoordinatesOfBeaconsInTargetRow.Add(relation.BeaconPosition.X);
                }
            }

            var reachableXCoordinatesInTargetRow = GetReachableXCoordinatesInTargetRow(yCoordinateOfTargetRow, relations);
            reachableXCoordinatesInTargetRow.ExceptWith(xCoordinatesOfBeaconsInTargetRow);

            Console.WriteLine(reachableXCoordinatesInTargetRow.Count);
        }

        public static SensorBeaconRelation GetRelation(string line)
        {
            var sensorXStartPosition = line.IndexOf('=') + 1;
            var sensorSeparatorAfterXPosition = line.IndexOf(',');
            var sensorX = int.Parse(line[sensorXStartPosition..sensorSeparatorAfterXPosition]);

            var sensorYStartPosition = sensorSeparatorAfterXPosition + ", y=".Length;
            var sensorSeparatorAfterYPosition = line.IndexOf(':', sensorYStartPosition);
            var sensorY = int.Parse(line[sensorYStartPosition..sensorSeparatorAfterYPosition]);

            var beaconXStartPosition = line.IndexOf('=', sensorSeparatorAfterYPosition) + 1;
            var beaconSeparatorAfterXPosition = line.IndexOf(',', sensorSeparatorAfterYPosition);
            var beaconX = int.Parse(line[beaconXStartPosition..beaconSeparatorAfterXPosition]);

            var beaconYStartPosition = beaconSeparatorAfterXPosition + ", y=".Length;
            var beaconY = int.Parse(line[beaconYStartPosition..]);

            return new SensorBeaconRelation(new Point(sensorX, sensorY), new Point(beaconX, beaconY));
        }

        private static ISet<int> GetReachableXCoordinatesInTargetRow(int yCoordinateOfTargetRow, IReadOnlyList<SensorBeaconRelation> relations)
        {
            var reachableXCoordinatesInTargetRow = new HashSet<int>();

            foreach (var relation in relations)
            {
                var sensorToTargetRowDistance = Math.Abs(yCoordinateOfTargetRow - relation.SensorPosition.Y);
                var stepsLeftAfterVerticalMovement = relation.ManhattanDistance - sensorToTargetRowDistance;
                if (stepsLeftAfterVerticalMovement > 0)
                {
                    var sensorX = relation.SensorPosition.X;
                    foreach (var xCoordinate in Enumerable.Range(sensorX - stepsLeftAfterVerticalMovement, 2 * stepsLeftAfterVerticalMovement + 1))
                    {
                        reachableXCoordinatesInTargetRow.Add(xCoordinate);
                    };
                }
            }

            return reachableXCoordinatesInTargetRow;
        }
    }
}
