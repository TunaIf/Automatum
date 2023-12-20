﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Automatum.CustomElements
{
    public class HexButton : Button
    {
        public HexButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }
        private GraphicsPath GetFigurePath(Rectangle container)
        {
            GraphicsPath grPath = new GraphicsPath();

            Point[] points = new Point[6];
            int half = container.Height / 2;
            int quart = container.Width / 4;
            points[0] = new Point(container.Left + quart, container.Top);
            points[1] = new Point(container.Right - quart, container.Top);
            points[2] = new Point(container.Right, container.Top + half);
            points[3] = new Point(container.Right - quart, container.Bottom);
            points[4] = new Point(container.Left + quart, container.Bottom);
            points[5] = new Point(container.Left, container.Top + half);

            grPath.AddPolygon(points);

            return grPath;
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
        }
    }
}
