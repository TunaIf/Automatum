using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    public class Player
    {
        public string name;
        public Creature[] creatures;
        public int score;

        public Creature currentCreature;

        public Hex respawnHex;

        public Player(string name)
        {
            this.name = name;
            this.creatures = new Creature[3];
        }
    }
}
