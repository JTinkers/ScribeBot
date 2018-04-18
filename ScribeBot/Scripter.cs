using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using MoonSharp.Interpreter;
using System.Diagnostics;
using System.Drawing;

namespace ScribeBot
{
    /// <summary>
    /// Class creating and maintaining environment for Lua scripts.
    /// </summary>
    public static class Scripter
    {
        private static Script currentScript = new Script();

        /// <summary>
        /// Class instance containing MoonSharp scripting session.
        /// </summary>
        public static Script CurrentScript { get => currentScript; set => currentScript = value; }

        /// <summary>
        /// Static constructor initializing and sharing all vital functionality with Lua environment.
        /// </summary>
        static Scripter()
        {
            Script.WarmUp();

            UserData.RegisterAssembly();

            //Options
            CurrentScript.Options.DebugPrint = value => Core.Write(Core.Colors["Purple"], value + Environment.NewLine);
            CurrentScript.Options.CheckThreadAccess = false;

            //Wrappers
            CurrentScript.Globals["core"] = typeof(Wrappers.Core);
            CurrentScript.Globals["input"] = typeof(Wrappers.Input);
            CurrentScript.Globals["interface"] = typeof(Wrappers.Interface);
            CurrentScript.Globals["screen"] = typeof(Wrappers.Screen);

            //Proxies?
            CurrentScript.Globals["webDriver"] = typeof(Wrappers.Proxies.WebDriver);

            //Enums
            UserData.RegisterType<Native.VirtualKeyCode>();
            CurrentScript.Globals["VirtualKeyCode"] = UserData.CreateStatic<Native.VirtualKeyCode>();
        }

        /// <summary>
        /// Execute a string of code. Keep in mind that setting asynchronous to true might cause debugger to be unable to pass syntax errors properly.
        /// </summary>
        /// <param name="code">String to execute.</param>
        /// <param name="asynchronous">Defines whether code should be executed on a thread different to ScribeBot itself.</param>
        /// <param name="silent">Defines whether console shouldn't output the code. Only set to true when code is.</param>
        public static void ExecuteCode(string code, bool asynchronous = true, bool silent = true)
        {
            if( !silent )
                Core.WriteLine(Core.Colors["Green"], $"> {code}");

            try
            {
                if (asynchronous)
                    CurrentScript.DoStringAsync(code);
                else
                    CurrentScript.DoString(code);
            }
            catch (Exception e)
            {
                Core.WriteLine(Core.Colors["Red"], $"ERROR: {e.Message}");
            }
        }
    }
}
