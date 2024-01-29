using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    internal static class HexManager
    {
        public static Hex[] HexArray = new Hex[19];
        public static Hex[,] HexArray2 = new Hex[5, 5];

        public static Dictionary<Hex, Creature> HexCreatureDictionary = new Dictionary<Hex, Creature>();


        public enum HexFilterType
        {
            AllHexes,
            Ally,
            Enemy,
            AllyAndEnemy,
            UnoccupiedHex
        }

        public static LinkedList<Hex> GetHexesInRadius_List(Hex hex, int radius, HexFilterType hexFilter = HexFilterType.AllHexes)
        {
            LinkedList<Hex> result = new LinkedList<Hex>();

            foreach(Hex hexInArray in HexArray)
            {
                if (hexInArray==hex) continue;
                if (cube_distance(hexInArray, hex) <= radius && ApplyFilter(hexInArray, hexFilter)) result.AddLast(hexInArray);
            }

            return result;
        }
        public static HashSet<Hex> GetHexesInRadius_HashSet(Hex hex, int radius, HexFilterType hexFilter = HexFilterType.AllHexes)
        {
            HashSet<Hex> result = new HashSet<Hex>();

            foreach (Hex hexInArray in HexArray)
            {
                if (hexInArray == hex) continue;
                if (cube_distance(hexInArray, hex) <= radius && ApplyFilter(hexInArray, hexFilter)) result.Add(hexInArray);
            }

            return result;
        }

        public static LinkedList<Hex> GetHexesInLine_list(Hex hex, int length = 4, HexFilterType hexFilter = HexFilterType.AllHexes)
        {
            LinkedList<Hex> result = new LinkedList<Hex>();

            Vec2 v2Base = hex.GetVec3().ToVec2();
            Vec2 v2 = new Vec2();
            for(int k = -length; k <= length; k++)
            {
                if(k==0)continue;

                Hex foundHex;
                v2 = v2Base;
                v2.i += k;
                if(v2.i >= 0 && v2.i <= 4)
                {
                    foundHex = HexArray2[v2.i,v2.j];
                    if(foundHex != null && ApplyFilter(foundHex, hexFilter)) result.AddLast(foundHex);
                }

                v2.j += -k;
                if(v2.i >= 0 && v2.i <= 4 && v2.j >= 0 && v2.j <= 4)
                {
                    foundHex = HexArray2[v2.i,v2.j];
                    if(foundHex != null && ApplyFilter(foundHex, hexFilter)) result.AddLast(foundHex);
                }

                v2.i += -k;
                if(v2.i >= 0 && v2.i <= 4 && v2.j >= 0 && v2.j <= 4)
                {
                    foundHex = HexArray2[v2.i,v2.j];
                    if(foundHex != null && ApplyFilter(foundHex, hexFilter)) result.AddLast(foundHex);
                }

            }

            return result;
        }

        public static int cube_distance(Hex hex1, Hex hex2)
        {
            return (Math.Abs(hex1.x - hex2.x) + Math.Abs(hex1.y - hex2.y) + Math.Abs(hex1.z - hex2.z)) / 2;
        }

        public static bool ApplyFilter(Hex hex, HexFilterType filter = HexFilterType.AllHexes)
        {
            bool result = false;

            switch (filter)
            {
                case HexFilterType.AllHexes:
                    result = true;
                    break;
                case HexFilterType.UnoccupiedHex:
                    result = !hex.isOccupied;
                    break;
                case HexFilterType.Ally:
                    foreach(Creature allyCreature in GameManager.currentPlayer.creatures)
                    {
                        if (allyCreature.hex == hex)
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case HexFilterType.Enemy:
                    foreach (Creature enemyCreature in GameManager.GetOpposingPlayer(GameManager.currentPlayer).creatures)
                    {
                        if (enemyCreature.hex == hex)
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case HexFilterType.AllyAndEnemy:
                    foreach (Creature allyCreature in GameManager.currentPlayer.creatures)
                    {
                        if (allyCreature.hex == hex)
                        {
                            result = true;
                            break;
                        }
                    }
                    if (!result)
                    {
                        foreach (Creature enemyCreature in GameManager.GetOpposingPlayer(GameManager.currentPlayer).creatures)
                        {
                            if (enemyCreature.hex == hex)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                    break;
            }

            return result;
        }
    }

}
