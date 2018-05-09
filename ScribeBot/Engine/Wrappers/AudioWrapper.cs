using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using MoonSharp.Interpreter;
using ScribeBot.Engine.Proxies;
using System.Threading;

namespace ScribeBot.Engine.Wrappers
{
    /// <summary>
    /// Wrapper containing NAudio's functionality exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class AudioWrapper
    {
        /// <summary>
        /// Play a musical note for given duration
        /// </summary>
        /// <param name="i">Frequency provided by NoteFrequencies enum.</param>
        /// <param name="duration">Time in milliseconds to play sound for.</param>
        public static void PlayNote(NoteFrequencies i, int duration)
        {
            Console.Beep((int)i, duration);
        }

        /// <summary>
        /// Create an instance of AudioDevice proxy that allows for loading and playing of sound files.
        /// </summary>
        /// <returns>Instance of AudioDevice proxy.</returns>
        public static AudioDeviceProxy CreateDevice()
        {
            return new AudioDeviceProxy(new WaveOutEvent());
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

    /// <summary>
    /// Enum containing most musical note frequencies used by Console.Beep
    /// </summary>
    public enum NoteFrequencies : int
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C0 = 46,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D0 = 48,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E0 = 50,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F0 = 51,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G0 = 54,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A0 = 57,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B0 = 60,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C1 = 62,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D1 = 66,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E1 = 71,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F1 = 73,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G1 = 79,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A1 = 85,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B1 = 91,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C2 = 95,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D2 = 103,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E2 = 112,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F2 = 117,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G2 = 128,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A2 = 140,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B2 = 153,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C3 = 160,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D3 = 176,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E3 = 194,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F3 = 204,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G3 = 226,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A3 = 250,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B3 = 276,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C4 = 281,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D4 = 323,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E4 = 359,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F4 = 379,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G4 = 422,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A4 = 470,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B4 = 523,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C5 = 553,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D5 = 617,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E5 = 689,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F5 = 728,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G5 = 813,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A5 = 910,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B5 = 1017,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C6 = 1076,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D6 = 1204,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E6 = 1348,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F6 = 1426,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G6 = 1597,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A6 = 1790,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B6 = 2005,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C7 = 2123,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D7 = 2379,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E7 = 2667,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F7 = 2823,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G7 = 3185,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A7 = 3550,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B7 = 3981,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        C8 = 4216,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        D8 = 4728,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        E8 = 5304,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        F8 = 5617,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        G8 = 6301,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        A8 = 7070,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        B8 = 7932
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
