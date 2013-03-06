using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Cohen_Sutherland.GraphicCores;
using System.Data;

namespace Cohen_Sutherland._2DObject
{
    /// <summary>
    /// A Vector.
    /// </summary>
    public class Vector
    {

        /// <summary>
        /// THe starting X coordinate.
        /// </summary>
        private readonly float originX;

        /// <summary>
        /// The starting Y coordinate.
        /// </summary>
        private readonly float originY;


        /// <summary>
        /// The X coordinate.
        /// </summary>
        public float X { get; set;  }

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public float Y { get; set; }


        /// <summary>
        /// The Cohen Sutherland Outcode.
        /// </summary>
        public int Outcode { get; set; }

        /// <summary>
        /// Is this point marked?
        /// </summary>
        public bool Marked { get; set; }


        /// <summary>
        /// Are we outside of the Clipping Window ?
        /// </summary>
        public bool isOutside { get; set; }

        /// <summary>
        /// Determine whether this vector is logical (static) or calculated at rendering.
        /// </summary>
        public bool isLogicalVector { get; private set; }

        /// <summary>
        /// The current rotation in degrees.
        /// </summary>
        public float degrees = 0;


        /// <summary>
        /// The rotation matrix.
        /// </summary>
        public DataTable Rotation { get; set; }

        /// <summary>
        /// The scale matrix.
        /// </summary>
        public DataTable Scale { get; set; }

        /// <summary>
        /// The translation matrix.
        /// </summary>
        public DataTable Translation { get; set; }

        /// <summary>
        /// Stores all matrices.
        /// </summary>
        public DataTable[] AllMextrices { get; set; }


        /// <summary>
        /// Creates a new Vector.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        [System.Diagnostics.DebuggerHidden()]
        public Vector(float x, float y, bool isLogicalVector)
        {
            this.X = x;
            this.Y = y;
            this.originX = x;
            this.originY = y;
            this.isLogicalVector = isLogicalVector;

            SetUpMatrices();
        }


        #region [ Matrix stuff ]


        /// <summary>
        /// Check if the point(X,Y) hits this vector.
        /// </summary>
        /// <param name="X">The x coordinate.</param>
        /// <param name="Y">The y coordinate.</param>
        /// <returns></returns>
        public bool isHitted(float X, float Y)
        {
            //is already checked in logic
            //if (this.isLogicalVector) //other vectors are just calculated at rendertime --> no chance to marke
            //{
            if (X >= this.X - GraphicCore.DotRadius / 2 && X <= this.X + GraphicCore.DotRadius / 2)
            {
                if (Y >= this.Y - GraphicCore.DotRadius / 2 && Y <= this.Y + GraphicCore.DotRadius / 2) //change because x,y are upsidedown
                {
                    return true;
                }
            }
            //} 

            return false;
        }


        /// <summary>
        /// Sets up or renews all matrices.
        /// </summary>
        private void SetUpMatrices()
        {
            //------------------------ Translation ---------------------//

            SetUpTranslationMatrix();

            //------------------------ Scale ---------------------//

            SetUpScaleMatrix();


            //------------------------ Rotation ---------------------//

            SetUpRotationMatrix();


            this.AllMextrices = new DataTable[] { Translation, Scale, Rotation };


        }

        /// <summary>
        /// Sets up or renews the rotation matrix.
        /// </summary>
        public void SetUpRotationMatrix()
        {
            Rotation = new DataTable("RotationMatrix");
            Rotation.Columns.Add("Column 1", typeof(float));
            Rotation.Columns.Add("Column 2", typeof(float));
            Rotation.Columns.Add("Column 3", typeof(float));

            Rotation.Rows.Add(new object[] { 1, 0, 0 }); //cos(Alpha), -sin(alpha), 0
            Rotation.Rows.Add(new object[] { 0, 1, 0 }); //sin(alpha), cos(alpha) , 0
            Rotation.Rows.Add(new object[] { 0, 0, 1 }); //         0,           0, 1


            this.degrees = 0;
            this.X = this.originX;
            this.Y = this.originY;
        }

        /// <summary>
        /// Sets up or renews the scale matrix
        /// </summary>
        public void SetUpScaleMatrix()
        {
            Scale = new DataTable("ScalationMatrix");
            Scale.Columns.Add("Column 1", typeof(float));
            Scale.Columns.Add("Column 2", typeof(float));
            Scale.Columns.Add("Column 3", typeof(float));

            Scale.Rows.Add(new object[] { 1, 0, 0 }); //sx,  0, 0
            Scale.Rows.Add(new object[] { 0, 1, 0 }); // 0, sy, 0
            Scale.Rows.Add(new object[] { 0, 0, 1 });

            this.X = this.originX;
            this.Y = this.originY;
        }

        /// <summary>
        /// Sets up or renews the translation matrix.
        /// </summary>
        public void SetUpTranslationMatrix()
        {
            Translation = new DataTable("TranslationMatrix");
            Translation.Columns.Add("Column 1", typeof(float));
            Translation.Columns.Add("Column 2", typeof(float));
            Translation.Columns.Add("Column 3", typeof(float));

            Translation.Rows.Add(new object[] { 1, 0, 0 }); //1, 0, dx
            Translation.Rows.Add(new object[] { 0, 1, 0 }); //0, 1, dy
            Translation.Rows.Add(new object[] { 0, 0, 1 });

            this.X = this.originX;
            this.Y = this.originY;
        }


        /// <summary>
        /// Adds a x translation to this vector.
        /// </summary>
        /// <param name="X">The x translation to add.</param>
        public void AssignToTranslationMatrix_X(float X)
        {
            //calculate delta
            float temp = this.Translation.Rows[0].Field<float>(2);
            //temp = X - temp;
            this.Translation.Rows[0].SetField<float>(2, temp + X);

            // X = matrix[0, 0] * vektor.X + matrix[0, 1] * vektor.Y,
            // Y = matrix[1, 0] * vektor.X + matrix[1, 1] * vektor.Y

            //this.X = this.originX + this.Translation.Rows[0].Field<float>(2);

            float tempX = ((this.originX + this.Translation.Rows[0].Field<float>(2)) * this.Scale.Rows[0].Field<float>(0));

            this.X = tempX * this.Rotation.Rows[0].Field<float>(0) +
                tempX * this.Rotation.Rows[1].Field<float>(0); ;

        }

        /// <summary>
        /// Adds a y translation to this vector.
        /// </summary>
        /// <param name="Y">The y translation to add.</param>
        public void AssignToTranslationMatrix_Y(float Y)
        {
            float temp = this.Translation.Rows[1].Field<float>(2);
            this.Translation.Rows[1].SetField<float>(2, temp + Y);

            //this.Y = this.originY + this.Translation.Rows[1].Field<float>(2);

            float tempY = (this.originY + this.Translation.Rows[1].Field<float>(2)) * this.Scale.Rows[1].Field<float>(1);
            this.Y = tempY * this.Rotation.Rows[0].Field<float>(1) + tempY * this.Rotation.Rows[1].Field<float>(1);

        }

        /// <summary>
        /// Adds a new x scale to this vector.
        /// </summary>
        /// <param name="X">The y scale to add.</param>
        public void AssignToScalationMatrix_X(float X)
        {
            float temp = this.Scale.Rows[0].Field<float>(0);
            this.Scale.Rows[0].SetField<float>(0, temp + X);

            // this.X = this.originX * this.Scalation.Rows[0].Field<float>(0);

            float tempX = ((this.originX + this.Translation.Rows[0].Field<float>(2)) * this.Scale.Rows[0].Field<float>(0));

            this.X = tempX * this.Rotation.Rows[0].Field<float>(0) +
                tempX * this.Rotation.Rows[1].Field<float>(0); ;
        }

        /// <summary>
        /// Adds a new y scale to this vector.
        /// </summary>
        /// <param name="Y">The y scale to add.</param>
        public void AssignToScalationMatrix_Y(float Y)
        {
            float temp = this.Scale.Rows[1].Field<float>(1);

            this.Scale.Rows[1].SetField<float>(1, temp + Y);

            //this.Y = this.originY * this.Scalation.Rows[1].Field<float>(1);

            float tempY = (this.originY + this.Translation.Rows[1].Field<float>(2)) * this.Scale.Rows[1].Field<float>(1);
            this.Y = tempY * this.Rotation.Rows[0].Field<float>(1) + tempY * this.Rotation.Rows[1].Field<float>(1);

        }

        /// <summary>
        /// Adds a new rotation on this vector.
        /// </summary>
        /// <param name="degree">The degrees to add.</param>
        public void AssignToRotationMatrix(float degree)
        {
            //cos(Alpha), -sin(alpha), 0
            //sin(alpha), cos(alpha) , 0
            //         0,           0, 1

            this.degrees = this.degrees + degree;


            float radian_measure = (float)(Math.PI / 180 * this.degrees);


            //float temp1 = this.Rotation.Rows[0].Field<float>(0); // cos(Alpha)
            //float temp2 = this.Rotation.Rows[0].Field<float>(1); //-sin(alpha)
            //float temp3 = this.Rotation.Rows[1].Field<float>(0); //sin(alpha)
            //float temp4 = this.Rotation.Rows[1].Field<float>(1); // cos(alpha)



            this.Rotation.Rows[0].SetField<float>(0, (float)Math.Cos(radian_measure));
            this.Rotation.Rows[0].SetField<float>(1, (float)Math.Sin(radian_measure));
            this.Rotation.Rows[1].SetField<float>(0, -(float)(Math.Sin(radian_measure)));
            this.Rotation.Rows[1].SetField<float>(1, (float)Math.Cos(radian_measure));



            //this.X = this.originX * this.Rotation.Rows[0].Field<float>(0) + this.originX * this.Rotation.Rows[1].Field<float>(0);

            float tempX = ((this.originX + this.Translation.Rows[0].Field<float>(2)) * this.Scale.Rows[0].Field<float>(0));

            this.X = tempX * this.Rotation.Rows[0].Field<float>(0) +
                tempX * this.Rotation.Rows[1].Field<float>(0); ;

            //this.Y = this.originY * this.Rotation.Rows[0].Field<float>(1) + this.originY * this.Rotation.Rows[1].Field<float>(1);

            float tempY = (this.originY + this.Translation.Rows[1].Field<float>(2)) * this.Scale.Rows[1].Field<float>(1);
            this.Y = tempY * this.Rotation.Rows[0].Field<float>(1) + tempY * this.Rotation.Rows[1].Field<float>(1);

        }


        /// <summary>
        /// Returns the Matrices.
        /// </summary>
        /// <returns></returns>
        public DataTable[] GetMatrices()
        {
            return this.AllMextrices;
        }


        /// <summary>
        /// Resets the coordinates and Matrices.
        /// </summary>
        public void ResetCoordinatesAndMatrices()
        {
            SetUpMatrices();
            this.X = this.originX;
            this.Y = this.originY;
        }


        #endregion


        /// <summary>
        /// Clones the Vector --> no reference
        /// </summary>
        /// <returns></returns>
        public Vector Clone()
        {
            return new Vector(this.X, this.Y, this.isLogicalVector);
        }

        #region To remove

      


        #endregion
        //public static Vector operator *(int skalar, Vector v1)
        //{
        //    return new Vector(v1.X * skalar, v1.Y * skalar);
        //}
        //public static Vector operator *(Vector v1, int skalar)
        //{
        //    return new Vector(v1.X * skalar, v1.Y * skalar);
        //}

        //public static Vector operator +(Vector v1, Vector v2)
        //{
        //    return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        //}


    }

    public static class ExtendVektor
    {

        /// <summary>
        /// RETURNS and SETS the Outcode of the Vector.
        /// </summary>
        /// <param name="ClippingWindow">The Renderwindow.</param>
        /// <returns></returns>
        public static int SetOutCode(this Vector vector, myRectangle ClippingWindow)
        {
            int b = 0;

            if (ClippingWindow == null)
            {
                return 0;
            }

            if (vector.X < ClippingWindow.v1.X) //left
            {
                b += 1;
            }
            if (vector.X >= ClippingWindow.v1.X && vector.X <= ClippingWindow.v2.X) //mitte
            {
                b += 0;
            }
            if (vector.X > ClippingWindow.v2.X) //right
            {
                b += 10;
            }

            if (vector.Y < ClippingWindow.v3.Y) //bottom
            {
                b += 100;
            }
            if (vector.Y > ClippingWindow.v1.Y) //top
            {
                b += 1000;
            }
            if (vector.Y >= ClippingWindow.v3.Y && vector.Y <= ClippingWindow.v1.Y) //center
            {
                b += 0;
            }
            vector.Outcode = b;
            return b;
        }



    }
}
