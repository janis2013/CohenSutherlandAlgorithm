using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cohen_Sutherland._2DObject
{
    public static class Cutter
    {
        /// <summary>
        /// Calculates the intersection point. if no intersection point: New Vector(0,0,false).
        /// </summary>
        /// <param name="v1">The starting Vector.</param>
        /// <param name="v2">The ending Vector.</param>
        /// <param name="ClippingWindowV1">The starting clipping Vector.</param>
        /// <param name="ClippingWindowV2">The ending clipping Vector.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerHidden()] //remove to debugg
        public static Vector CalculateIntersection(Vector v1, Vector v2, Vector ClippingWindowV1, Vector ClippingWindowV2)
        {

            if (Math.Abs(v1.Y - v2.Y) == 0) //our line(v1,v2) is horizontal
            {
                if (Math.Abs(ClippingWindowV1.Y - ClippingWindowV2.Y) == 0) //horizontal line
                {
                    return new Vector(0, 0, false); //no intersection
                }
            }

            if (Math.Abs(v1.X - v2.X) == 0) //vertical line
            {
                if (Math.Abs(ClippingWindowV1.X - ClippingWindowV2.X) == 0) //vertical too
                {
                    return new Vector(0, 0, false); //no intersection
                }
            }




            //calcualte our valid ranges
            float minX = v1.X >= v2.X ? v2.X : v1.X;
            float maxX = v1.X >= v2.X ? v1.X : v2.X;

            float minY = v1.Y >= v2.Y ? v2.Y : v1.Y;
            float maxY = v1.Y >= v2.Y ? v1.Y : v2.Y;

            float ClippMaxX = ClippingWindowV1.X >= ClippingWindowV2.X ? ClippingWindowV1.X : ClippingWindowV2.X;
            float ClippMinX = ClippingWindowV1.X >= ClippingWindowV2.X ? ClippingWindowV2.X : ClippingWindowV1.X;

            float ClippMaxY = ClippingWindowV1.Y >= ClippingWindowV2.Y ? ClippingWindowV1.Y : ClippingWindowV2.Y;
            float ClippMinY = ClippingWindowV1.Y >= ClippingWindowV2.Y ? ClippingWindowV2.Y : ClippingWindowV1.Y;

            //v1 + r * v2 = ClippingWindowV1 + s * ClippingWindowV2 // to get the intersection point

            //v2 & ClippingWindowV2 sould be our directional vectors...
            // directional vector(left1X) = v2.X - v1.X // AB = OB - OA

            float Left1X = (v2.X - v1.X);
            float Left1Y = (v2.Y - v1.Y);

            float Right1X = (ClippingWindowV2.X - ClippingWindowV1.X);
            float Right1Y = ClippingWindowV2.Y - ClippingWindowV1.Y;

            //solve this...
            //x1 + r * x2 = x3 + s * x4 | -x3
            //y1 + r * y2 = y3 + s * y4 | -y3

            //leftX + r * v2.X = s * ClippingWindowV2.X
            //leftY + r * v2.Y = s * ClippingWindowV2.Y

            float leftX = v1.X - ClippingWindowV1.X;
            float leftY = v1.Y - ClippingWindowV1.Y;

            //now we have

            //leftX + r * Left1X = s * Right1X
            //leftY + r * Left1Y = s * Right1Y

            float r, s;



            #region general checks


            //leftX + r * Left1X = s * 0
            //leftY + r * 0 = s * Right1Y

            if (Left1Y == 0 && Right1X == 0) //no need to extend... //leftX + r * Left1X = 0 && s * Right1Y = 0
            {
                //leftX + r * LeftX = 0 | - leftX

                // r * Left1X = -leftX | / LeftX
                //r = (-leftX) / Left1X
                r = (-leftX) / Left1X;

                s = leftY / Right1Y;

                if (r >= 0 && r <= 1 && s >= 0 && s <= 1) //we only need valid intersections ( r > 1 would be beyond our v2 vector && r < 0 beyond v1)
                {
                    //to int because float is sometimes glitched (round)

                    //check s too

                    return new Vector(Convert.ToInt32(v1.X + Left1X * r), Convert.ToInt32(v1.Y + Left1Y * r),false);


                }
                else
                {
                    return new Vector(0, 0, false);
                }
            }

            //leftX + r * 0 = s * Right1X
            //leftY + r * Left1Y = s * 0

            if (Left1X == 0 && Right1Y == 0) //no need to extend 
            {
                // leftY + r * Left1Y = 0 | - leftY

                //r * Left1Y = -leftY | / Left1Y

                r = (-leftY) / Left1Y;

                s = leftX / Right1X;

                if (r >= 0 && r <= 1 && s >= 0 && s <= 1) //we only need valid intersections ( r > 1 would be beyond our v2 vector && r < 0 beyond v1)
                {
                    //to int because float is sometimes glitched (round)

                    return new Vector(Convert.ToInt32(v1.X + Left1X * r), Convert.ToInt32(v1.Y + Left1Y * r),false );
                    

                }
                else
                {
                    return new Vector(0, 0, false);
                }

            }

            //leftX + r * Left1X = s * Right1X
            //leftY + r * 0 = s * Right1Y

            if (Left1Y == 0)
            {
                //leftY + 0 = s * Right1Y | / Right1Y
                s = leftY / Right1Y;

                r = (s * Right1X - leftX) / Left1X;

                if (s >= 0 && s <= 1 && r >= 0 && r <= 1)  //we only need valid intersections ( r > 1 would be beyond our v2 vector && r < 0 beyond v1)
                {
                   
                        return new Vector(Convert.ToInt32(ClippingWindowV1.X + Right1X * s), Convert.ToInt32(ClippingWindowV1.Y + Right1Y * s),false);
                }
                else
                {
                    return new Vector(0, 0, false);
                }
            }

            //leftX + r * 0 = s * Right1X
            //leftY + r * Left1Y = s * Right1Y

            if (Left1X == 0)
            {
                //leftX + r * 0 = s * Right1X | / Right1X
                s = leftX / Right1X;

                r = (s * Right1Y - leftY) / Left1Y;

                if (s >= 0 && s <= 1 && r >= 0 && r <= 1)
                {

                    return new Vector(Convert.ToInt32(ClippingWindowV1.X + Right1X * s), Convert.ToInt32(ClippingWindowV1.Y + Right1Y * s),false );
                   
                }
                else
                {
                    return new Vector(0, 0, false);
                }
            }

            //leftX + r * Left1X = s * 0
            //leftY + r * Left1Y = s * Right1Y


            if (Right1X == 0)
            {
                //leftX + r * Left1X = 0
                r = (-leftX) / Left1X;

                s = (r * Left1Y + leftY) / Right1Y;

                if (r >= 0 && r <= 1 && s >= 0 && s <= 1)
                {

                    return new Vector(Convert.ToInt32(v1.X + Left1X * r), Convert.ToInt32(v1.Y + Left1Y * r),false );
                    
                   
                }
                else
                {
                    return new Vector(0, 0, false);
                }

            }


            //leftX + r * Left1X = s * Right1X
            //leftY + r * Left1Y = s * 0

            if (Right1Y == 0)
            {
                //leftY + r * Left1Y = 0

                r = (-leftY) / Left1Y;

                s = (r * Left1X + leftX) / Right1X;


                if (r >= 0 && r <= 1 && s >= 0 && s <= 1)
                {

                    return new Vector(Convert.ToInt32(v1.X + Left1X * r), Convert.ToInt32(v1.Y + Left1Y * r),false );
                    
                }
                else
                {
                    return new Vector(0, 0, false);
                }

            }

            #endregion
            //now we need to extend

            //(leftX*Left1Y) + r * (Left1X*Left1Y) = s * (Right1X*Left1Y)
            //(leftY*Left1X) + r * (Left1Y*Left1X) = s * (Right1Y*Left1X)


            Left1X = Left1X * Left1Y;
            Left1Y = Left1Y * Left1X;

            Right1X = Right1X * Left1Y;
            Right1Y = Right1Y * Left1X;

            leftX = leftX * Left1Y;
            leftY = leftY * Left1X;

            //I.    leftX + r * 1 = s * (Right1X*Left1Y)
            //II.   leftY + r * 1 = s * (Right1Y*Left1X)

            // I - II 
            float tempRight, tempLeft;

            tempRight = Right1X - Right1Y;
            tempLeft = leftX - leftY;
            //1r - 1r = 0r = 0

            //tempLeft = s * tempRight

            s = tempLeft / tempRight;

            //now check r

            //leftX + r * 1 = s * (Right1X)
            //leftX + r  = s * (Right1X) |- leftX
            // r = s * (Right1X) - leftX 

            //r = ((RenderWindowPunkt2.X * s) + RenderWindowPunkt1.X - StartPunkt.X) / EndPunkt.X;
            r = (s * Right1X) - leftX;

            if (CheckIfValidForBoth(v1, v2, ClippingWindowV1, ClippingWindowV2, r, s) == true)
            {
                return new Vector(ClippingWindowV1.X + (ClippingWindowV2.X * s), ClippingWindowV1.Y + (ClippingWindowV2.Y * s),false );
            }


            return new Vector(0, 0, false);

        }

        private static bool CheckIfValidForBoth(Vector v1, Vector v2, Vector ClippingWindowV1, Vector ClippingWindowV2, float r, float s)
        {
            //v1.x + (Left1X * r)
            float check1 = v1.X + ((v2.X - v1.X) * r);

            //ClippingWindowV1.X + (Right1X * s)
            float check2 = ClippingWindowV1.X + ((ClippingWindowV2.X - ClippingWindowV1.X) * s);

            if (Convert.ToInt32(check1) == Convert.ToInt32(check2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
