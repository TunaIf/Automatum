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

            InitializeHexField();
            Application.Run(new Form1());
        }

        private static void InitializeHexField()
        {
            for(int i=0; i <= 4; i++)
            {
                for(int j = 0; j <= 4; j++)
                {
                    Vec3 cubeCoords = new Vec3(i, j);
                    if (cubeCoords.z <= -3 || cubeCoords.z >= 3) continue;

                    Hex newHex = new Hex(cubeCoords);
                    HexManager.HexArray[i, j] = newHex;
                    HexManager.HexButtonsDictionary.Add(newHex, new CustomElements.HexButton());
                }
            }

        }
    }
}
