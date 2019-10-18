using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturallySpawner
{
    internal static class Debug
    {
        static Debug()
        {
            IsDebug = false;
        }

        public static bool IsDebug { get; set; }
    }
}
