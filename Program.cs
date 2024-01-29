using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatum
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameManager.player1.score = 12;
            GameManager.player2.score = 14;

            InitializeHexField();
            InitializeCreatures();

            Application.Run(new Form1());

            

        }

        private static void InitializeHexField()
        {
            int HexArrayIndex = 0;
            for (int i=0; i <= 4; i++)
            {
                for(int j = 0; j <= 4; j++)
                {
                    Vec3 cubeCoords = new Vec3(i, j);
                    if (cubeCoords.z <= -3 || cubeCoords.z >= 3) continue; 

                    Hex newHex = new Hex(cubeCoords);
                    CustomElements.HexButton newButton = new CustomElements.HexButton();
                    newButton.hex = newHex;
                    HexManager.HexArray2[i, j] = newHex;
                    RenderManager.HexButtonDictionary.Add(newHex, newButton);
                    HexManager.HexArray[HexArrayIndex] = newHex;
                    HexArrayIndex++;

                    if (i == 2 && j == 4) GameManager.player1.respawnHex = newHex;
                    if (i == 2 && j == 0) GameManager.player2.respawnHex = newHex;
                }
            }

        }
        private static void InitializeCreatures()
        {
            Creature charA1 = new Creature(HexManager.HexArray2[2, 4]);
            charA1.maxHealth = 2;
            charA1.health = charA1.maxHealth;
            GameManager.player1.creatures[0] = charA1;
            GameManager.player1.currentCreature = charA1;

            Creature charA2 = new Creature(HexManager.HexArray2[2, 4]);
            charA2.maxHealth = 2;
            charA2.health = charA2.maxHealth;
            GameManager.player1.creatures[1] = charA2;

            Creature charA3 = new Creature(HexManager.HexArray2[2, 4]);
            charA3.maxHealth = 2;
            charA3.health = charA3.maxHealth;
            GameManager.player1.creatures[2] = charA3;


            Creature charB1 = new Creature(HexManager.HexArray2[2, 0]);
            charB1.maxHealth = 2;
            charB1.health = charB1.maxHealth;
            GameManager.player2.creatures[0] = charB1;
            GameManager.player2.currentCreature = charB1;

            Creature charB2 = new Creature(HexManager.HexArray2[2, 0]);
            charB2.maxHealth = 2;
            charB2.health = charB2.maxHealth;
            GameManager.player2.creatures[1] = charB2;

            Creature charB3 = new Creature(HexManager.HexArray2[2, 0]);
            charB3.maxHealth = 2;
            charB3.health = charB3.maxHealth;
            GameManager.player2.creatures[2] = charB3;

        }
    }
}
