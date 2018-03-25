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
        public static void ExecuteFile(String path, bool asynchronous = true)
        {
            UserData.RegisterAssembly();

            Script.DefaultOptions.DebugPrint = value => Core.WriteLine(value);

            Script script = new Script();
            script.Globals["Core"] = new Wrappers.Core();

            if (asynchronous)
            {
                script.DoFileAsync(path);
            }
            else
            {
                try
                {
                    script.DoFile(path);
                }
                catch (SyntaxErrorException e)
                {
                    Core.WriteLine($"[{Path.GetFileName(path)}] ERROR: {e.Message}");
                }
            }
        }
    }
}
