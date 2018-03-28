using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Native
{
    //Wrapper and API for Native functionality
    class API
    {
        public static void SetFocusWindow(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);

            if (p.Count() > 0)
                Native.SetForegroundWindow(p[0].MainWindowHandle);
        }

        public static void SendKeyPress(VirtualKeyCode key)
        {
            SendKeyDown(key);
            SendKeyPress(key);
        }

        public static void SendKeyUp( VirtualKeyCode key )
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
                            VirtualKey = key,
                            Flags = KeyEventFlags.KEYUP
                        }
                    }
                }
            };

            Native.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        public static void SendKeyDown( VirtualKeyCode key )
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