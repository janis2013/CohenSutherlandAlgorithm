using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cohen_Sutherland._2DObject
{
    public class Line
    {

        /// <summary>
        /// Stores all Vectors.
        /// </summary>
        public List<Vector> Vectors { get; set; }

        /// <summary>
        /// Are we outside of the Clipping Window ?
        /// </summary>
        public bool isOutside { get; set; }



        public Line()
        {
            //v1 = new Vector();
            //v2 = new Vector();
            //Vectors = new List<Vector>() { v1, v2 };
            Vectors = new List<Vector>();
        }
        public Line(bool outside)
        {
            //v1 = new Vector();
            //v2 = new Vector();
            //Vectors = new List<Vector>() { v1, v2 };
            Vectors = new List<Vector>();
            this.isOutside = outside;
        }
        [System.Diagnostics.DebuggerHidden()]
        public Line(Vector vect1, Vector vect2)
        {
            //v1 = vect1;
            //v2 = vect2;
            //Vectors = new List<Vector>() { v1, v2 };
            Vectors = new List<Vector>() { vect1, vect2 };
            isOutside = false;
        }

        public Line(params Vector[] Vectors)
        {
            this.Vectors = new List<Vector>();
            this.Vectors.AddRange(Vectors);

            isOutside = false;
        }



        public Line(Vector vect1, Vector vect2,bool outside)
        {
            //v1 = vect1;
            //v2 = vect2;
            //Vectors = new List<Vector>() { v1, v2 };
            Vectors = new List<Vector>() { vect1, vect2 };
            this.isOutside = false;
        }


        /// <summary>
        /// Adds a Vector to this line.
        /// </summary>
        /// <param name="v"></param>
        public void AddPoint(Vector v)
        {
            this.Vectors.Add(v);
        }

        /// <summary>
        /// Clones this vector.
        /// </summary>
        /// <returns></returns>
        public Line Clone()
        {
            return (Line)MemberwiseClone();
        }

    }

    public static class ExtendLine
    {
        /// <summary>
        /// Clones a list of lines.
        /// </summary>
        /// <param name="Lines">The list of lines to clone.</param>
        /// <returns></returns>
        public static List<Line> Clone(this List<Line> Lines)
        {
            List<Line> NewLines = new List<Line>();

            foreach (var line in Lines)
            {
                NewLines.Add(line.Clone());
            }
            return NewLines;
        }
    }

}
