using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    internal static class HexManager
    {
        public static Dictionary<Hex, CustomElements.HexButton> HexButtonDictionary = new Dictionary<Hex, CustomElements.HexButton>();
        public static Hex[] HexArray = new Hex[19];
        public static Hex[,] HexArray2 = new Hex[5, 5];

        public static LinkedList<Hex> GetHexesInRadius(Hex hex, int radius)
        {
            LinkedList<Hex> result = new LinkedList<Hex>();

            foreach(Hex hexInArray in HexArray)
            {
                if(hexInArray==hex) continue;
                if (cube_distance(hexInArray, hex) <= radius) result.AddLast(hexInArray);
            }

            return result;
        }

        public static LinkedList<Hex> GetHexesInLine(Hex hex, int length = 4)
        {
            LinkedList<Hex> result = new LinkedList<Hex>();

            Vec2 v2Base = hex.GetVec3().ToVec2();
            Vec2 v2 = new Vec2();
            for(int k = -length; k <= length; k++)
            {
                if(k==0)continue;

                v2 = v2Base;
                v2.i += k;
                if(v2.i >= 0 && v2.i <= 4)
                {
                    Hex foundHex = HexArray2[v2.i,v2.j];
                    if(foundHex != null) result.AddLast(foundHex);
                }

                v2.j += -k;
                if(v2.i >= 0 && v2.i <= 4 && v2.j >= 0 && v2.j <= 4)
                {
                    Hex foundHex = HexArray2[v2.i,v2.j];
                    if(foundHex != null) result.AddLast(foundHex);
                }

                v2.i += -k;
                if(v2.i >= 0 && v2.i <= 4 && v2.j >= 0 && v2.j <= 4)
                {
                    Hex foundHex = HexArray2[v2.i,v2.j];
                    if(foundHex != null) result.AddLast(foundHex);
                }

            }

            return result;
        }

        public static int cube_distance(Hex hex1, Hex hex2)
        {
            return (Math.Abs(hex1.x - hex2.x) + Math.Abs(hex1.y - hex2.y) + Math.Abs(hex1.z - hex2.z)) / 2;
        }

    }

}
