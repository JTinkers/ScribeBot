using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using ScribeBot.Wrappers.Types;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Wrapper containing all core functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Core
    {
        public static string Version => ScribeBot.Core.Version;

        public static void ProcessConsoleInput() => ScribeBot.Core.ProcessConsoleInput();

        public static void Write(string text) => ScribeBot.Core.Write(text);

        public static void WriteLine(string line) => ScribeBot.Core.WriteLine(line);

        public static void SetFocusWindow(string title) => Native.API.SetFocusWindow(title);

        public static string GetFocusWindow() => Native.API.GetFocusWindow();

        public static void SetWindowSize(string title, int w, int h) => Native.API.SetWindowSize(title, w, h);

        public static Size GetWindowSize(string title) => Native.API.GetWindowSize(title);

        public static void SetWindowPos(string title, int x, int y) => Native.API.SetWindowPos(title, x, y);

        public static Point GetWindowPos(string title) => Native.API.GetWindowPos(title);

        public static bool IsWindowVisible(string title) => Native.API.IsWindowVisible(title);

        public static string[] GetWindowTitles() => Native.API.GetWindowTitles();

        public static void Close() => ScribeBot.Core.Close();
    }
}
