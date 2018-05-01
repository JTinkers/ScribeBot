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

namespace ScribeBot
{
    /// <summary>
    /// Class containing core functionality.
    /// </summary>
    static class Core
    {
        private static string version = "0.6beta";
        private static double timeStarted = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        private static List<string> consoleInputQueue = new List<string>();
        private static Thread interfaceThread;
        private static Window mainWindow;
        private static PackageEditor editor = new PackageEditor();
        private static PrivateFontCollection fonts = new PrivateFontCollection();
        private static StringBuilder log = new StringBuilder();
        private static StreamWriter logStream = new StreamWriter($@"{Application.StartupPath}\Data\Logs\{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}.txt", true );

        /// <summary>
        /// Current version of ScribeBot.
        /// </summary>
        public static string Version { get => version; private set => version = value; }

        /// <summary>
        /// Timestamp of when ScribeBot was ran.
        /// </summary>
        public static double TimeStarted { get => timeStarted; set => timeStarted = value; }

        /// <summary>
        /// Thread on which WinForms class instances are ran.
        /// </summary>
        public static Thread InterfaceThread { get => interfaceThread; private set => interfaceThread = value; }

        /// <summary>
        /// The main frame for user interface.
        /// </summary>
        public static Window MainWindow { get => mainWindow; private set => mainWindow = value; }

        /// <summary>
        /// Container for all custom fonts used by the program.
        /// </summary>
        public static PrivateFontCollection Fonts { get => fonts; set => fonts = value; }

        /// <summary>
        /// Stream to a date-signed log file.
        /// </summary>
        public static StreamWriter LogStream { get => logStream; set => logStream = value; }

        /// <summary>
        /// Contains console output as a log.
        /// </summary>
        public static StringBuilder Log { get => log; set => log = value; }

        /// <summary>
        /// Built-in package editor.
        /// </summary>
        public static PackageEditor Editor { get => editor; set => editor = value; }

        /// <summary>
        /// Queue containing strings inputed via console for processing.
        /// </summary>
        public static List<string> ConsoleInputQueue { get => consoleInputQueue; set => consoleInputQueue = value; }

        /// <summary>
        /// Initializes object-based enumerations, loads fonts, opens user interface etc. basically anything that has to be done once the program starts.
        /// </summary>
        public static void Initialize()
        {
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
        /// Process lines of code entered via console.
        /// </summary>
        public static void ProcessConsoleInput()
        {
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
        public static void Write(String value)
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

            StringBuilder text = new StringBuilder();
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
        public static void WriteLine(String value)
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

            StringBuilder text = new StringBuilder();
            for (int i = 0; i < args.Length; i += 2)
            {
                text.Append(args[i + 1].ToString());
            }
            text.Append("\n");

            Log.Append(text);
        }
    }
}
