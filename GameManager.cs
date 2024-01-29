using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatum
{
    internal static class GameManager
    {

        public static Player player1 = new Player("Player 1");
        public static Player player2 = new Player("Player 2");

        public static Player currentPlayer = player1;

        public delegate void MethodContainer();
        public static event MethodContainer onCurrentPlayerChange;
        public static event MethodContainer onCreatureAttack;
        public static event MethodContainer onScoreChange;


        public delegate void MethodContainerCreature(Creature creature);
        public static event MethodContainerCreature onCreatureMove;
        public static event MethodContainerCreature onCreatureDeath;



        public static void ChangeCurrentPlayer()
        {
            currentPlayer = currentPlayer == player1 ? player2 : player1;

            foreach(Creature creature in currentPlayer.creatures)
            {
                creature.hasMove = true;
                creature.hasAttack = true;
            }

            if (onCurrentPlayerChange != null) onCurrentPlayerChange();
        }

        public static void MoveCreatureToHex(Creature creature, Hex hex)
        {
            if (creature.hex == hex) return;

            HexManager.HexCreatureDictionary[creature.hex] = null;

            creature.hex.isOccupied = false;
            creature.hex = hex;
            creature.hex.isOccupied = true;

            HexManager.HexCreatureDictionary[hex] = creature;

            if (onCreatureMove != null) onCreatureMove(creature);

        }

        public static void DealDamageToCreature(Creature creature, int damage)
        {
            creature.health -= damage;

            if (onCreatureAttack != null) onCreatureAttack();


            if (creature.health <= 0)
            {
                creature.health = creature.maxHealth;
                MoveCreatureToHex(creature, GetOpposingPlayer(currentPlayer).respawnHex);

                if (onCreatureDeath != null) onCreatureDeath(creature);

                GetOpposingPlayer(currentPlayer).score -= 1;
                if (onScoreChange != null) onScoreChange();
            }
        }

        public static int CalculateDamage(Creature dealer, Creature receiver)
        {
            return 1;
        }

        public static Player GetOpposingPlayer(Player player)
        {
            if (player == player1)
            {
                return player2;
            }

            if(player== player2)
            {
                return player1;
            }

            return player1;
        }

    }
}
