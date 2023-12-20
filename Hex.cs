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

        public Hex(Vec3 vec3)
        {
            x = vec3.x;
            y = vec3.y;
            z = vec3.z;
        }

        public Vec3 GetVec3()
        {
            return new Vec3(x, y, z);
        }
    }
}
