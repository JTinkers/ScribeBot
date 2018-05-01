using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace ScribeBot.Engine.Containers
{
    /// <summary>
    /// Container structure for System.Drawing.Size
    /// </summary>
    [MoonSharpUserData]
    struct SizeContainer
    {
        public int Width, Height;

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Size[ Width = {Width}, Height = {Height} ]";
    }
}
