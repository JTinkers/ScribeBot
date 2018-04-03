using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Scribe.Wrappers.Types
{
    /// <summary>
    /// Proxy structure for System.Drawing.Point
    /// </summary>
    [MoonSharpUserData]
    public struct Point
    {
        public int X, Y;
    }
}
