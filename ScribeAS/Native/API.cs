using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scribe.Wrappers.Classes;

namespace Scribe.Native
{
    //Wrapper and API for Native functionality
    class API
    {
        public static IntPtr GetWindowHandleByTitle(string title)
        {
            IEnumerable<Process> processes = Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle));

            processes = processes.Where(x => x.MainWindowTitle == title);

            if (processes.Any())
                return processes.First().MainWindowHandle;

            return IntPtr.Zero;
        }

        public static void SetFocusWindow(string title)
        {
            IntPtr windowHandle = GetWindowHandleByTitle(title);

            if (windowHandle != IntPtr.Zero)
                Native.SetForegroundWindow(windowHandle);
        }

        public static string GetFocusWindow()
        {
            StringBuilder title = new StringBuilder();

            Native.GetWindowText(Native.GetForegroundWindow(), title, 256);

            return title.ToString();
        }

        public static Point GetWindowPos(string title)
        {
            WindowRect rect;

            Native.GetWindowRect(GetWindowHandleByTitle(title), out rect);

            return new Point() { X = rect.Left, Y = rect.Top };
        }

        public static void SetCursorPos(int x, int y)
        {
            Native.SetCursorPos(x, y);
        }

        public static Point GetCursorPos()
        {
            NativePoint point;

            Native.GetCursorPos(out point);

            return new Point() { X = point.X, Y = point.Y };
        }

        //KeyDown, KeyUp needed
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
    }
}