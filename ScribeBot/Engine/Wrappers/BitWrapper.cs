using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribeBot.Engine.Wrappers
{
    [MoonSharpUserData]
    class BitWrapper
    {
        //&
        public static int BAnd(int a, int b) => a & b;

        //|
        public static int BOr(int a, int b) => a | b;

        //^
        public static int BXor(int a, int b) => a ^ b;

        //~
        public static int BFlip(int a) => ~a;

        //<<
        public static int BLShift(int a, int b) => a << b;

        //>>
        public static int BRShift(int a, int b) => a >> b;
    }
}
