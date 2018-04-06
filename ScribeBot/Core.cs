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
using System.Drawing;
using System.Drawing.Text;

namespace ScribeBot
{
    /// <summary>
    /// Class containing core functionality.
    /// </summary>
    static class Core
    {
        private static string version = "0.1beta";
        private static Thread interfaceThread;
        private static Window mainWindow;
        private static PrivateFontCollection fonts;
        private static Dictionary<string, Color> colors = new Dictionary<string, Color>();
        private static StringBuilder log = new StringBuilder();
        private static StreamWriter logStream = new StreamWriter($@"{Application.StartupPath}\Data\Logs\{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}.txt", true );

        /// <summary>
        /// Current version of ScribeBot.
        /// </summary>
        public static string Version { get => version; private set => version = value; }

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
        /// Container for all custom colors used by the program.
        /// </summary>
        public static Dictionary<string, Color> Colors { get => colors; set => colors = value; }

        /// <summary>
        /// Stream to a date-signed log file.
        /// </summary>
        public static StreamWriter LogStream { get => logStream; set => logStream = value; }

        /// <summary>
        /// Contains console output as a log.
        /// </summary>
        public static StringBuilder Log { get => log; set => log = value; }

        /// <summary>
        /// Creates user interface. TO-DO: Make it also load up config containing version info.
        /// </summary>
        public static void Initialize()
        {
            Colors["Red"] = Color.FromArgb(231, 127, 103);
            Colors["Blue"] = Color.FromArgb(119, 139, 235);
            Colors["LightBlue"] = Color.FromArgb(99, 205, 218);
            Colors["Yellow"] = Color.FromArgb(247, 215, 148);

            fonts = new PrivateFontCollection();
            fonts.AddFontFile($@"{Application.StartupPath}\Data\Fonts\OfficeCodePro-Medium.ttf");

            InterfaceThread = new Thread(() =>
            {
                Application.EnableVisualStyles();

                MainWindow = new Window();

                MainWindow.ConsoleOutput.Font = new Font(fonts.Families[0], 10f );

                MainWindow.ConsoleRun.Click += (o, e) =>
                {
                    Scripter.ExecuteString(MainWindow.ConsoleInput.Text, MainWindow.AsyncStringCheck.Checked);
                    MainWindow.ConsoleInput.Text = "";
                };

                MainWindow.ConsoleInput.KeyPress += (o, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        MainWindow.ConsoleRun.PerformClick();
                        e.Handled = true;
                    }
                };

                MainWindow.ScriptRun.Click += (o, e) =>
                {
                    if( MainWindow.ScriptListBox.SelectedItem != null )
                        Scripter.ExecuteFile($@"{Application.StartupPath}\Data\Scripts\{MainWindow.ScriptListBox.SelectedItem}", MainWindow.AsyncCheckbox.Checked);
                };

                MainWindow.ScriptStop.Click += (o, e) =>
                {
                    Scripter.CurrentScript.DoStringAsync("lua_pcall( L, 0, LUA_MULTRET, 0 )");
                };

                MainWindow.ConsoleOutput.TextChanged += (o, e) =>
                {
                    MainWindow.ConsoleOutput.ScrollToCaret();
                };

                MainWindow.FormClosing += (o, e) =>
                {
                    DumpLog();
                };

                GetScriptPaths().ToList().ForEach(x => MainWindow.ScriptListBox.Items.Add(Path.GetFileName(x)));

                MainWindow.ShowDialog();
            });
            InterfaceThread.Name = "Interface Thread";
            InterfaceThread.Start();
        }

        /// <summary>
        /// Close user interface.
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
        private static void DumpLog()
        {
            if (MainWindow.LogCheckBox.Checked)
            {
                Log.ToString().Split('\n').ToList().ForEach(x => LogStream.WriteLineAsync(x));
                LogStream.Flush();
            }
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
        /// <param name="args">Strings prepended by colors ex: Color.Red, "text", Color.Yellow, "text2".</param>
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
                text.Append((String)args[i + 1]);
            }
            text.Append("\n");

            Log.Append(text);
        }

        /// <summary>
        /// Get a path list of script files contained inside Data\Scripts\ folder.
        /// </summary>
        /// <returns>A path list of script files contained inside Data\Scripts\ folder.</returns>
        public static string[] GetScriptPaths()
        {
            return Directory.GetFiles($@"{Application.StartupPath}\Data\Scripts\").Where(x => Path.GetExtension(x) == ".lua").ToArray();
        }
    }
}
