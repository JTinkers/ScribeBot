using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Color[ R = {R}, G = {G}, B = {B} ]";
    }
}