using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MoonSharp.Interpreter;

namespace Scribe
{
    static class Scripter
    {
        private static Script currentScript = new Script();

        public static Script CurrentScript { get => currentScript; set => currentScript = value; }

        static Scripter()
        {
            UserData.RegisterAssembly();

            //Options
            CurrentScript.Options.DebugPrint = value => Core.WriteLine(value);

            //Wrappers/Classes
            CurrentScript.Globals["Core"] = typeof(Wrappers.Core);
            CurrentScript.Globals["Input"] = typeof(Wrappers.Input);

            //Enums
            UserData.RegisterType<Native.VirtualKeyCode>();
            CurrentScript.Globals["VirtualKeyCode"] = UserData.CreateStatic<Native.VirtualKeyCode>();

            //LuaFunc extensions
            CurrentScript.DoString(Wrappers.LuaExtensions.Wait);
        }

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
