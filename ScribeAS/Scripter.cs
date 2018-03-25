using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Scribe
{
    static class Scripter
    {
        public static void ExecuteFile(String path)
        {
            UserData.RegisterAssembly();

            Script.DefaultOptions.DebugPrint = value => Core.WriteLine(value);

            Script script = new Script();
            script.Globals["Core"] = new Wrappers.Core();

            try
            {
                script.DoFile(path);
            }
            catch (SyntaxErrorException e)
            {
                Core.WriteLine($"[{path}] ERROR: {e.Message}");
            }
        }
    }
}
