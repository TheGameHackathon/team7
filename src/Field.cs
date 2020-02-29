using System;

namespace thegame
{
    public class Field
    {
        private readonly static int[] supportedColorsIds = new[] {1, 2, 3, 4, 5};

        //private readonly int width;
        //private readonly int height;
        //private readonly int colorsCount;

        //private readonly int[,] field;

        //public Field(int width, int height, int colorsCount)
        //{
        //    this.width = width;
        //    this.height = height;
        //    this.colorsCount = colorsCount;

        //    field = GenerateField(width, height, colorsCount);
        //} 

        public static int[,] GenerateField(int width, int height, int colorsCount)
        {
            var field = new int[width, height];

            var random = new Random();
            //var randomColors = GenerareRandomColors(colorsCount).ToArray();

            for (var x = 0; x < field.GetLength(0); x++)
            for (var y = 0; y < field.GetLength(1); y++)
                field[x, y] = supportedColorsIds[random.Next(0, supportedColorsIds.Length - 1)];

            return field;
        }

        //private HashSet<Color> GenerareRandomColors(int colorsCount)
        //{
        //    var randomColors = new HashSet<Color>();
        //    var random = new Random();

        //    while (randomColors.Count != colorsCount)
        //        randomColors.Add(
        //            Color.FromArgb(
        //                random.Next(0, 255),
        //                random.Next(0, 255),
        //                random.Next(0, 255)));

        //    return randomColors;
        //}
    }
}