using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace ScribeBot.Engine.Containers
{
    /// <summary>
    /// Container structure for System.Drawing.Color
    /// </summary>
    [MoonSharpUserData]
    struct ColorContainer
    {
        public int R, G, B;

        public ColorContainer( int r, int g, int b )
        {
            R = r;
            G = g;
            B = b;
        }

        public static ColorContainer[][] FromBitmap(string path)
        {
            var bmp = new Bitmap(path);

            var colors = new ColorContainer[bmp.Height][];
            for (int i = 0; i < bmp.Width; i++)
            {
                colors[i] = new ColorContainer[bmp.Height];
            }

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    colors[y][x] = new ColorContainer(bmp.GetPixel(y, x).R, bmp.GetPixel(y, x).G, bmp.GetPixel(y, x).B);
                }
            }

            return colors;
        }

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Color[ R = {R}, G = {G}, B = {B} ]";
    }
}