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

           
            Vec2 v2 = new Vec2();

            for (int x=-radius; x<=radius; x++)
            {

                Vec3 v3 = hex.GetVec3();
                v3.x += x;
                v2 = v3.ToVec2();

                if (v2.i < 0 || v2.i > 4 || v2.j < 0 || v2.j > 4) continue;

                Hex foundHex = HexArray2[v2.i, v2.j];

                if(foundHex != null) result.AddLast(foundHex);
            }

            return result;
        }

    }

}
