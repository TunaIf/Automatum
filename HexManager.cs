using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    internal static class HexManager
    {
        public static Dictionary<Hex, CustomElements.HexButton> HexButtonsDictionary = new Dictionary<Hex, CustomElements.HexButton>();
        public static Hex[,] HexArray = new Hex[5, 5];

    }
}
