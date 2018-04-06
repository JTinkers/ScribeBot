using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Class containing all functions that can and should be implemented from Lua environment itself.
    /// </summary>
    static class LuaExtensions
    {
        /// <summary>
        /// String containing code for 'wait(time)' function; Wait until 'time' milliseconds have passed.
        /// </summary>
        public static string Wait =
        @"
            function wait(time)
                local callTime = os.clock() + (time/1000)
                repeat until os.clock() > callTime
            end
        ";

        public static string PrintTable =
        @"
            function table.print(t)
                print( '{\n' )
                for key, value in pairs(t) do
                    print(string.format('\t[%s] = %s\n', key, value))
                end
                print( '}' )
            end
        ";
    }
}
