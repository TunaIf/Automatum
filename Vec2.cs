using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    internal struct Vec2
    {
        public int i;
        public int j;

        public Vec2(int i, int j)
        {
            this.i = i;
            this.j = j;

        }

        public Vec3 ToVec3()
        {
            return new Vec3(i - 2, j - 2, 4 - i - j);
        }
    }
}
