using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using Scribe.Wrappers.Types;

namespace Scribe.Wrappers
{
    /// <summary>
    /// Wrapper containing all core functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Core
    {
        public static string Version => Scribe.Core.Version;

        public static void Write(string text) => Scribe.Core.Write(text);
        public static void WriteLine(string line) => Scribe.Core.WriteLine(line);
        public static void SetFocusWindow(string title) => Native.API.SetFocusWindow(title);
        public static void Close() => Scribe.Core.Close();
        public static string GetFocusWindow() => Native.API.GetFocusWindow();
        //public static string[] GetWindowTitles() => Scribe.Core.GetWindowTitles(); //Repalce with Native.API
        public static Point GetWindowPos(string title) => Native.API.GetWindowPos(title);
    }
}
