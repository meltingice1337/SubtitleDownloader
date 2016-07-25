using System;
using System.Collections.Generic;
using System.Text;

namespace SubtitleDownloader
{
    class NativeMethodsHelper
    {
        public static int MakeLong(int wLow, int wHigh)
        {
            var low = (int)IntLoWord(wLow);
            short high = IntLoWord(wHigh);
            var product = 0x10000 * (int)high;
            var mkLong = (int)(low | product);
            return mkLong;
        }

        private static short IntLoWord(int word)
        {
            return (short)(word & short.MaxValue);
        }
    }
}
