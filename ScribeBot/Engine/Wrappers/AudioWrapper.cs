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
        C0 = 46,
        D0 = 48,
        E0 = 50,
        F0 = 51,
        G0 = 54,
        A0 = 57,
        B0 = 60,
        C1 = 62,
        D1 = 66,
        E1 = 71,
        F1 = 73,
        G1 = 79,
        A1 = 85,
        B1 = 91,
        C2 = 95,
        D2 = 103,
        E2 = 112,
        F2 = 117,
        G2 = 128,
        A2 = 140,
        B2 = 153,
        C3 = 160,
        D3 = 176,
        E3 = 194,
        F3 = 204,
        G3 = 226,
        A3 = 250,
        B3 = 276,
        C4 = 281,
        D4 = 323,
        E4 = 359,
        F4 = 379,
        G4 = 422,
        A4 = 470,
        B4 = 523,
        C5 = 553,
        D5 = 617,
        E5 = 689,
        F5 = 728,
        G5 = 813,
        A5 = 910,
        B5 = 1017,
        C6 = 1076,
        D6 = 1204,
        E6 = 1348,
        F6 = 1426,
        G6 = 1597,
        A6 = 1790,
        B6 = 2005,
        C7 = 2123,
        D7 = 2379,
        E7 = 2667,
        F7 = 2823,
        G7 = 3185,
        A7 = 3550,
        B7 = 3981,
        C8 = 4216,
        D8 = 4728,
        E8 = 5304,
        F8 = 5617,
        G8 = 6301,
        A8 = 7070,
        B8 = 7932
    }
}
