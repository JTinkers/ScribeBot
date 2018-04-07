using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribeBot.Wrappers.Types
{
    /// <summary>
    /// Proxy structure
    /// </summary>
    [MoonSharpUserData]
    struct Size
    {
        public int Width, Height;

        /// <summary>
        /// Override to simplify console output.
        /// </summary>
        /// <returns>Formatted string.</returns>
        public override string ToString() => $"Size[ Width = {Width}, Height = {Height} ]";
    }
}
