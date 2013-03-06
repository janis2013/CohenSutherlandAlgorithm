using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using Cohen_Sutherland._2DObject;

namespace Cohen_Sutherland.GraphicCores
{

    /// <summary>
    /// The Graphics Core. Provides simple graphic operations.
    /// </summary>
    public partial class GraphicCore
    {
        #region [ Fields ]


        /// <summary>
        /// The drawing Area (to calculate Positons (height - x))
        /// </summary>
        public readonly PictureBox Parent;

        /// <summary>
        /// The Graphic.
        /// </summary>
        public Graphics g { get; private set; }


        /// <summary>
        /// The picture.
        /// </summary>
        private Bitmap Image;



        #endregion


        /// <summary>
        /// Creats a new Graphcis Core.
        /// </summary>
        /// <param name="box"></param>
        public GraphicCore(PictureBox box)
        {
            this.Parent = box;

        }


        #region [ drawing methods ]

        /// <summary>
        /// Starts a new image.
        /// </summary>
        public void StartImage()
        {
            this.Image = new Bitmap(this.Parent.Width, this.Parent.Height);
            this.g = Graphics.FromImage(this.Image);
            this.g.Clear(Color.White);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        /// <summary>
        /// Returns the drawn image;
        /// </summary>
        /// <returns></returns>
        public Bitmap EndImage()
        {
            return Image;

        }

        /// <summary>
        /// Fills a ellipse.
        /// </summary>
        /// <param name="g">The Graphic.</param>
        /// <param name="brush">The fill color.</param>
        /// <param name="x">The X koordinate.</param>
        /// <param name="y">The Y koordinate.</param>
        /// <param name="width">The width of the ellipse.</param>
        /// <param name="height">The height of the ellipse.</param>
        public void FillEllipse(SolidBrush brush, float x, float y, float width, float height)
        {
            this.g.FillEllipse(brush, x - (width / 2), Parent.Height - (y + (height / 2)), width, height);
        }

        /// <summary>
        /// Fills a ellipse.
        /// </summary>
        /// <param name="g">The Graphic.</param>
        /// <param name="brush">The fill color.</param>
        /// <param name="point">The koordinates as point.</param>
        /// <param name="width">The width of the ellipse.</param>
        /// <param name="height">The height of the ellipse.</param>
        public void FillEllipse(SolidBrush brush, Vector point, float width, float height)
        {
            this.g.FillEllipse(brush, point.X - (width / 2), Parent.Height - (point.Y + (height / 2)), width, height);
            
        }

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="g">The Graphic.</param>
        /// <param name="pen">The line color.</param>
        /// <param name="v1">The start point.</param>
        /// <param name="v2">The end point.</param>
        public void DrawLine(Pen pen, Vector v1, Vector v2)
        {
            this.g.DrawLine(pen, v1.X, Parent.Height - v1.Y, v2.X, Parent.Height - v2.Y);

        }

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="pen">The line color.</param>
        /// <param name="vectors">The vectors of the line.</param>
        public void DrawLine(Pen pen, params Vector[] vectors)
        {
            if (vectors.Length > 1)
            {
                this.DrawLine(pen, vectors[0], vectors[1]);
            }

        }


        /// <summary>
        /// Draws a triangle.
        /// </summary>
        /// <param name="pen">The line color.</param>
        /// <param name="vectors">The vectors.</param>
        public void DrawTriangle(Pen pen, params Vector[] vectors)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                if (i == vectors.Length - 1)
                {
                    this.DrawLine(pen, vectors[i], vectors[0]);
                }
                else
                {
                    this.DrawLine(pen, vectors[i], vectors[i + 1]);
                }
            }

        }


        /// <summary>
        /// Draw Cohen sutherland stuff (caption).
        /// </summary>
        /// <param name="ClippingWindow">The clipping window.</param>
        public void DrawCaption(myRectangle ClippingWindow)
        {
            //draw lines

            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v2.X, Parent.Height - ClippingWindow.v2.Y, ClippingWindow.v2.X, 0);
            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v2.X, Parent.Height - ClippingWindow.v2.Y, Parent.Width, Parent.Height - ClippingWindow.v2.Y);

            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v3.X, Parent.Height - ClippingWindow.v3.Y, Parent.Width, Parent.Height - ClippingWindow.v3.Y);
            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v3.X, Parent.Height - ClippingWindow.v3.Y, ClippingWindow.v3.X, Parent.Height);

            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v4.X, Parent.Height - ClippingWindow.v4.Y, 0, Parent.Height - ClippingWindow.v4.Y);
            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v4.X, Parent.Height - ClippingWindow.v4.Y, ClippingWindow.v4.X, Parent.Height);

            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v1.X, Parent.Height - ClippingWindow.v1.Y, ClippingWindow.v1.X, 0);
            g.DrawLine(GraphicCore.Cohen_Sutherland_LinesColor, ClippingWindow.v1.X, Parent.Height - ClippingWindow.v1.Y, 0, Parent.Height - ClippingWindow.v1.Y);


            //top
            PointF p1001 = new PointF((ClippingWindow.v1.X / 2) - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                                   (Parent.Height - ClippingWindow.v1.Y) / 2 - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2);

            g.DrawString("1001", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, p1001);


            PointF f2 = new PointF(((ClippingWindow.v2.X - ClippingWindow.v1.X) / 2 + ClippingWindow.v1.X) - (g.MeasureString("1000", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                                 (Parent.Height - ClippingWindow.v2.Y) / 2 - (g.MeasureString("1000", GraphicCore.Cohen_Sutherland_Font).Height) / 2);

            g.DrawString("1000", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f2);

            PointF f3 = new PointF(((Parent.Width - ClippingWindow.v2.X) / 2 + ClippingWindow.v2.X) - (g.MeasureString("1010", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                         (Parent.Height - ClippingWindow.v2.Y) / 2 - (g.MeasureString("1010", GraphicCore.Cohen_Sutherland_Font).Height) / 2);

            g.DrawString("1010", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f3);

            //unten
            PointF f4 = new PointF((ClippingWindow.v4.X / 2) - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                         Parent.Height - (Parent.Height - (Parent.Height - ClippingWindow.v4.Y)) / 2 - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2);

            g.DrawString("0101", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f4);

            PointF f5 = new PointF(((ClippingWindow.v3.X - ClippingWindow.v4.X) / 2 + ClippingWindow.v4.X) - (g.MeasureString("1000", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                          Parent.Height - (Parent.Height - (Parent.Height - ClippingWindow.v4.Y)) / 2 - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2);

            g.DrawString("0100", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f5);

            PointF f6 = new PointF(((Parent.Width - ClippingWindow.v3.X) / 2 + ClippingWindow.v3.X) - (g.MeasureString("1010", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                         Parent.Height - (Parent.Height - (Parent.Height - ClippingWindow.v3.Y)) / 2 - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2);

            g.DrawString("0110", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f6);

            //mitte

            PointF f7 = new PointF((ClippingWindow.v4.X / 2) - (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                        Parent.Height - (((ClippingWindow.v1.Y - ClippingWindow.v4.Y) / 2) + ClippingWindow.v4.Y + (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2));

            g.DrawString("0001", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f7);

            PointF f8 = new PointF(((ClippingWindow.v3.X - ClippingWindow.v4.X) / 2 + ClippingWindow.v4.X) - (g.MeasureString("1000", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                        Parent.Height - (((ClippingWindow.v1.Y - ClippingWindow.v4.Y) / 2) + ClippingWindow.v4.Y + (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2));

            g.DrawString("0000", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f8);

            PointF f9 = new PointF(((Parent.Width - ClippingWindow.v3.X) / 2 + ClippingWindow.v3.X) - (g.MeasureString("1010", GraphicCore.Cohen_Sutherland_Font).Width / 2),
                         Parent.Height - (((ClippingWindow.v2.Y - ClippingWindow.v3.Y) / 2) + ClippingWindow.v3.Y + (g.MeasureString("1001", GraphicCore.Cohen_Sutherland_Font).Height) / 2));

            g.DrawString("0010", GraphicCore.Cohen_Sutherland_Font, Brushes.Black, f9);


        }


        #endregion

    }
}
