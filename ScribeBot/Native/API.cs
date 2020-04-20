﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribeBot.Engine.Containers;
using Drawing = System.Drawing;

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
            var processes = Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle));

            processes = processes.Where(x => x.MainWindowTitle == title);

            if (processes.Any())
                return processes.First().MainWindowHandle;

            return IntPtr.Zero;
        }

        /// <summary>
        /// Generate a bitmap from screen portion.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Bitmap CopyScreenArea( int x, int y, int w = 1, int h = 1 )
        {
            var container = new Bitmap(w, h);

            var dst = Graphics.FromImage(container);
            var src = Graphics.FromHwnd(IntPtr.Zero);

            Native.BitBlt(dst.GetHdc(), 0, 0, w, h, src.GetHdc(), x, y, (int)CopyPixelOperation.SourceCopy);

            dst.ReleaseHdc();
            src.ReleaseHdc();

            dst.Dispose();
            src.Dispose();

            return container;
        }

        /// <summary>
        /// Post WinAPI message directly to the window.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public static void PostMessage(string title, uint message, int param1, int param2) => Native.PostMessage(GetWindowHandleByTitle(title), message, param1, param2);

        /// <summary>
        /// Get an array containing titles of all visible windows.
        /// </summary>
        /// <returns>An array of strings with window titles.</returns>
        public static string[] GetWindowTitles()
        {
            var processes = Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle));

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
            var title = new StringBuilder();

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
            var handle = GetWindowHandleByTitle(title);

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
            var handle = GetWindowHandleByTitle(title);

            Native.GetWindowRect(handle, out WindowRect rect);

            Native.MoveWindow(GetWindowHandleByTitle(title), rect.Left, rect.Top, width, height, true);
        }

        /// <summary>
        /// Get size of window of a specified title.
        /// </summary>
        /// <param name="title">Title of window to get size of.</param>
        /// <returns>The size of window.</returns>
        public static SizeContainer GetWindowSize(string title)
        {
            var handle = GetWindowHandleByTitle(title);

            Native.GetWindowRect(handle, out WindowRect rect);

            return new SizeContainer() { Width = rect.Right - rect.Left, Height = rect.Bottom - rect.Top };
        }

        /// <summary>
        /// Set window position.
        /// </summary>
        /// <param name="title">Title of windowo to set position of.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetWindowPos(string title, int x, int y)
        {
            var handle = GetWindowHandleByTitle(title);

            Native.GetWindowRect(handle, out WindowRect rect);

            Native.MoveWindow(GetWindowHandleByTitle(title), x, y, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
        }

        /// <summary>
        /// Get position of a window of given title.
        /// </summary>
        /// <param name="title">Title of window to get position of.</param>
        /// <returns>Position of window of a specified title.</returns>
        public static PointContainer GetWindowPos(string title)
        {
            Native.GetWindowRect(GetWindowHandleByTitle(title), out WindowRect rect);

            return new PointContainer() { X = rect.Left, Y = rect.Top };
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
        public static PointContainer GetCursorPos()
        {
            Native.GetCursorPos(out NativePoint point);

            return new PointContainer() { X = point.X, Y = point.Y };
        }

        /// <summary>
        /// Get whether key is down or not.
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        /// <returns>Key state.</returns>
        public static bool IsKeyDown(VirtualKeyCode key) => Convert.ToBoolean(Native.GetKeyState(key) & 0x8000);

        /// <summary>
        /// Emulate a key press.
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        public static void SendKeyPress(VirtualKeyCode key)
        {
            SendKeyDown(key);
            SendKeyUp(key);
        }

        /// <summary>
        /// Emulate key press.
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        public static void SendKeyDown(VirtualKeyCode key)
        {
            var inputs = new Input[]
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
        /// Emulate key press.
        /// </summary>
        /// <param name="key">VirtualKeyCode of key to emulate.</param>
        public static void SendKeyUp(VirtualKeyCode key)
        {
            var inputs = new Input[]
            {
                new Input
                {
                    Type = 1,
                    Data = new InputUnion
                    {
                        KeyboardInput = new KeyboardInputData
                        {
                            VirtualKey = key,
                            Flags = KeyEventFlags.KEYUP
                        }
                    }
                }
            };

            Native.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        /// <summary>
        /// Emulate a mouse key press.
        /// </summary>
        /// <param name="button">Number of mouse button to emulate.</param>
        public static void SendMousePress(int button, PointContainer? pos = null)
        {
            if (!pos.HasValue)
                pos = GetCursorPos();

            switch (button)
            {
                case 0:
                    Native.MouseEvent((int)MouseEventFlags.LEFTDOWN, pos.Value.X, pos.Value.Y, 0, 0);
                    Native.MouseEvent((int)MouseEventFlags.LEFTUP, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                case 1:
                    Native.MouseEvent((int)MouseEventFlags.RIGHTDOWN, pos.Value.X, pos.Value.Y, 0, 0);
                    Native.MouseEvent((int)MouseEventFlags.RIGHTUP, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                case 2:
                    Native.MouseEvent((int)MouseEventFlags.MIDDLEDOWN, pos.Value.X, pos.Value.Y, 0, 0);
                    Native.MouseEvent((int)MouseEventFlags.MIDDLEUP, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Emulate mouse press.
        /// </summary>
        /// <param name="button">Number of mouse button to emulate.</param>
        public static void SendMouseDown(int button, PointContainer? pos = null)
        {
            if(!pos.HasValue)
                pos = GetCursorPos();

            switch (button)
            {
                case 0:
                    Native.MouseEvent((int)MouseEventFlags.LEFTDOWN, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                case 1:
                    Native.MouseEvent((int)MouseEventFlags.RIGHTDOWN, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                case 2:
                    Native.MouseEvent((int)MouseEventFlags.MIDDLEDOWN, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Emulate mouse button release.
        /// </summary>
        /// <param name="button">Number of mouse button to emulate.</param>
        public static void SendMouseUp(int button, PointContainer? pos = null)
        {
            if (!pos.HasValue)
                pos = GetCursorPos();

            switch (button)
            {
                case 0:
                    Native.MouseEvent((int)MouseEventFlags.LEFTUP, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                case 1:
                    Native.MouseEvent((int)MouseEventFlags.RIGHTUP, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                case 2:
                    Native.MouseEvent((int)MouseEventFlags.MIDDLEUP, pos.Value.X, pos.Value.Y, 0, 0);
                    break;

                default:
                    break;
            }
        }
    }
}