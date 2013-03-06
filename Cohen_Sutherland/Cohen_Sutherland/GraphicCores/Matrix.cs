using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cohen_Sutherland._2DObject;

namespace Cohen_Sutherland.GraphicCores
{
    [Obsolete("Not in use")]
    public class Matrix
    {

        public float[,] matrix { get; set; }


        public float this[int row, int column]
        {
            set
            {
                this.matrix[row, column] = value;
            }

            get
            {
                return this.matrix[row, column];
            }
        }

        public Matrix(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            matrix = new float[3, 3];

            matrix[0, 0] = m11;
            matrix[0, 1] = m12;
            matrix[0, 2] = m13;

            matrix[1, 0] = m21;
            matrix[1, 1] = m22;
            matrix[1, 2] = m23;

            matrix[2, 0] = m31;
            matrix[2, 1] = m32;
            matrix[2, 2] = m33;

        }



    }
}
