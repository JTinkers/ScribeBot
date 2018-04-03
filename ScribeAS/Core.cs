using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MoonSharp.Interpreter;
using Scribe.Interface;
using System.Diagnostics;

namespace Scribe
{
    /// <summary>
    /// Class containing core functionality.
    /// </summary>
    static class Core
    {
        private static string version = "0.1beta";

        /// <summary>
        /// Current version of Scribe.
        /// </summary>
        public static string Version { get => version; private set => version = value; }

        private static Thread interfaceThread;
        private static Window mainWindow;

        /// <summary>
        /// Thread on which WinForms class instances are ran.
        /// </summary>
        public static Thread InterfaceThread { get => interfaceThread; private set => interfaceThread = value; }

        /// <summary>
        /// The main frame for user interface.
        /// </summary>
        public static Window MainWindow { get => mainWindow; private set => mainWindow = value; }

        /// <summary>
        /// Creates user interface. TO-DO: Make it also load up config containing version info.
        /// </summary>
        public static void Initialize()
        {
            InterfaceThread = new Thread(() =>
            {
                Application.EnableVisualStyles();

                MainWindow = new Window();

                MainWindow.ConsoleSend.Click += (o, e) =>
                {
                    Scripter.ExecuteString(MainWindow.ConsoleInput.Text);
                    MainWindow.ConsoleInput.Text = "";
                };

                MainWindow.ConsoleInput.KeyPress += (o, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        MainWindow.ConsoleSend.PerformClick();
                        e.Handled = true;
                    }
                };

                MainWindow.ScriptRun.Click += (o, e) =>
                {
                    if( MainWindow.ScriptListBox.SelectedItem != null )
                        Scripter.ExecuteFile($@"{Application.StartupPath}\Data\Scripts\{MainWindow.ScriptListBox.SelectedItem}", MainWindow.AsyncCheckbox.Checked);
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
        /// Write a string of text.
        /// </summary>
        /// <param name="value"></param>
        public static void Write(String value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(value);
            }));
        }

        /// <summary>
        /// Write a string of text and append it with a linebreak.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteLine(String value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(value + "\n");
            }));
        }

        /// <summary>
        /// Get a path list of script files contained inside Data\Scripts\ folder.
        /// </summary>
        /// <returns></returns>
        public static string[] GetScriptPaths()
        {
            return Directory.GetFiles($@"{Application.StartupPath}\Data\Scripts\").Where(x => Path.GetExtension(x) == ".lua").ToArray();
        }
    }
}
