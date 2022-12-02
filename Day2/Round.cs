namespace Day2
{
    internal class Round
    {
        public Shape OpponentShape { get; }

        public Shape YourShape { get; }

        public Outcome Outcome { get; }

        public int YourScore
        {
            get
            {
                return YourShape.Score + Outcome switch
                {
                    Outcome.YouWin => 6,
                    Outcome.Draw => 3,
                    Outcome.YouLose => 0,
                    _ => throw new Exception($"{Outcome} is not a valid outcome")
                };
            }
        }

        public Round(Shape opponentShape, Shape yourShape)
        {
            OpponentShape = opponentShape;
            YourShape = yourShape;
            Outcome = Shape.CalculateOutcome(opponentShape, yourShape);
        }
    }
}
