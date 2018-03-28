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
    static class Core
    {
        private static string version = "0.1beta";

        public static string Version { get => version; set => version = value; }

        private static Thread interfaceThread;
        private static Window mainWindow;

        public static Thread InterfaceThread { get => interfaceThread; private set => interfaceThread = value; }
        public static Window MainWindow { get => mainWindow; private set => mainWindow = value; }

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

        public static void Close()
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.Close();
            }));
        }

        public static void Write(String value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(value);
            }));
        }

        public static void WriteLine(String value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.ConsoleOutput.AppendText(value + "\n");
            }));
        }

        public static string[] GetScriptPaths()
        {
            return Directory.GetFiles($@"{Application.StartupPath}\Data\Scripts\").Where(x => Path.GetExtension(x) == ".lua").ToArray();
        }

        static public string[] GetWindowTitles()
        {
            return Process.GetProcesses().Where(x => !String.IsNullOrEmpty(x.MainWindowTitle)).Select(x => x.MainWindowTitle).ToArray();
        }
    }
}
