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
    struct Point
    {
        public int X, Y;

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Point[ X = {X}, Y = {Y} ]";
    }
}
