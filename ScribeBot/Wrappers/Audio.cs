using MoonSharp.Interpreter;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribeBot.Wrappers.Proxies;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Wrapper containing NAudio's functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Audio
    {
        public static AudioDevice CreateDevice()
        {
            return new AudioDevice(new WaveOutEvent());
        }
    }
}
