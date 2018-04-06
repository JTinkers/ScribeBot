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
        /// <param name="title">The title of window to get a handle of.</param>
        /// <returns></returns>
        private static IntPtr GetWindowHandleByTitle(string title)
        {
            IEnumerable<Process> processes = Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle));

            processes = processes.Where(x => x.MainWindowTitle == title);

            if (processes.Any())
                return processes.First().MainWindowHandle;

            return IntPtr.Zero;
        }

        public static string[] GetWindowTitles()
        {
            IEnumerable<Process> processes = Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle));

            if (processes.Any())
                return processes.Select(x => x.MainWindowTitle).ToArray();

            return new string[0];
        }

        /// <summary>
        /// Set window into focus.
        /// </summary>
        /// <param name="title">The title of window to set focus to.</param>
        public static void SetFocusWindow(string title)
        {
            IntPtr handle = GetWindowHandleByTitle(title);

            if (handle != IntPtr.Zero)
                Native.SetForegroundWindow(handle);
        }

        /// <summary>
        /// Get window title of a currently focused window.
        /// </summary>
        /// <returns>Title of window currently in focus.</returns>
        public static string GetFocusWindow()
        {
            StringBuilder title = new StringBuilder();

            Native.GetWindowText(Native.GetForegroundWindow(), title, 256);

            return title.ToString();
        }

        /// <summary>
        /// Check whether window is visible.
        /// </summary>
        /// <param name="title">The title of window to check.</param>
        /// <returns>Whether it's visible or not</returns>
        public static bool IsWindowVisible(string title)
        {
            IntPtr handle = GetWindowHandleByTitle(title);

            return Native.IsWindowVisible(handle);
        }

        /// <summary>
        /// Set size of window of a specified title.
        /// </summary>
        /// <param name="title">Title of window to set size of.</param>
        /// <param name="width">The width of window.</param>
        /// <param name="height">The height of window.</param>
        public static void SetWindowSize(string title, int width, int height)
        {
            IntPtr handle = GetWindowHandleByTitle(title);

            Native.GetWindowRect(handle, out WindowRect rect);

            Native.MoveWindow(GetWindowHandleByTitle(title), rect.Left, rect.Top, width, height, true);
        }

        /// <summary>
        /// Get size of window of a specified title.
        /// </summary>
        /// <param name="title">Title of window to get size of.</param>
        /// <returns>The size of window.</returns>
        public static Size GetWindowSize(string title)
        {
            IntPtr handle = GetWindowHandleByTitle(title);

            Native.GetWindowRect(handle, out WindowRect rect);

            return new Size() { Width = rect.Right - rect.Left, Height = rect.Bottom - rect.Top };
        }

        /// <summary>
        /// Set window position.
        /// </summary>
        /// <param name="title">Title of windowo to set position of.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetWindowPos(string title, int x, int y)
        {
            IntPtr handle = GetWindowHandleByTitle(title);

            Native.GetWindowRect(handle, out WindowRect rect);

            Native.MoveWindow(GetWindowHandleByTitle(title), x, y, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
        }

        /// <summary>
        /// Get position of a window of given title.
        /// </summary>
        /// <param name="title">Title of window to get position of.</param>
        /// <returns>Position of window of a specified title.</returns>
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
        /// <returns>Position of the cursor.</returns>
        public static Point GetCursorPos()
        {
            Native.GetCursorPos(out NativePoint point);

            return new Point() { X = point.X, Y = point.Y };
        }

        /// <summary>
        /// Emulate a key press.
        /// </summary>
        /// <param name="key">VirtualKeyCode of a key to emulate.</param>
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
        /// <param name="button">Number of mousebutton to emulate.</param>
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