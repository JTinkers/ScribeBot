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
        public static string Version => Scribe.Core.Version;

        public static void Write(String value) => Scribe.Core.Write(value);
        public static void WriteLine(String value) => Scribe.Core.WriteLine(value);
        public static void SetFocusWindow(String value) => Native.API.SetFocusWindow(value);
        public static void Close() => Scribe.Core.Close();
        public static string[] GetWindowTitles() => Scribe.Core.GetWindowTitles();
    }
}
