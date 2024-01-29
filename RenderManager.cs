using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    public static class RenderManager
    {
        public static int hexWidth = 60;
        public static int hexHeight = 50;

        public static int tokenDiametr = 30;

        public static Dictionary<Creature, CustomElements.CreatureToken> CreatureTokenDictionary = new Dictionary<Creature, CustomElements.CreatureToken>();

        public static Dictionary<Hex, CustomElements.HexButton> HexButtonDictionary = new Dictionary<Hex, CustomElements.HexButton>();
        public static void RefreshCreatureTokenLocation(Creature creature)
        {
            CreatureTokenDictionary[creature].Location = HexButtonDictionary[creature.hex].Location;
        }

    }
}
