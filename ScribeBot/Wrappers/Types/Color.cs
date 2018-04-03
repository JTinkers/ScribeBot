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
    }
}
