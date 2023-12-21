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
        public Hex hex;
        public HexButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;

            //this.Click += new EventHandler(HexButton_Click);
            this.MouseDown += new MouseEventHandler(OnMouseDown);
            this.MouseUp += new MouseEventHandler(OnMouseUp);

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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        public void SetState(int state)
        {
            switch (state)
            {
                case 1:
                    this.BackColor = Color.MediumPurple;
                    break;
                case 2:
                    this.BackColor = Color.MediumSlateBlue;
                    break;             
            }
        }

        private void OnMouseDown(object sender, EventArgs e)
        {
            foreach(Hex hexInRaduis in HexManager.GetHexesInRadius(this.hex, 1))
            {
                HexButton buttonInRadius;
                if(HexManager.HexButtonDictionary.TryGetValue(hexInRaduis, out buttonInRadius))
                {
                    buttonInRadius.SetState(1);
                }
            }
        }
        private void OnMouseUp(object sender, EventArgs e)
        {
            foreach (Hex hexInRaduis in HexManager.GetHexesInRadius(this.hex, 1))
            {
                HexButton buttonInRadius;
                if (HexManager.HexButtonDictionary.TryGetValue(hexInRaduis, out buttonInRadius))
                {
                    buttonInRadius.SetState(2);
                }
            }
        }

        //private void HexButton_MouseDown(object sender, MouseEventArgs e)
        //{
        //    this.BackColor = Color.LightYellow;
        //    this.Text = "lel";
        //}

        //private void HexButton_MouseUp(object sender, MouseEventArgs e)
        //{
        //    this.BackColor = Color.MediumSlateBlue;
        //}

        //private void HexButton_Click(object sender, EventArgs e)
        //{
        //    this.Text = "t";
        //}
    }
}
