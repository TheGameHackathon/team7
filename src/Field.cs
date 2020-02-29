using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace thegame
{
    internal struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Field
    {
        private readonly static int[] supportedColorsIds = new[] { 1, 2, 3, 4, 5 };

        private readonly int width;
        private readonly int height;
        private readonly int colorsCount;

        private readonly int[,] field;

        private readonly HashSet<Coordinates> groupCoordinates;

        public Field(int width, int height, int colorsCount)
        {
            this.width = width;
            this.height = height;
            this.colorsCount = colorsCount;

            field = GenerateField(width, height, colorsCount);
            groupCoordinates = new HashSet<Coordinates>();
        }

        private int[,] GenerateField(int width, int height, int colorsCount)
        {
            var field = new int[width, height];

            var random = new Random();
            //var randomColors = GenerareRandomColors(colorsCount).ToArray();

            for (var x = 0; x < field.GetLength(0); x++)
                for (var y = 0; y < field.GetLength(1); y++)
                    field[x, y] = supportedColorsIds[random.Next(0, supportedColorsIds.Length - 1)];

            return field;
        }

        public int[,] GetField() => field;

        public int[,] ClickedTo(int x, int y)
        {
            var colorId = field[x, y];
            field[0, 0] = colorId;

            foreach (var n in groupCoordinates)
                field[n.X, n.Y] = colorId;

            var neighbours = FindNeighboursByColor(0, 0);
            foreach (var n in neighbours)
                groupCoordinates.Add(n);

            return field;
        }

        private HashSet<Coordinates> FindNeighboursByColor(int x, int y)
        {
            var neighbours = new HashSet<Coordinates>();
            var checkedCoordinates = new HashSet<Coordinates>();
            var queue = new Queue<Coordinates>();

            queue.Enqueue(new Coordinates { X = x, Y = y });

            while (queue.Count > 0)
            {
                var coords = queue.Dequeue();

                foreach (var neighbour in GetNeighbours(x, y)
                    .Where(c =>
                    c.X < field.GetLength(0) &&
                    c.Y < field.GetLength(1) &&
                    field[x, y] == field[c.X, c.Y] &&
                    !checkedCoordinates.Contains(c)))
                {
                    neighbours.Add(neighbour);
                    queue.Enqueue(neighbour);
                }

                checkedCoordinates.Add(coords);
            }

            return neighbours;
        }

        private IEnumerable<Coordinates> GetNeighbours(int x, int y)
        {
            for (var dx = 0; dx <= 1; dx++)
                for (var dy = 0; dy <= 1; dy++)
                    yield return new Coordinates { X = x + dx, Y = y + dy };
        }
    }
}