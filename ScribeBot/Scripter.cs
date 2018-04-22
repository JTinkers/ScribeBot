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
        private static Script environment = new Script();

        /// <summary>
        /// Class instance containing MoonSharp scripting session.
        /// </summary>
        public static Script Environment { get => environment; set => environment = value; }

        /// <summary>
        /// Static constructor initializing and sharing all vital functionality with Lua environment.
        /// </summary>
        static Scripter()
        {
            Script.WarmUp();
            Script.GlobalOptions.RethrowExceptionNested = true;

            UserData.RegisterAssembly();

            Environment.Options.DebugPrint = value => Core.Write(Core.Colors["Purple"], value + System.Environment.NewLine);
            Environment.Options.CheckThreadAccess = false;

            Directory.GetFiles($@"Data\Extensions\", "*.lua").ToList().ForEach(x => Environment.DoFile(x));

            Environment.Globals["core"] = typeof(Wrappers.Core);
            Environment.Globals["input"] = typeof(Wrappers.Input);
            Environment.Globals["interface"] = typeof(Wrappers.Interface);
            Environment.Globals["screen"] = typeof(Wrappers.Screen);
            Environment.Globals["webDriver"] = typeof(Wrappers.Proxies.WebDriver);
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

            //A clumsy way of getting the syntax errors properly shown
            //Will change this later
            try
            {
                if (asynchronous)
                    Environment.DoStringAsync(code);
                else
                    Environment.DoString(code);
            }
            catch (Exception e)
            {
                Core.WriteLine(Core.Colors["Red"], $"ERROR: {e.Message}");
            }
        }
    }
}
