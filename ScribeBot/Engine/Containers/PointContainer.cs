using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace ScribeBot.Engine.Containers
{
    /// <summary>
    /// Container structure for System.Drawing.Point
    /// </summary>
    [MoonSharpUserData]
    public struct PointContainer
    {
        public int X, Y;

        public PointContainer(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Point[ X = {X}, Y = {Y} ]";
    }
}
