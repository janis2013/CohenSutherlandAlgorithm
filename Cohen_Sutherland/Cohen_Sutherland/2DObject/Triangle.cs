using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cohen_Sutherland._2DObject
{
    public class Triangle
    {

        /// <summary>
        /// Stores all Vectors.
        /// </summary>
        public List<Vector> Vectors { get; set; }

        /// <summary>
        /// Are we outside of the Clipping Window ?
        /// </summary>
        public bool outside { get; set; }


        /// <summary>
        /// Creates a new empty Triangle.
        /// </summary>
        public Triangle()
        {
            this.Vectors = new List<Vector>();
        }

        /// <summary>
        /// Adds a Vector to this triangle.
        /// </summary>
        /// <param name="v">The vector to add.</param>
        public void AddPoint(Vector v)
        {
            this.Vectors.Add(v);
        }

        /// <summary>
        /// Clones this vector.
        /// </summary>
        /// <returns></returns>
        public Triangle Clone()
        {
            return (Triangle)MemberwiseClone();
        }

    }

    public static class ExtendTriangle
    {
        
        /// <summary>
        /// Clones a list of triangles.
        /// </summary>
        /// <param name="Triangles">The list of triangles to clone.</param>
        /// <returns></returns>
        public static List<Triangle> Clone(this List<Triangle> Triangles)
        {
            List<Triangle> NewTriangles = new List<Triangle>();

            foreach (var triangle in Triangles)
            {
                NewTriangles.Add(triangle.Clone());
            }
            return NewTriangles;
        }
    }

}
