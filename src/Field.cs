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
        private static int[,] field;

        public static void InitializeField(int width, int height, int colorsCount)
        {
            field = GenerateField(width, height, colorsCount);
        }

        private static int[,] GenerateField(int width, int height, int colorsCount)
        {
            var field = new int[height, width];
            var random = new Random();

            for (var x = 0; x < field.GetLength(1); x++)
                for (var y = 0; y < field.GetLength(0); y++)
                    field[y, x] = random.Next(0, colorsCount - 1);

            return field;
        }

        public static int[,] GetField() => field;

        public static int[,] ClickedTo(int x, int y)
        {
            var colorIdForPaint = field[y, x];

            var neighbours = FindNeighboursByColor(0, 0);

            field[0, 0] = colorIdForPaint;
            foreach (var n in neighbours)
                field[n.Y, n.X] = colorIdForPaint;

            return field;
        }

        private static HashSet<Coordinates> FindNeighboursByColor(int x, int y)
        {
            var neighbours = new HashSet<Coordinates>();
            var checkedCoordinates = new HashSet<Coordinates>();
            var queue = new Queue<Coordinates>();

            queue.Enqueue(new Coordinates { X = x, Y = y });

            while (queue.Count > 0)
            {
                var coords = queue.Dequeue();
                checkedCoordinates.Add(coords);

                foreach (var neighbour in GetNeighbours(coords.X, coords.Y)
                    .Where(c =>
                    c.X < field.GetLength(1) &&
                    c.Y < field.GetLength(0) &&
                    field[y, x] == field[c.Y, c.X] &&
                    !checkedCoordinates.Contains(c)))
                {
                    neighbours.Add(neighbour);
                    queue.Enqueue(neighbour);
                }
            }

            return neighbours;
        }

        private static IEnumerable<Coordinates> GetNeighbours(int x, int y)
        {
            for (var dx = 0; dx <= 1; dx++)
                for (var dy = 0; dy <= 1; dy++)
                {
                    if (dx == 1 && dy == 1)
                        continue;
                    yield return new Coordinates { X = x + dx, Y = y + dy };
                }
        }
    }
}