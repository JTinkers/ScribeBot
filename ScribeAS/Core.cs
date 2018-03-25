using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scribe.Interface;
using MoonSharp.Interpreter;

namespace Scribe
{
    static class Core
    {
        private static Thread interfaceThread;
        private static Window mainWindow;

        public static Thread InterfaceThread { get => interfaceThread; private set => interfaceThread = value; }
        public static Window MainWindow { get => mainWindow; private set => mainWindow = value; }

        public static void Initialize()
        {
            InterfaceThread = new Thread(() =>
            {
                MainWindow = new Window();
                MainWindow.ShowDialog();
            });
            InterfaceThread.Name = "Interface Thread";
            InterfaceThread.Start();
        }

        public static void Write(String value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.Output.AppendText(value);
            }));
        }

        public static void WriteLine(String value)
        {
            MainWindow?.Invoke(new Action(() =>
            {
                MainWindow.Output.AppendText(value + "\n");
            }));
        }
    }
}
