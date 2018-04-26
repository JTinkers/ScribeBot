using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using MoonSharp.Interpreter;
using System.Diagnostics;
using System.Threading.Tasks;
using ScribeBot.Wrappers.Types;

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

            Environment.Options.DebugPrint = value => Core.Write(new Color(0, 131, 63), value + System.Environment.NewLine);
            Environment.Options.CheckThreadAccess = true;

            Directory.GetFiles($@"Data\Extensions\", "*.lua").ToList().ForEach(x => Environment.DoFile(x));

            Environment.Globals["core"] = typeof(Wrappers.Core);
            Environment.Globals["input"] = typeof(Wrappers.Input);
            Environment.Globals["interface"] = typeof(Wrappers.Interface);
            Environment.Globals["screen"] = typeof(Wrappers.Screen);
            Environment.Globals["webdriver"] = typeof(Wrappers.Proxies.WebDriver);
        }

        /// <summary>
        /// Execute a string of code.
        /// </summary>
        /// <param name="code">String to execute.</param>
        /// <param name="silent">Defines whether console should hide code that's being executed.</param>
        public static void Execute(string code, bool silent = true)
        {
            if (!silent)
                Core.WriteLine(new Color(0, 131, 63), $"> {code}");

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
                    Core.WriteLine(new Color(177, 31, 41), $"Syntax Error: {exception.Message}");
                }
                catch (ScriptRuntimeException exception)
                {
                    Core.WriteLine(new Color(177, 31, 41), $"Runtime Error: {exception.Message}");
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
        public static void Stop()
        {
            //Crude, but effective.
            if (LuaThread != null && LuaThread.IsAlive)
                LuaThread.Abort();
        }

        /// <summary>
        /// Suspend Lua thread/environment.
        /// </summary>
        public static void Suspend()
        {
            if (LuaThread != null && LuaThread.IsAlive)
                Core.WriteLine($"{Thread.CurrentThread.Name} {LuaThread.Name}");
        }

        /// <summary>
        /// Resume Lua thread/environment.
        /// </summary>
        public static void Resume()
        {
            if (LuaThread != null && LuaThread.IsAlive)
                LuaThread.Resume();
        }

        /// <summary>
        /// Get whether Lua thread/environment is paused.
        /// </summary>
        /// <returns>Whether Lua thread is suspended.</returns>
        public static bool IsPaused() => LuaThread?.ThreadState == System.Threading.ThreadState.WaitSleepJoin;
    }
}
