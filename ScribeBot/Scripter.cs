using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using MoonSharp.Interpreter;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

namespace ScribeBot
{
    /// <summary>
    /// Class creating and maintaining environment for Lua scripts.
    /// </summary>
    public static class Scripter
    {
        private static Script environment = new Script();

        private static Thread luaThread;

        /// <summary>
        /// Class instance containing MoonSharp scripting session.
        /// </summary>
        public static Script Environment { get => environment; set => environment = value; }

        /// <summary>
        /// Thread scripts are executed on.
        /// </summary>
        public static Thread LuaThread { get => luaThread; set => luaThread = value; }

        /// <summary>
        /// Static constructor initializing and sharing all vital functionality with Lua environment.
        /// </summary>
        static Scripter()
        {
            Script.WarmUp();
            Script.GlobalOptions.RethrowExceptionNested = true;

            UserData.RegisterAssembly();

            Environment.Options.DebugPrint = value => Core.Write(Core.Colors["Purple"], value + System.Environment.NewLine);
            Environment.Options.CheckThreadAccess = true;

            Directory.GetFiles($@"Data\Extensions\", "*.lua").ToList().ForEach(x => Environment.DoFile(x));

            Environment.Globals["core"] = typeof(Wrappers.Core);
            Environment.Globals["input"] = typeof(Wrappers.Input);
            Environment.Globals["interface"] = typeof(Wrappers.Interface);
            Environment.Globals["screen"] = typeof(Wrappers.Screen);
            Environment.Globals["webDriver"] = typeof(Wrappers.Proxies.WebDriver);
        }

        /// <summary>
        /// Execute a string of code.
        /// </summary>
        /// <param name="code">String to execute.</param>
        /// <param name="silent">Defines whether console should hide code that's being executed.</param>
        public static void ExecuteCode(string code, bool silent = true)
        {
            if( !silent )
                Core.WriteLine(Core.Colors["Green"], $"> {code}");

            if (LuaThread != null && LuaThread.IsAlive)
                LuaThread.Abort();

            LuaThread = new Thread(() =>
            {
                try
                {
                    Environment.DoString($"{code}");
                }
                catch (SyntaxErrorException exception)
                {
                    Core.WriteLine(Core.Colors["Red"], exception.Message);
                }
            })
            {
                Name = "Lua Thread",
                IsBackground = true
            };
            LuaThread.Start();
        }

        /// <summary>
        /// Stop Lua thread, effectively killing all running scripts.
        /// </summary>
        public static void ForceStop()
        {
            //Crude, but effective.
            LuaThread.Abort();
        }
    }
}
