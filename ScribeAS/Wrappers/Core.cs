using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Scribe.Wrappers
{
    [MoonSharpUserData]
    class Core
    {
        public static void Write(String value) => Scribe.Core.Write(value);
        public static void WriteLine(String value) => Scribe.Core.WriteLine(value);
    }
}
