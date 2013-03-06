using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cohen_Sutherland._2DObject
{
    public class myRectangle
    {

        public Vector v1 { get; set; }

        public Vector v2 { get; set; }

        public Vector v3 { get; set; }

        public Vector v4 { get; set; }

        /// <summary>
        /// Stores all 4 coner points.
        /// </summary>
        public Vector[] Vectors { get; set; }

       
        /// <summary>
        /// Creates a new Rectangle.
        /// </summary>
        /// <param name="vect1">The top,left corner point.</param>
        /// <param name="vect2">The bottom,right corner point.</param>
        public myRectangle(Vector vect1, Vector vect2)
        {
            this.v1 = new Vector(vect1.X,vect1.Y,false);
            this.v2 = new Vector(vect2.X, vect1.Y,false);
            this.v3 = new Vector(vect2.X,vect2.Y,false);
            this.v4 = new Vector(vect1.X, vect2.Y,false);

            Vectors = new Vector[] { v1, v2, v3, v4 };
        }



    }
}
