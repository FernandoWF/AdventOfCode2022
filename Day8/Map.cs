namespace Day8
{
    internal class Map
    {
        private readonly int[,] trees;

        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            trees = new int[width, height];
        }

        public bool IsTreeVisible(int treeX, int treeY)
        {
            if (treeX < 0 || treeX >= Width) { throw new ArgumentOutOfRangeException(nameof(treeX)); }
            if (treeY < 0 || treeY >= Height) { throw new ArgumentOutOfRangeException(nameof(treeY)); }

            var specifiedTreeHeight = trees[treeX, treeY];

            var isVisibleFromTop = true;
            for (var y = 0; y < treeY; y++)
            {
                var currentTreeHeight = trees[treeX, y];
                isVisibleFromTop &= currentTreeHeight < specifiedTreeHeight;
            }

            var isVisibleFromBottom = true;
            for (var y = Height - 1; y > treeY; y--)
            {
                var currentTreeHeight = trees[treeX, y];
                isVisibleFromBottom &= currentTreeHeight < specifiedTreeHeight;
            }

            var isVisibleFromLeft = true;
            for (var x = 0; x < treeX; x++)
            {
                var currentTreeHeight = trees[x, treeY];
                isVisibleFromLeft &= currentTreeHeight < specifiedTreeHeight;
            }

            var isVisibleFromRight = true;
            for (var x = Width - 1; x > treeX; x--)
            {
                var currentTreeHeight = trees[x, treeY];
                isVisibleFromRight &= currentTreeHeight < specifiedTreeHeight;
            }

            return isVisibleFromTop || isVisibleFromBottom || isVisibleFromLeft || isVisibleFromRight;
        }

        public int this[int x, int y]
        {
            get => trees[x, y];
            set => trees[x, y] = value;
        }
    }
}
