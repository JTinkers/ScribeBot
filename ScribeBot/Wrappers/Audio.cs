using MoonSharp.Interpreter;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribeBot.Wrappers.Proxies;
using NAudio.CoreAudioApi;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Wrapper containing NAudio's functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Audio
    {
        /// <summary>
        /// Create an instance of AudioDevice proxy that allows for loading and playing of sound files.
        /// </summary>
        /// <returns>Instance of AudioDevice proxy.</returns>
        public static AudioDevice CreateDevice()
        {
            return new AudioDevice(new WaveOutEvent());
        }

        /// <summary>
        /// Get names of audio devices.
        /// </summary>
        /// <returns>An array containing names of audio devices.</returns>
        public static string[] GetDeviceNames()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);

            return devices.Select(x => x.FriendlyName).ToArray();
        }

        /// <summary>
        /// Get the master peak level of an audio device.
        /// </summary>
        /// <param name="deviceName">User-friendly device name to check peak levels of.</param>
        /// <returns>Master peak level.</returns>
        public static int GetPeakValue(string deviceName)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);

            MMDevice device = devices.Where(x => x.FriendlyName == deviceName).First();
            return (int)Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
        }
    }
}
