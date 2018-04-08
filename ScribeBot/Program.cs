using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ScribeBot
{
    /// <summary>
    /// One class to rule them all.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point for the program.
        /// </summary>
        /// <param name="args">Startup args</param>
        static void Main(string[] args)
        {
            Core.Initialize();
        }
    }
}
