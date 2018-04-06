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
    static class Scripter
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
            CurrentScript.Options.DebugPrint = value => Core.Write(Core.Colors["LightBlue"], value + "\n");
            CurrentScript.Options.CheckThreadAccess = false;

            //Wrappers/Classes
            CurrentScript.Globals["core"] = typeof(Wrappers.Core);
            CurrentScript.Globals["input"] = typeof(Wrappers.Input);
            CurrentScript.Globals["interface"] = typeof(Wrappers.Interface);

            //Enums
            UserData.RegisterType<Native.VirtualKeyCode>();
            CurrentScript.Globals["VirtualKeyCode"] = UserData.CreateStatic<Native.VirtualKeyCode>();

            //LuaFunc extensions
            CurrentScript.DoString(Wrappers.LuaExtensions.Wait);
            CurrentScript.DoString(Wrappers.LuaExtensions.PrintTable);
        }

        /// <summary>
        /// Execute a Lua file. Keep in mind that setting asynchronous to true might cause debugger to be unable to pass syntax errors properly.
        /// </summary>
        /// <param name="path">Path of file to execute.</param>
        /// <param name="asynchronous">Defines whether file should be executed on a thread different to ScribeBot itself.</param>
        public static void ExecuteFile(string path, bool asynchronous = true)
        {
            Core.WriteLine(Core.Colors["Yellow"], $"> Running {Path.GetFileName(path)}");

            try
            {
                if (asynchronous)
                    CurrentScript.DoFileAsync(path);
                else
                    CurrentScript.DoFile(path);
            }
            catch (Exception e)
            {
                Core.WriteLine(Core.Colors["Red"], $"[{Path.GetFileName(path)}] ERROR: {e.Message}");
            }
        }

        /// <summary>
        /// Execute a string of code. Keep in mind that setting asynchronous to true might cause debugger to be unable to pass syntax errors properly.
        /// </summary>
        /// <param name="code">String to execute.</param>
        /// <param name="asynchronous">Defines whether code should be executed on a thread different to ScribeBot itself.</param>
        public static void ExecuteString(string code, bool asynchronous = false)
        {
            Core.WriteLine(Core.Colors["Blue"], $"> {code}");

            try
            {
                if (asynchronous)
                    CurrentScript.DoStringAsync(code);
                else
                    CurrentScript.DoString(code);
            }
            catch (Exception e)
            {
                Core.WriteLine(Core.Colors["Red"], $"[Console] ERROR: {e.Message}");
            }
        }
    }
}
