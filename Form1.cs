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

            for(int x=-2; x<= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    for (int z = -2; z <= 2; z++)
                    {
                        if (x + y + z != 0) continue;

                        CustomElements.HexButton newButton = InsertButton(new Point(
                            center_x + ((hexSize.Width ) * x - (int)(((double)((hexSize.Width + gapWidth) * y + (hexSize.Width + gapWidth) * z)) * sin30)) /2
                            , center_y + ((int)(((double)(hexSize.Height + gapWidth) * y - (hexSize.Height + gapWidth) * z) * cos30)) *5/9
                            ), hexSize);

                        newButton.Text = x + ", " + y + ", " + z;
                    }
                }
            }




        }

        private CustomElements.HexButton InsertButton(Point locationPoint, Size size)
        {
            CustomElements.HexButton newButton = new CustomElements.HexButton();

            this.Controls.Add(newButton);

            newButton.Location = locationPoint;
            newButton.Size = size;

            return newButton;
        }
    }
}
