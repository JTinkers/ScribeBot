using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MoonSharp.Interpreter;

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
            CurrentScript.Options.DebugPrint = value => Core.WriteLine(value);

            //Wrappers/Classes
            CurrentScript.Globals["Core"] = typeof(Wrappers.Core);
            CurrentScript.Globals["Input"] = typeof(Wrappers.Input);
            CurrentScript.Globals["Interface"] = typeof(Wrappers.Interface);

            //Enums
            UserData.RegisterType<Native.VirtualKeyCode>();
            CurrentScript.Globals["VirtualKeyCode"] = UserData.CreateStatic<Native.VirtualKeyCode>();

            //LuaFunc extensions
            CurrentScript.DoString(Wrappers.LuaExtensions.Wait);
        }

        /// <summary>
        /// Execute a Lua file. Keep in mind that setting asynchronous to true might cause debugger to be unable to pass syntax errors properly.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="asynchronous"></param>
        public static void ExecuteFile(string path, bool asynchronous = true)
        {
            if (asynchronous)
            {
                CurrentScript.DoFileAsync(path);
            }
            else
            {
                try
                {
                    CurrentScript.DoFile(path);
                }
                catch (SyntaxErrorException e)
                {
                    Core.WriteLine($"[{Path.GetFileName(path)}] ERROR: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Execute a string of Lua code on the currently running script. If script is no longer running - the code will still be able to access variables, functions etc.
        /// </summary>
        /// <param name="code"></param>
        public static void ExecuteString(string code)
        {
            try
            {
                CurrentScript?.DoString(code); //Cannot enter the same MoonSharp processor from two different threads : 5 and 3
            }
            catch (SyntaxErrorException e)
            {
                Core.WriteLine($"[Console] ERROR: {e.Message}");
            }
        }
    }
}
