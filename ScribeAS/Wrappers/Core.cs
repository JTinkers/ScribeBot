using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Scribe.Wrappers
{
    [MoonSharpUserData]
    static class Core
    {
        private static string version = "0.1beta"; // fetch from core class

        public static string Version { get => version; set => version = value; } // fetch from core class

        public static void Write(String value) => Scribe.Core.Write(value);
        public static void WriteLine(String value) => Scribe.Core.WriteLine(value);
        public static void SetFocusWindow(String value) => Native.API.SetFocusWindow(value);
    }
}
