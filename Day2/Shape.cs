using System.Reflection;

namespace Day2
{
    internal sealed class Shape : IEquatable<Shape>
    {
        public static readonly Shape Rock = new('A', 'X', 1);
        public static readonly Shape Paper = new('B', 'Y', 2);
        public static readonly Shape Scissors = new('C', 'Z', 3);

        public static readonly ISet<Shape> AllShapes;

        public char OpponentSymbol { get; }
        public char YourSymbol { get; }
        public int Score { get; }
        public Shape ShapeToWinAgainst { get; private set; } = null!;

        static Shape()
        {
            AllShapes = typeof(Shape)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(Shape))
                .Select(f => (Shape)f.GetValue(null)!)
                .ToHashSet();

            Rock.ShapeToWinAgainst = Paper;
            Paper.ShapeToWinAgainst = Scissors;
            Scissors.ShapeToWinAgainst = Rock;
        }

        private Shape(char opponentSymbol, char yourSymbol, int score)
        {
            OpponentSymbol = opponentSymbol;
            YourSymbol = yourSymbol;
            Score = score;
        }

        public static Shape FromOpponentSymbol(char symbol)
        {
            return AllShapes.SingleOrDefault(s => s.OpponentSymbol == symbol)
                ?? throw new ArgumentException("Invalid symbol");
        }

        public static Shape FromYourSymbol(char symbol)
        {
            return AllShapes.SingleOrDefault(s => s.YourSymbol == symbol)
                ?? throw new ArgumentException("Invalid symbol");
        }

        public static Outcome CalculateOutcome(Shape opponentShape, Shape yourShape)
        {
            if (yourShape == opponentShape)
            {
                return Outcome.Draw;
            }
            else if (yourShape == opponentShape.ShapeToWinAgainst)
            {
                return Outcome.YouWin;
            }

            return Outcome.YouLose;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Shape shape)
            {
                return Equals(shape);
            }

            return false;
        }

        public bool Equals(Shape? other) => Equals(OpponentSymbol, other?.OpponentSymbol)
            && Equals(YourSymbol, other?.YourSymbol)
            && Equals(Score, other?.Score);
        public override int GetHashCode() => HashCode.Combine(OpponentSymbol, YourSymbol, Score);
        public override string ToString() => $"{OpponentSymbol} / {YourSymbol}";

        public static bool operator ==(Shape x, Shape y) => Equals(x, y);
        public static bool operator !=(Shape x, Shape y) => !Equals(x, y);
    }
}
