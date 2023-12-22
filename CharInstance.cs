using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    public class CharInstance
    {
        public Hex hex;

        public CharInstance(Hex hex)
        {
            this.hex = hex;
        }

        public void Move(Hex targetHex)
        {
            if (targetHex == hex) return;

            hex = targetHex;
        }
    }
}
