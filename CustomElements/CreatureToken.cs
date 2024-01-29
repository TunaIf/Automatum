using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;
namespace Automatum.CustomElements
{
    public class CreatureToken: PictureBox
    {
        private static int diametr = RenderManager.tokenDiametr;
        private static int hexOffsetX = RenderManager.hexWidth / 4;
        private static int hexOffsetY = RenderManager.hexHeight / 4;

        public Creature creatureInstance;
        public string label;

        public CreatureToken(Creature creature)
        {
            this.creatureInstance = creature;

            this.BackColor = Color.White;
            this.Enabled = false;

            this.Width = RenderManager.hexWidth;
            this.Height = RenderManager.hexHeight;

            RenderManager.CreatureTokenDictionary.Add(creature, this);

            GameManager.onCreatureMove += RenderManager.RefreshCreatureTokenLocation;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath pathSurface = GetFigurePath(ClientRectangle))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            {
                this.Region = new Region(pathSurface);
                e.Graphics.DrawPath(penSurface, pathSurface);
            }

            e.Graphics.DrawString(label, new Font("Arial", 14), Brushes.Green, new Point(diametr/2, diametr/2));

        }
        private GraphicsPath GetFigurePath(Rectangle container)
        {
            GraphicsPath grPath = new GraphicsPath();

            grPath.AddEllipse(hexOffsetX, hexOffsetY, diametr, diametr);

            return grPath;
        }


    }
}
