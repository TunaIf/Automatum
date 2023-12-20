using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    internal class Hex
    {
        public int x;
        public int y;
        public int z;

        public bool isWater;
        public bool isForest;
        public bool isMountain;

        public bool isCastle;
        public bool isTower;
        public bool isControlZone;

        public bool isOccupied;

        
        public Hex(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
