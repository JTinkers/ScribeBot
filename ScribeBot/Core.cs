using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MoonSharp.Interpreter;
using ScribeBot.Interface;
using System.Diagnostics;
using System.Drawing.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using ScribeBot.Engine.Containers;
using Newtonsoft.Json;
using ScribeBot.Engine.Wrappers;

namespace ScribeBot
{
    /// <summary>
    /// Class containing core functionality.
    /// </summary>
    static class Core
    {
        public static string ReleaseAddress { get; private set; } = @"https://api.github.com/repos/jonekcode/ScribeBot/releases";

        /// <summary>
        /// Current version of ScribeBot.
        /// </summary>
        public static string Version { get; private set; }

        /// <summary>
        /// Timestamp of when ScribeBot was ran.
        /// </summary>
        public static double TimeStarted { get; set; } = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;

        /// <summary>
        /// Thread on which WinForms class instances are ran.
        /// </summary>
        public static Thread InterfaceThread { get; private set; }

        /// <summary>
        /// The main frame for user interface.
        /// </summary>
        public static Window MainWindow { get; private set; }

        /// <summary>
        /// Container for all custom fonts used by the program.
        /// </summary>
        public static PrivateFontCollection Fonts { get; set; } = new PrivateFontCollection();

        /// <summary>
        /// Stream to a date-signed log file.
        /// </summary>
        public static StreamWriter LogStream { get; set; } = new StreamWriter($@"{Application.StartupPath}\Data\Logs\{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}.txt", true);

        /// <summary>
        /// Contains console output as a log.
        /// </summary>
        public static StringBuilder Log { get; set; } = new StringBuilder();

        /// <summary>
        /// Built-in package editor.
        /// </summary>
        public static PackageEditor Editor { get; set; } = new PackageEditor();

        /// <summary>
        /// Queue containing strings inputed via console for processing.
        /// </summary>
        public static List<string> ConsoleInputQueue { get; set; } = new List<string>();

        /// <summary>
        /// Initializes object-based enumerations, loads fonts, opens user interface etc. basically anything that has to be done once the program starts.
        /// </summary>
        public static void Initialize()
        {
            var Info = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("info.json"));
            Version = Info["Version"];

            Fonts.AddFontFile($@"{Application.StartupPath}\Data\Fonts\OfficeCodePro-Medium.ttf");

            InterfaceThread = new Thread(() =>
            {
                Application.EnableVisualStyles();

                MainWindow = new Window();
                MainWindow.ShowDialog();
            })
            {
                Name = "Interface Thread"
            };
            InterfaceThread.Start();

            Scripter.Initialize();
        }

        /// <summary>
        /// Process console input sent while script was running.
        /// </summary>
        public static void ProcessConsoleInput()
        {
            if (Native.API.IsKeyDown(Native.VirtualKeyCode.PAUSE))
                Scripter.Stop();

            if (ConsoleInputQueue.Count > 0)
            {
                try
                {             
                    ConsoleInputQueue.ForEach(x =>
                    {
                        Scripter.Environment.DoString(x);
                    });

                    ConsoleInputQueue.Clear();
                }
                catch (SyntaxErrorException exception)
                {
                    WriteLine(new ColorContainer(177, 31, 41), $"Syntax Error: {exception.Message}");
                }
                catch (ScriptRuntimeException exception)
                {
                    WriteLine(new ColorContainer(177, 31, 41), $"Runtime Error: {exception.Message}");
                }
                catch (Exception exception)
                {
                    WriteLine(new ColorContainer(177, 31, 41), $"Error: {exception.Message}");
                }
            }
        }

        /// <summary>
        /// Close user interface and the program.
        /// </summary>
        public static void Close()
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.Close();
            }));
        }

        /// <summary>
        /// Dumps stored log into log file.
        /// </summary>
        public static void DumpLog()
        {
            Log.ToString().Split('\n').ToList().ForEach(x => LogStream.WriteLine(x));
            LogStream.Flush();
        }

        /// <summary>
        /// Write a string of text.
        /// </summary>
        /// <param name="value">String to write</param>
        public static void Write(string value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(value);
            }));

            Log.Append(value);
        }

        /// <summary>
        /// Write a multi-color string of text.
        /// </summary>
        /// <param name="args">Strings prepended by colors ex: Color.Red, "text", Color.Yellow, "text2".</param>
        public static void Write(params object[] args)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(args);
            }));

            var text = new StringBuilder();
            for (int i = 0; i < args.Length; i += 2)
            {
                text.Append((String)args[i + 1]);
            }

            Log.Append(text);
        }

        /// <summary>
        /// Write a string of text and append it with a linebreak.
        /// </summary>
        /// <param name="value">String to write</param>
        public static void WriteLine(string value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(value + Environment.NewLine);
            }));

            Log.Append(value + Environment.NewLine);
        }

        /// <summary>
        /// Write a multi-color string of text and append it with a linebreak.
        /// </summary>
        /// <param name="args">Strings prepended by colors ex: Color, "text", Color, "text2".</param>
        public static void WriteLine(params object[] args)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(args);
                MainWindow.ConsoleOutput.AppendText(Environment.NewLine);
            }));

            var text = new StringBuilder();
            for (int i = 0; i < args.Length; i += 2)
            {
                text.Append(args[i + 1].ToString());
            }
            text.Append(Environment.NewLine);

            Log.Append(text);
        }
    }
}
