using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Cohen_Sutherland.GraphicCores
{
    public partial class GraphicCore
    {

        /// <summary>
        /// The normal dot color.
        /// </summary>
        public static SolidBrush NormalDotColor = new SolidBrush(Color.Gray);


        /// <summary>
        /// The transformed dot color.
        /// </summary>
        public static SolidBrush TransformedDotColor = new SolidBrush(Color.Green);

        /// <summary>
        /// The pen of the cohen sutherland clipping window.
        /// </summary>
        public static Pen Cohen_Sutherland_WindowLines = new Pen(Color.Black, 3);

        /// <summary>
        /// The font of the cohen sutherland caption.
        /// </summary>
        public static Font Cohen_Sutherland_Font = new Font("Arial", 12);

        /// <summary>
        /// The color to split the Cohen Sutherland window into parts.
        /// </summary>
        public static Pen Cohen_Sutherland_LinesColor = new Pen(Color.Aqua);

        /// <summary>
        /// The opacity of the outsided vectors and lines.
        /// </summary>
        public static int Cohen_Sutherland_Opacity = 45;

        /// <summary>
        /// The color of the marked vectors.
        /// </summary>
        public static SolidBrush MarkedDotColor = new SolidBrush(Color.DarkTurquoise);


        /// <summary>
        /// The normal line color.
        /// </summary>
        public static Pen NormalLineColor = new Pen(NormalDotColor);

        /// <summary>
        /// The transformed line color.
        /// </summary>
        public static Pen TransformedLineColor = new Pen(TransformedDotColor);

        /// <summary>
        /// The dot(vector) raidus.
        /// </summary>
        public static int DotRadius = 10;



    }
}
