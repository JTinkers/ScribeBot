using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace ScribeBot.Wrappers.Types
{
    /// <summary>
    /// Proxy Type
    /// </summary>
    [MoonSharpUserData]
    struct Color
    {
        public int R, G, B;

        public Color( int r, int g, int b )
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