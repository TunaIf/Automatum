using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    public class Creature
    {
        public Hex hex;

        public bool hasMove;
        public bool hasAttack;

        public int health;
        public int maxHealth;

        public Creature(Hex hex)
        {
            this.hex = hex;

            this.hasAttack = true;
            this.hasMove = true;

        }

        public void Action_Move(Hex targetHex)
        {
            if (!hasMove || !hasAttack) return;
            hasMove = false;
            GameManager.MoveCreatureToHex(this, targetHex);

        }
        public void Action_Attack(Creature creature)
        {
            if (!hasMove || !hasAttack) return;
            hasAttack = false;

            GameManager.DealDamageToCreature(creature, GameManager.CalculateDamage(this, creature));
        }
    }
}
