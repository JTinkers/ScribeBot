using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Wrappers
{
    static class LuaExtensions
    {
        public static string Wait =
        @"
            function wait(t)
                local callTime = os.clock() + (t/1000)
                repeat until os.clock() > callTime
            end
        ";
    }
}
