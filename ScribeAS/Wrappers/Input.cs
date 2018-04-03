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
    /// Wrapper containing all input functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Input
    {
        public static void SendKeyPress(Native.VirtualKeyCode key) => Native.API.SendKeyPress(key);
        public static void SendMousePress(int button) => Native.API.SendMousePress(button);
        public static void SetCursorPos(int x, int y) => Native.API.SetCursorPos(x, y);
        public static Point GetCursorPos() => Native.API.GetCursorPos();
    }
}