using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribeBot.Wrappers.Types;

namespace ScribeBot.Native
{
    /// <summary>
    /// Wrapper class created to simplify usage of native functionality derived via DllImport.
    /// </summary>
    class API
    {
        /// <summary>
        /// Get window handle that matches given title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static IntPtr GetWindowHandleByTitle(string title)
        {
            IEnumerable<Process> processes = Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle));

            processes = processes.Where(x => x.MainWindowTitle == title);

            if (processes.Any())
                return processes.First().MainWindowHandle;

            return IntPtr.Zero;
        }

        /// <summary>
        /// Bring a window of given title to the front and switch input focus to it.
        /// </summary>
        /// <param name="title"></param>
        public static void SetFocusWindow(string title)
        {
            IntPtr windowHandle = GetWindowHandleByTitle(title);

            if (windowHandle != IntPtr.Zero)
                Native.SetForegroundWindow(windowHandle);
        }

        /// <summary>
        /// Get window title of a currently focused window.
        /// </summary>
        /// <returns></returns>
        public static string GetFocusWindow()
        {
            StringBuilder title = new StringBuilder();

            Native.GetWindowText(Native.GetForegroundWindow(), title, 256);

            return title.ToString();
        }

        /// <summary>
        /// Get position of a window of given title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static Point GetWindowPos(string title)
        {
            WindowRect rect;

            Native.GetWindowRect(GetWindowHandleByTitle(title), out rect);

            return new Point() { X = rect.Left, Y = rect.Top };
        }

        /// <summary>
        /// Set position of the cursor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetCursorPos(int x, int y)
        {
            Native.SetCursorPos(x, y);
        }

        /// <summary>
        /// Get position of the cursor.
        /// </summary>
        /// <returns></returns>
        public static Point GetCursorPos()
        {
            NativePoint point;

            Native.GetCursorPos(out point);

            return new Point() { X = point.X, Y = point.Y };
        }

        /// <summary>
        /// Emulate a key press.
        /// </summary>
        /// <param name="key"></param>
        public static void SendKeyPress(VirtualKeyCode key)
        {
            Input[] inputs = new Input[]
            {
                new Input
                {
                    Type = 1,
                    Data = new InputUnion
                    {
                        KeyboardInput = new KeyboardInputData
                        {
                            VirtualKey = key
                        }
                    }
                }
            };

            Native.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        /// <summary>
        /// Emulate a mouse key press.
        /// </summary>
        /// <param name="button"></param>
        public static void SendMousePress(int button)
        {
            Point cPos = GetCursorPos();

            switch (button)
            {
                case 0:
                    Native.mouse_event((int)MouseEventFlags.LEFTDOWN, cPos.X, cPos.Y, 0, 0);
                    Native.mouse_event((int)MouseEventFlags.LEFTUP, cPos.X, cPos.Y, 0, 0);
                    break;

                case 1:
                    Native.mouse_event((int)MouseEventFlags.RIGHTDOWN, cPos.X, cPos.Y, 0, 0);
                    Native.mouse_event((int)MouseEventFlags.RIGHTUP, cPos.X, cPos.Y, 0, 0);
                    break;

                case 2:
                    Native.mouse_event((int)MouseEventFlags.MIDDLEDOWN, cPos.X, cPos.Y, 0, 0);
                    Native.mouse_event((int)MouseEventFlags.MIDDLEUP, cPos.X, cPos.Y, 0, 0);
                    break;

                default:
                    break;
            }
        }
    }
}