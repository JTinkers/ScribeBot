using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MoonSharp.Interpreter;
using ScribeBot.Engine.Containers;

namespace ScribeBot.Engine.Wrappers
{
    /// <summary>
    /// Wrapper containing all input functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class InputWrapper
    {
        /// <summary>
        /// Post WinAPI message directly to the window.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public static void PostMessage(string title, uint message, int param1, int param2) => Native.API.PostMessage(title, message, param1, param2);

        /// <summary>
        /// Get whether a key is down or not.
        /// </summary>
        /// <param name="key">Key to check state of.</param>
        /// <returns>Whether the key is down or not</returns>
        public static bool IsKeyDown(Native.VirtualKeyCode key) => Native.API.IsKeyDown(key);

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
            if (char.IsUpper(x))
            {
                SendKeyDown(Native.VirtualKeyCode.LSHIFT);
                SendKeyPress((Native.VirtualKeyCode)char.ToUpper(x));
                SendKeyUp(Native.VirtualKeyCode.LSHIFT);
            }
            else
                SendKeyPress((Native.VirtualKeyCode)char.ToUpper(x));

            Thread.Sleep(delay);
        });

        /// <summary>
        /// Emulate key press and release
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        public static void SendKeyPress(Native.VirtualKeyCode key) => Native.API.SendKeyPress(key);

        /// <summary>
        /// Emulate key press.
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        public static void SendKeyDown(Native.VirtualKeyCode key) => Native.API.SendKeyDown(key);

        /// <summary>
        /// Emulate key release.
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        public static void SendKeyUp(Native.VirtualKeyCode key) => Native.API.SendKeyUp(key);

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
        public static PointContainer GetCursorPos() => Native.API.GetCursorPos();

        /// <summary>
        /// Send mousebutton press.
        /// </summary>
        /// <param name="button">Number of button to emulate - starting from left:0.</param>
        public static void SendMousePress(int button) => Native.API.SendMousePress(button);

        /// <summary>
        /// Emulate mouse button press.
        /// </summary>
        /// <param name="button">Number of mouse button to emulate.</param>
        public static void SendMouseDown(int button) => Native.API.SendMouseDown(button);

        /// <summary>
        /// Emulate mouse button release.
        /// </summary>
        /// <param name="button">Number of mouse button to emulate.</param>
        public static void SendMouseUp(int button) => Native.API.SendMouseUp(button);
    }
}