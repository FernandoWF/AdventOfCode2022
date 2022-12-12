using System.Drawing;

namespace Day12
{
    internal class Area
    {
        private readonly Dictionary<Point, Square> squares = new();

        public int Width { get; }
        public int Height { get; }
        public Square Start { get; private set; } = null!;
        public Square End { get; private set; } = null!;

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Square? GetSquare(Point position)
        {
            return squares.GetValueOrDefault(position);
        }

        public Square? GetSquare(int x, int y)
        {
            return GetSquare(new Point(x, y));
        }

        public void SetSquare(char letter, Point position)
        {
            if (!char.IsAsciiLetter(letter))
            {
                throw new ArgumentException($"'{letter}' is not a letter");
            }

            var height = letter switch
            {
                'S' => 'a' - 'a',
                'E' => 'z' - 'a',
                _ => letter - 'a'
            };

            var square = new Square(position, height, this);
            squares.Add(position, square);

            if (letter == 'S')
            {
                Start = square;
            }
            else if (letter == 'E')
            {
                End = square;
            }
        }

        public void SetSquare(char letter, int x, int y)
        {
            SetSquare(letter, new Point(x, y));
        }
    }
}
