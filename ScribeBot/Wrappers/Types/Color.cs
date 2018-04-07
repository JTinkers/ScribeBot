using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace ScribeBot.Wrappers.Types
{
    /// <summary>
    /// Proxy structure
    /// </summary>
    [MoonSharpUserData]
    public struct Color
    {
        public int R, G, B;

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Color[ R = {R}, G = {G}, B = {B} ]";
    }
}
