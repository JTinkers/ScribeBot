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
        /// <summary>
        /// Create an instance of AudioDevice proxy for a specified WaveOutEvent.
        /// </summary>
        /// <param name="attachment">WaveOutEvent to attach proxy to.</param>
        public AudioDeviceProxy(WaveOutEvent attachment) => OutputDevice = attachment;

        /// <summary>
        /// WaveOutEvent that AudioDeviceProxy is attached to.
        /// </summary>
        private WaveOutEvent OutputDevice { get; set; }

        /// <summary>
        /// AudioFileReader that AudioDeviceProxy utilises for file loading.
        /// </summary>
        private AudioFileReader FileReader { get; set; }

        /// <summary>
        /// Load sound file from harddrive or URL.
        /// </summary>
        /// <param name="path">Path or URL</param>
        public void Load(string path)
        {
            FileReader = new AudioFileReader(path);
            OutputDevice.Init(FileReader);
        }

        /// <summary>
        /// Play pre-loaded sound.
        /// </summary>
        public void Play() => OutputDevice.Play();

        /// <summary>
        /// Stop currently playing sound.
        /// </summary>
        public void Stop() => OutputDevice.Stop();

        /// <summary>
        /// Pause currently playing sound.
        /// </summary>
        public void Pause() => OutputDevice.Pause();

        /// <summary>
        /// Get volume of currently played sound.
        /// </summary>
        public float Volume => OutputDevice.Volume;

        /// <summary>
        /// Get current state of device.
        /// </summary>
        public int State => (int)OutputDevice.PlaybackState;
    }
}
