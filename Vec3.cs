using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    public struct Vec3
    {
        public int x;
        public int y;
        public int z;

        public Vec3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }
        public Vec3(int i, int j)
        {
            this.x = i - 2;
            this.y = j - 2;
            this.z = 4 - i - j;
        }

        public Vec2 ToVec2()
        {
            return new Vec2(x + 2, y + 2);
        }
    }
}
