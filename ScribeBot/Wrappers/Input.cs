using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MoonSharp.Interpreter;
using ScribeBot.Wrappers.Types;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Wrapper containing all input functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Input
    {
        /// <summary>
        /// Get whether a key is down or not.
        /// </summary>
        /// <param name="character">Key to check state of.</param>
        /// <returns>Whether the key is down or not</returns>
        public static bool IsKeyDown(char character) => Native.API.IsKeyDown((Native.VirtualKeyCode)character);

        /// <summary>
        /// Get whether a mouse button specified by number is down or not.
        /// </summary>
        /// <param name="button">Number of button to check.</param>
        /// <returns>Button state.</returns>
        public static bool IsMouseDown(int button) => Native.API.IsKeyDown((Native.VirtualKeyCode)((short)Native.VirtualKeyCode.LBUTTON + button));

        /// <summary>
        /// Send a string of characters that'll be interpreted as separate keys to emulate.
        /// </summary>
        /// <param name="text">String of text to input.</param>
        /// <param name="delay">Delay between key presses.</param>
        public static void SendKeyPress(string text, int delay = 100) => text.ToList().ForEach(x =>
        {
            SendKeyPress(x);
            Thread.Sleep(delay); 
        });

        /// <summary>
        /// Send a character that'll be interpreted as a single key to emulate.
        /// </summary>
        /// <param name="character">The character to input.</param>
        public static void SendKeyPress(char character) => Native.API.SendKeyPress((Native.VirtualKeyCode)character);

        /// <summary>
        /// Send mousebutton press.
        /// </summary>
        /// <param name="button">Number of button to emulate - starting from left:0.</param>
        public static void SendMousePress(int button) => Native.API.SendMousePress(button);

        /// <summary>
        /// Set position of the cursor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetCursorPos(int x, int y) => Native.API.SetCursorPos(x, y);

        /// <summary>
        /// Get current position of the cursor.
        /// </summary>
        /// <returns>Position of the cursor as a Point structure.</returns>
        public static Point GetCursorPos() => Native.API.GetCursorPos();
    }
}