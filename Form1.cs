using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatum
{
    public partial class Form1 : Form
    {

        private static int hexWidth = 60;
        private static int hexHeight = 50;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Size hexSize = new Size(hexWidth, hexHeight);

            int center_x = 270;
            int center_y = 170;

            double sin30 = 0.5;
            double cos30 = Math.Sqrt(3) / 2;

            double sin60 = cos30;
            double cos60 = sin30;

            int gapWidth = 5;

            foreach(KeyValuePair<Hex, CustomElements.HexButton> kvp in HexManager.HexButtonDictionary)
            {
                Vec3 cubeCoords = kvp.Key.GetVec3();
                CustomElements.HexButton hexButton = kvp.Value;

                this.Controls.Add(hexButton);
                hexButton.Location = new Point(
                            center_x + ((hexSize.Width) * cubeCoords.x - (int)(((double)((hexSize.Width + gapWidth) * cubeCoords.y + (hexSize.Width + gapWidth) * cubeCoords.z)) * sin30)) / 2
                            , center_y + ((int)(((double)(hexSize.Height + gapWidth) * cubeCoords.y - (hexSize.Height + gapWidth) * cubeCoords.z) * cos30)) * 5 / 9
                            );
                hexButton.Size = hexSize;
                hexButton.Text = cubeCoords.x + ", " + cubeCoords.y + ", " + cubeCoords.z;
            }



        }

        
    }
}
