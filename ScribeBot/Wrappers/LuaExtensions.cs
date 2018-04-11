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
        public static string Code =
        @"
            function wait(time)
                local callTime = os.clock() + (time/1000)
                repeat until os.clock() > callTime
            end

            function table.print(t)
                print( '{' )
                for key, value in pairs(t) do
                    print(string.format('\t%-20s= %s', tostring(key), tostring(value)))
                end
                print( '}' )
            end
        ";
    }
}
