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
            function wait(time)
                local callTime = os.clock() + (time/1000)
                repeat until os.clock() > callTime
            end
        ";
    }
}
