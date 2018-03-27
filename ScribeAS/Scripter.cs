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
        private static Script currentScript;

        public static void ExecuteFile(string path, bool asynchronous = true)
        {
            UserData.RegisterAssembly();
            Script.DefaultOptions.DebugPrint = value => Core.WriteLine(value);

            currentScript = new Script();
            currentScript.Globals["Core"] = new Wrappers.Core();

            if (asynchronous)
            {
                currentScript.DoFileAsync(path);
            }
            else
            {
                try
                {
                    currentScript.DoFile(path);
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
                currentScript?.DoString(code); //Cannot enter the same MoonSharp processor from two different threads : 5 and 3
            }
            catch (SyntaxErrorException e)
            {
                Core.WriteLine($"[Console] ERROR: {e.Message}");
            }
        }
    }
}
