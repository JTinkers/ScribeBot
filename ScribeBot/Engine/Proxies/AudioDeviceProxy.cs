using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using NAudio.Wave;

namespace ScribeBot.Engine.Proxies
{
    /// <summary>
    /// Proxy for NAudio's WaveOutEvent.
    /// </summary>
    [MoonSharpUserData]
    class AudioDeviceProxy
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader fileReader;

        /// <summary>
        /// Create an instance of AudioDevice proxy for a specified WaveOutEvent.
        /// </summary>
        /// <param name="attachment">WaveOutEvent to attach proxy to.</param>
        public AudioDeviceProxy(WaveOutEvent attachment) => outputDevice = attachment;

        /// <summary>
        /// Load sound file from harddrive or URL.
        /// </summary>
        /// <param name="path">Path or URL</param>
        public void Load(string path)
        {
            fileReader = new AudioFileReader(path);
            outputDevice.Init(fileReader);
        }

        /// <summary>
        /// Play pre-loaded sound.
        /// </summary>
        public void Play() => outputDevice.Play();

        /// <summary>
        /// Stop currently playing sound.
        /// </summary>
        public void Stop() => outputDevice.Stop();

        /// <summary>
        /// Pause currently playing sound.
        /// </summary>
        public void Pause() => outputDevice.Pause();

        /// <summary>
        /// Get volume of currently played sound.
        /// </summary>
        public float Volume => outputDevice.Volume;

        /// <summary>
        /// Get current state of device.
        /// </summary>
        public int State => (int)outputDevice.PlaybackState;
    }
}
