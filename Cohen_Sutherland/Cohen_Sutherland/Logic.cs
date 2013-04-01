using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

using Cohen_Sutherland.GraphicCores;
using Cohen_Sutherland._2DObject;

namespace Cohen_Sutherland
{
    /// <summary>
    /// What to do with incoming points?
    /// </summary>
    public enum DrawingMode
    {
        /// <summary>
        /// Do nothing when clicked.
        /// </summary>
        None,

        /// <summary>
        /// Add to plain points.
        /// </summary>
        Points,

        /// <summary>
        /// Add Lines.
        /// </summary>
        Lines,

        /// <summary>
        /// point is part of a triangle.
        /// </summary>
        Triangles

    }

    public enum OutcodeState
    {
        /// <summary>
        /// full outside, no need to check intersection.
        /// </summary>
        outside,

        /// <summary>
        /// we need to check intersections.
        /// </summary>
        partially,

        /// <summary>
        /// full inside, no need to check intersection.
        /// </summary>
        inside

    }

    public class Logic
    {

        #region [ Fields ]

        /// <summary>
        /// Our Graphics Core.
        /// </summary>
        public readonly GraphicCore gc;



        /// <summary>
        /// All visible Points (contains plain points + triangle points).
        /// </summary>
        public List<Vector> AllVectors { get; set; }

        /// <summary>
        /// List of plain Points.
        /// </summary>
        public List<Vector> Points { get; set; }


        /// <summary>
        /// Base list of Triangles.
        /// </summary>
        public List<Triangle> logicalTriangles { get; set; }

        /// <summary>
        /// If cohen sutherland split a triangle, add the 2 new triangles here.
        /// </summary>
        public List<Triangle> calcualtedTriangles { get; set; }



        /// <summary>
        /// base list of Lines.
        /// </summary>
        public List<Line> logicalLines { get; set; }

        /// <summary>
        /// The drawn Lines.
        /// </summary>
        public List<Line> calculatedLines { get; set; }


        /// <summary>
        /// The Drawing mode.
        /// </summary>
        public DrawingMode drawingMode { get; set; }


        /// <summary>
        /// Countes the number of points for the current triangle (if == 2, add point and create new triangle).
        /// </summary>
        private int _trianglePointCount;

        /// <summary>
        /// Countes the number of points for the current line (if == 1, add point and create new line).
        /// </summary>
        private int _linePointCount;


        /// <summary>
        /// Indicates if we use the Cohen sutherland algorithm or not.
        /// </summary>
        public bool UseCohenSutherlandAlgorithm { get; set; }


        /// <summary>
        /// Determines whether the coordinates of the cursor are shown on the main form or not.
        /// </summary>
        public bool ShowCoordinates { get; set; }


        /// <summary>
        /// Our clipping area.
        /// </summary>
        public myRectangle ClippingWindow { get; set; }

        /// <summary>
        /// Draw the Outcodes for the areas.
        /// </summary>
        public bool DrawCaption { get; set; }


        /// <summary>
        /// The main form to change the caption.
        /// </summary>
        FormMain fmMain;


        /// <summary>
        /// The list view to displays the vector states.
        /// </summary>
        ListView lvLogger;


        //lvlogger event stuff

        private bool isKeyDown = false;


        public Vector CurrentOnMainFormSelectedVector { get; set; }


        #endregion

        /// <summary>
        /// Fires when a Vector is clicked and the drawingmode is none.
        /// </summary>
        public event Action<Vector> OnVectorClicked;


        /// <summary>
        /// Creates a new Logic for the program.
        /// </summary>
        /// <param name="box">The drawing area.</param>
        /// <param name="fmMain">The main window.</param>
        /// <param name="logger">The ListView to display the vector coordinates.</param>
        public Logic(PictureBox box, FormMain fmMain, ListView logger)
        {
            gc = new GraphicCore(box);



            this.ShowCoordinates = true;

            this.UseCohenSutherlandAlgorithm = false;

            this.fmMain = fmMain;

            _trianglePointCount = 0;
            _linePointCount = 0;

            drawingMode = DrawingMode.Points;

            this.lvLogger = logger;

            box.MouseUp += new MouseEventHandler(box_MouseUp);
            box.MouseMove += new MouseEventHandler(box_MouseMove);
            box.SizeChanged += new EventHandler(box_SizeChanged);

            lvLogger.SelectedIndexChanged += new EventHandler(lvLogger_SelectedIndexChanged);

            lvLogger.Click += new EventHandler(lvLogger_Click);
            lvLogger.KeyUp += new KeyEventHandler(lvLogger_KeyUp);
            lvLogger.KeyDown += new KeyEventHandler(lvLogger_KeyDown);

            //1. corner: left top
            //2. corner right bottom
            ClippingWindow = new myRectangle(new Vector(box.Width / 4, 3 * box.Height / 4, false), new Vector(3 * (box.Width / 4), (box.Height / 4), false));

            this.InitLists();

        }


        /// <summary>
        /// Inits all lists.
        /// </summary>
        public void InitLists()
        {
            AllVectors = new List<Vector>();
            Points = new List<Vector>();
            logicalTriangles = new List<Triangle>();
            calcualtedTriangles = new List<Triangle>();
            logicalLines = new List<Line>();
            calculatedLines = new List<Line>();

            this._linePointCount = 0;
            this._trianglePointCount = 0;

            UpdateLogger();
        }

        /// <summary>
        /// Adds a Point.
        /// </summary>
        /// <param name="x">The x koordiante.</param>
        /// <param name="y">The y koordinate.</param>
        public void AddPoint(float x, float y)
        {
            Vector v = new Vector(x, y, true);

            //lvLogger.Items.Add(new ListViewItem(new string[] { v.ID.ToString(), "X: " + v.X + " Y: " + v.Y, v.Outcode.ToString() }));

            switch (this.drawingMode)
            {
                case DrawingMode.Points:
                    this.AllVectors.Add(v);
                    this.Points.Add(v);

                    break;

                case DrawingMode.Triangles:

                    if (this._trianglePointCount == 3) // 0 - 2
                    {
                        this._trianglePointCount = 0;
                    }
                    if (this._trianglePointCount == 0) // because we started with 0
                    {
                        this.logicalTriangles.Add(new Triangle());
                    }

                    this.AllVectors.Add(v);
                    this.logicalTriangles[this.logicalTriangles.Count - 1].AddPoint(v);
                    this._trianglePointCount++;

                    break;

                case DrawingMode.Lines:

                    if (this._linePointCount == 2)
                    {
                        this._linePointCount = 0;
                    }
                    if (this._linePointCount == 0)
                    {
                        this.logicalLines.Add(new Line());
                    }

                    this.AllVectors.Add(v);
                    this.logicalLines[this.logicalLines.Count - 1].AddPoint(v);
                    this._linePointCount++;

                    break;

                case DrawingMode.None: break;

                default:
                    break;
            }

            UpdateLogger();
            Program.fmMain.Updater.Start();
        }

        /// <summary>
        /// Clears all lists = next image is empty.
        /// </summary>
        public void ClearImage()
        {
            InitLists();
        }

        /// <summary>
        /// Returns the next image.
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.DebuggerHidden()]
        public Bitmap GetImage()
        {
            gc.StartImage();

            //now calculations...

            this.calcualtedTriangles.Clear();
            this.calculatedLines.Clear();
            //this.AllVectors.Clear();

            //clipping?
            if (this.UseCohenSutherlandAlgorithm)
            {
                //and draw the border of our  target window
                this.DoClipping();
                gc.DrawTriangle(GraphicCore.Cohen_Sutherland_WindowLines, this.ClippingWindow.Vectors);
            }
            else
            {
                //just copy the logical triangles
                this.calcualtedTriangles.AddRange(this.logicalTriangles.Clone());
                this.calculatedLines.AddRange(this.logicalLines.Clone());
            }


            #region Draw plain Points

            foreach (var vector in this.Points)
            {
                //draw each dot
                if (this.UseCohenSutherlandAlgorithm)
                {
                    //check if dot is outside
                    if (vector.isOutside)
                    {
                        if (vector.Marked)
                        {
                            gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }
                        else
                        {
                            gc.FillEllipse(this.GetTransparentBrush(GraphicCore.NormalDotColor), vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }

                    }
                    else
                    {
                        if (vector.Marked)
                        {
                            gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }
                        else
                        {
                            gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }
                    }
                }
                else
                {
                    if (vector.Marked)
                    {
                        gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                    }
                    else
                    {
                        gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                    }
                }

            }

            #endregion

            #region Draw calcualted Lines

            foreach (var line in this.calculatedLines)
            {
                foreach (var vector in line.Vectors)
                {
                    //check if dot is outside
                    if (this.UseCohenSutherlandAlgorithm)
                    {
                        if (vector.isOutside)
                        {
                            if (vector.Marked)
                            {
                                gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }
                            else
                            {
                                gc.FillEllipse(this.GetTransparentBrush(GraphicCore.NormalDotColor), vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }

                        }
                        else
                        {
                            if (vector.Marked)
                            {
                                gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }
                            else
                            {
                                gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }

                        }
                    }
                    else // don't use cohen sutherland
                    {
                        if (vector.Marked)
                        {
                            gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }
                        else
                        {
                            gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }
                    }
                }

                //draw the line
                if (this.UseCohenSutherlandAlgorithm)
                {
                    if (line.isOutside)
                    {
                        gc.DrawLine(this.GetTransparentPen(GraphicCore.NormalLineColor), line.Vectors.ToArray());
                    }
                    else
                    {
                        gc.DrawLine(GraphicCore.NormalLineColor, line.Vectors.ToArray());
                    }
                }
                else
                {
                    gc.DrawLine(GraphicCore.NormalLineColor, line.Vectors.ToArray());
                }


            }

            #endregion

            #region Draw calculated (visible) Triangles

            foreach (var triangle in this.calcualtedTriangles)
            {
                //draw each dot
                foreach (var vector in triangle.Vectors)
                {
                    //check if dot is outside
                    if (this.UseCohenSutherlandAlgorithm)
                    {
                        if (vector.isOutside)
                        {
                            if (vector.Marked)
                            {
                                gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }
                            else
                            {
                                gc.FillEllipse(this.GetTransparentBrush(GraphicCore.NormalDotColor), vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }

                        }
                        else
                        {
                            if (vector.Marked)
                            {
                                gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }
                            else
                            {
                                gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                            }

                        }
                    }
                    else // don't use cohen sutherland
                    {
                        if (vector.Marked)
                        {
                            gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }
                        else
                        {
                            gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
                        }

                    }
                }

                //draw triangle
                if (this.UseCohenSutherlandAlgorithm)
                {
                    //if so we already have drawn the triangle as lines
                }
                else
                {
                    gc.DrawTriangle(GraphicCore.NormalLineColor, triangle.Vectors.ToArray());
                }

            }

            #endregion


            #region draw All Points

            //don't work if we resize the picturebox
            //foreach (var vector in this.AllVectors)
            //{
            //    //draw each dot
            //    if (this.UseCohenSutherlandAlgorithm)
            //    {
            //        //check if dot is outside
            //        if (vector.isOutside)
            //        {
            //            if (vector.Marked)
            //            {
            //                gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
            //            }
            //            else
            //            {
            //                gc.FillEllipse(this.GetTransparentBrush(GraphicCore.NormalDotColor), vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
            //            }

            //        }
            //        else
            //        {
            //            if (vector.Marked)
            //            {
            //                gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
            //            }
            //            else
            //            {
            //                gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (vector.Marked)
            //        {
            //            gc.FillEllipse(GraphicCore.MarkedDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
            //        }
            //        else
            //        {
            //            gc.FillEllipse(GraphicCore.NormalDotColor, vector, GraphicCore.DotRadius, GraphicCore.DotRadius);
            //        }
            //    }
            //}

            #endregion


            //draw caption Outcode areas at least
            if (this.DrawCaption)
            {
                gc.DrawCaption(this.ClippingWindow);
            }


            //... now send back calculated image


            return gc.EndImage();

        }

        /// <summary>
        /// Returns a new Brush (used when the dot is outside).
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        private SolidBrush GetTransparentBrush(SolidBrush brush)
        {
            return new SolidBrush(Color.FromArgb(GraphicCore.Cohen_Sutherland_Opacity, brush.Color.R, brush.Color.G, brush.Color.B));
        }

        /// <summary>
        /// Returns a new Pen (used when the line is outside.
        /// </summary>
        /// <param name="pen"></param>
        /// <returns></returns>
        private Pen GetTransparentPen(Pen pen)
        {
            return new Pen(Color.FromArgb(GraphicCore.Cohen_Sutherland_Opacity, pen.Color.R, pen.Color.G, pen.Color.B), pen.Width);
        }


        #region [ Clipping Methods ]



        /// <summary>
        /// Do clipping.
        /// </summary>
        private void DoClipping()
        {

            //set all Outcodes
            this.SetAllLogicalOutcodes();


            //--------------------------------------------------------------------//

            List<Vector> intersectionPoints = new List<Vector>();
            //just handle & copy finished 2dojects

            //clipp lines
            foreach (var line in this.logicalLines)
            {
                if (line.Vectors.Count == 2) //line is finished
                {
                    intersectionPoints.Clear();
                    //check if we need to do sth.
                    if (CheckOutcodes(line.Vectors[0], line.Vectors[1]) == OutcodeState.partially)
                    {
                        //check if we intersect with the ClippingWindow
                        for (int i = 0; i < ClippingWindow.Vectors.Length; i++)
                        {
                            if (i == ClippingWindow.Vectors.Length - 1) // -2 ?
                            {
                                this.CheckIntersectionLine(line.Vectors[0], line.Vectors[1], ClippingWindow.Vectors[i], ClippingWindow.Vectors[0], ref intersectionPoints);
                            }
                            else
                            {
                                this.CheckIntersectionLine(line.Vectors[0], line.Vectors[1], ClippingWindow.Vectors[i], ClippingWindow.Vectors[i + 1], ref intersectionPoints);
                            }
                        }
                    }
                    else //add to lines collection
                    {
                        this.calculatedLines.Add(new Line(line.Vectors[0], line.Vectors[1]));
                    }
                }
                else //add nevertheless to draw points...
                {
                    this.calculatedLines.Add(new Line(line.Vectors.ToArray()));
                }
            } //end clipp lines

            intersectionPoints.Clear();
            //--------------------------------------------------------------------//

            //clipp tirangles

            foreach (var triangle in this.logicalTriangles)
            {
                if (triangle.Vectors.Count == 3) //triangle finished
                {
                    this.CheckTriangle(triangle, ref intersectionPoints);
                }
                else if (triangle.Vectors.Count == 2) //treat as a line
                {
                    intersectionPoints.Clear();
                    //check if we intersect with the ClippingWindow
                    for (int i = 0; i < ClippingWindow.Vectors.Length; i++)
                    {
                        if (i == ClippingWindow.Vectors.Length - 1) // -2 ?
                        {
                            this.CheckIntersectionLine(triangle.Vectors[0], triangle.Vectors[1], ClippingWindow.Vectors[i], ClippingWindow.Vectors[0], ref intersectionPoints);
                        }
                        else
                        {
                            this.CheckIntersectionLine(triangle.Vectors[0], triangle.Vectors[1], ClippingWindow.Vectors[i], ClippingWindow.Vectors[i + 1], ref intersectionPoints);
                        }
                    }
                }
                else
                {
                    this.calculatedLines.Add(new Line(triangle.Vectors.ToArray()));
                }
            }

            //end clipp triangles
            intersectionPoints.Clear();

            //--------------------------------------------------------------------------------------------------------------------------//

            //now we have all new dots and lines ...

            //now check and set if we are outside 
            foreach (var point in this.Points)
            {
                if (point.SetOutCode(this.ClippingWindow) != 0) //we are outside
                {
                    point.isOutside = true;
                }
                else
                {
                    point.isOutside = false;
                }
            }


            foreach (var line in this.calculatedLines)
            {
                foreach (var vect in line.Vectors)
                {
                    if (vect.SetOutCode(this.ClippingWindow) == 0)
                    {
                        vect.isOutside = false;
                    }
                    else
                    {
                        vect.isOutside = true;
                    }
                }

                if (line.Vectors.Count == 2)
                {
                    if (this.CheckOutcodes(line.Vectors[0], line.Vectors[1]) == OutcodeState.outside)
                    {
                        line.isOutside = true;
                    }
                    else if (this.CheckOutcodes(line.Vectors[0], line.Vectors[1]) == OutcodeState.partially) // 1 dot outside , 1 on our clipping window -> inside
                    {
                        line.isOutside = true;
                    }
                    else //partially shoudn't be able here --> here inside
                    {
                        line.isOutside = false;
                    }
                }

                //now points in line


            }

            //all triangles are already lines !!!

            //we are done here

        }

        /// <summary>
        /// Sets all outcodes from every Vector.
        /// </summary>
        private void SetAllLogicalOutcodes()
        {
            foreach (var item in this.Points)
            {
                item.SetOutCode(this.ClippingWindow);
            }

            foreach (var line in this.logicalLines)
            {
                foreach (var vect in line.Vectors)
                {
                    vect.SetOutCode(this.ClippingWindow);
                }
            }

            foreach (var triangle in this.logicalTriangles)
            {
                foreach (var vect in triangle.Vectors)
                {
                    vect.SetOutCode(this.ClippingWindow);
                }
            }
        }

        /// <summary>
        /// Checks and calcualtes Intersection for a line.
        /// </summary>
        /// <param name="v1">The starting point.</param>
        /// <param name="v2">The ending point.</param>
        /// <param name="ClippingWindowV1">The clipping starting point.</param>
        /// <param name="ClippingWindowV2">The ending clipping point.</param>
        private void CheckIntersectionLine(Vector v1, Vector v2, Vector ClippingWindowV1, Vector ClippingWindowV2, ref List<Vector> intersectionVectors)
        {
            Vector intersectionPoint = Cutter.CalculateIntersection(v1, v2, ClippingWindowV1, ClippingWindowV2);

            if (intersectionPoint.X != 0 && intersectionPoint.Y != 0)
            {
                if (intersectionVectors.Count == 0)
                {
                    //1 intersection point
                    //Vector realVector = new Vector(intersectionPoint, Logic.Index++);
                    //Vector realVector = new Vector(intersectionPoint);

                    this.calculatedLines.Add(new Line(v1, intersectionPoint));
                    this.calculatedLines.Add(new Line(intersectionPoint, v2));

                    //if (!this.AllVectors.Exists((v) => v.X == realVector.X && v.Y == realVector.Y))
                    //{
                    //    this.AllVectors.Add(realVector);
                    //}


                    intersectionVectors.Add(intersectionPoint);
                }
                else if (intersectionVectors.Count == 1)
                {

                    //Vector realVector = new Vector(intersectionPoint, Logic.Index++);
                    //Vector realVector = new Vector(intersectionPoint);

                    //found 2. intersection point...
                    this.calculatedLines.RemoveAt(this.calculatedLines.Count - 1); //last one was wrong
                    this.calculatedLines.Add(new Line(intersectionVectors[0], intersectionPoint));
                    //right one
                    this.calculatedLines.Add(new Line(intersectionPoint, v2));

                    //if (!this.AllVectors.Exists((v) => v.X == realVector.X && v.Y == realVector.Y))
                    //{
                    //    this.AllVectors.Add(realVector);
                    //}

                    intersectionVectors.Add(intersectionPoint);
                }


            }
            else
            {
                //but check if we have this line already...

                Line tempLine = new Line(v1, v2);

                if (!this.calculatedLines.Exists((line) => line.Vectors[0].X == tempLine.Vectors[0].X && line.Vectors[0].Y == tempLine.Vectors[0].Y))
                {
                    this.calculatedLines.Add(tempLine);
                }
            }
        }

        /// <summary>
        /// Checks and calcualtes Intersection for a triangle.
        /// </summary>
        /// <param name="triangle">The triangle.</param>
        private void CheckTriangle(Triangle triangle, ref List<Vector> intersectionPoints)
        {
            //check if we intersect with the ClippingWindow

            //actually we divide triangle into lines...

            for (int index = 0; index < triangle.Vectors.Count; index++)
            {
                intersectionPoints.Clear();
                if (index == triangle.Vectors.Count - 1)
                {
                    //check if we need to do sth. (intersection)
                    if (CheckOutcodes(triangle.Vectors[index], triangle.Vectors[0]) == OutcodeState.partially)
                    {
                        for (int i = 0; i < ClippingWindow.Vectors.Length; i++)
                        {
                            if (i == ClippingWindow.Vectors.Length - 1) // -2 ?
                            {
                                this.CheckIntersectionLine(triangle.Vectors[index], triangle.Vectors[0], ClippingWindow.Vectors[i], ClippingWindow.Vectors[0], ref intersectionPoints);
                            }
                            else
                            {
                                this.CheckIntersectionLine(triangle.Vectors[index], triangle.Vectors[0], ClippingWindow.Vectors[i], ClippingWindow.Vectors[i + 1], ref intersectionPoints);
                            }
                        }
                    }
                    else //add to lines collection
                    {
                        this.calculatedLines.Add(new Line(triangle.Vectors[index], triangle.Vectors[0]));
                    }
                }
                else //last line
                {
                    //check if we need to do sth. (intersection)
                    if (CheckOutcodes(triangle.Vectors[index], triangle.Vectors[index + 1]) == OutcodeState.partially)
                    {
                        for (int i = 0; i < ClippingWindow.Vectors.Length; i++)
                        {
                            if (i == ClippingWindow.Vectors.Length - 1) // -2 ?
                            {
                                this.CheckIntersectionLine(triangle.Vectors[index], triangle.Vectors[index + 1], ClippingWindow.Vectors[i], ClippingWindow.Vectors[0], ref intersectionPoints);
                            }
                            else
                            {
                                this.CheckIntersectionLine(triangle.Vectors[index], triangle.Vectors[index + 1], ClippingWindow.Vectors[i], ClippingWindow.Vectors[i + 1], ref intersectionPoints);
                            }
                        }
                    }
                    else //add to lines collection
                    {
                        this.calculatedLines.Add(new Line(triangle.Vectors[index], triangle.Vectors[index + 1]));
                    }
                }

            } //end for (int index = 0; index < triangle.Vectors.Count; index++)
        } //end CheckTriangle

        [System.Diagnostics.DebuggerHidden()]
        private OutcodeState CheckOutcodes(Vector v1, Vector v2)
        {
            string outcode1 = v1.Outcode.ToString("0000");
            string outcode2 = v2.Outcode.ToString("0000");

            string result = "";

            //compare via logiacal AND

            if (outcode1 == "0000" && outcode2 == "0000") // we are inside
            {
                return OutcodeState.inside;
            }

            if (outcode1 == "0000" || outcode2 == "0000") //partially
            {
                return OutcodeState.partially;
            }

            for (int i = 0; i < outcode1.Length; i++)
            {
                if (outcode1[i] == outcode2[i] && outcode1[i] == '0')
                {
                    result += "0";
                }
                else if (outcode1[i] == outcode2[i] && outcode1[i] == '1')
                {
                    result += "1";
                }
                else if (outcode1[i] == '0' && outcode2[i] == '1' || outcode1[i] == '1' && outcode2[i] == '0')
                {
                    result += "0";
                }
            }
            if (result == "0000") // 0010,0001 --> 0000 --> partially
            {
                return OutcodeState.partially;
            }

            if (result.Contains('1')) //we are outside
            {
                return OutcodeState.outside;
            }

            //hope we never get here...
            return OutcodeState.outside;
        }

        #endregion



        #region [ Picturebox Events  & LsitView Events]

        void lvLogger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Shift)
            {
                isKeyDown = true;
            }
        }

        void lvLogger_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Shift)
            {
                isKeyDown = false;
            }
        }


        void lvLogger_Click(object sender, EventArgs e)
        {

            foreach (var v in this.AllVectors)
            {
                v.Marked = false;
                // this.lvLogger.Items[count].SubItems[2].Text = v.Marked.ToString();
            }

            Program.fmMain.ClearClickedVectors();

            List<Vector> Clicked = new List<Vector>();

            try
            {
                for (int i = 0; i < lvLogger.SelectedIndices.Count; i++)
                {
                    int index = lvLogger.SelectedIndices[i];

                    this.AllVectors[index].Marked = true;

                    this.lvLogger.Items[index].SubItems[2].Text = this.AllVectors[index].Marked.ToString();

                    Clicked.Add(this.AllVectors[index]);

                }
            }
            catch (Exception)
            {
                //throw if you want
                //because of null
            }

            Program.fmMain.AddClickedVectors(Clicked.ToArray());
        }


        void lvLogger_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.CurrentOnMainFormSelectedVector != null) //we just want to show the Marked = true on the selected vector
            {
                int count = 0;
                foreach (var v in this.AllVectors)
                {
                    this.lvLogger.Items[count].SubItems[2].Text = v.Marked.ToString();
                    count++;
                }
            }
            else
            {
                int count = 0;
                foreach (var v in this.AllVectors)
                {
                    v.Marked = false;
                    this.lvLogger.Items[count].SubItems[2].Text = v.Marked.ToString();
                    count++;
                }
                Program.fmMain.ClearClickedVectors();
            }

            if (this.isKeyDown)
            {
                Program.fmMain.ClearClickedVectors();

                List<Vector> Clicked = new List<Vector>();

                try
                {
                    for (int i = 0; i < lvLogger.SelectedIndices.Count; i++)
                    {
                        int index = lvLogger.SelectedIndices[i];

                        this.AllVectors[index].Marked = true;

                        this.lvLogger.Items[index].SubItems[2].Text = this.AllVectors[index].Marked.ToString();

                        Clicked.Add(this.AllVectors[index]);

                    }
                }
                catch (Exception)
                {
                    //throw if you want
                }

                Program.fmMain.AddClickedVectors(Clicked.ToArray());
            }



        }


        /// <summary>
        /// Updates the ListView.
        /// </summary>
        public void UpdateLogger()
        {
            lvLogger.Items.Clear();


            //just show the real (logical) dots

            foreach (var v in this.Points)
            {
                lvLogger.Items.Add(new ListViewItem(new string[] { "X: " + v.X + " Y: " + v.Y, v.Outcode.ToString("0000"), v.Marked.ToString() }));
            }

            foreach (var line in this.logicalLines)
            {
                foreach (var v in line.Vectors)
                {
                    lvLogger.Items.Add(new ListViewItem(new string[] { "X: " + v.X + " Y: " + v.Y, v.Outcode.ToString("0000"), v.Marked.ToString() }));
                }
            }

            foreach (var triangle in this.logicalTriangles)
            {
                foreach (var v in triangle.Vectors)
                {
                    lvLogger.Items.Add(new ListViewItem(new string[] { "X: " + v.X + " Y: " + v.Y, v.Outcode.ToString("0000"), v.Marked.ToString() }));
                }
            }



        }


        void box_MouseUp(object sender, MouseEventArgs e)
        {

            if (this.drawingMode == DrawingMode.None)
            {
                int clickCount = 0;
                foreach (var v in this.AllVectors)
                {
                    if (v.isHitted(e.X, (gc.Parent.Height - e.Y)))
                    {
                        if (this.OnVectorClicked != null)
                        {
                            this.OnVectorClicked(v);
                            clickCount++;
                        }
                    }
                    else
                    {
                        v.Marked = false;
                    }
                }
                if (clickCount == 0) //we don't want any vector to be marked anymore
                {
                    //don't work if lvLogger has lost focus
                    //foreach (ListViewItem item in lvLogger.Items)
                    //{
                        //if (item.Selected)
                        //{
                        //    item.Selected = false;
                        //}
                    //}
                    UpdateLogger();

                    Program.fmMain.ClearClickedVectors();
                }
            }
            else
            {
                this.AddPoint(e.X, (gc.Parent.Height - e.Y));
            }
            //}


        }

        void box_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ShowCoordinates)
            {
                fmMain.Text = "Main Window | X: " + e.X + " Y: " + (gc.Parent.Height - e.Y);
            }
            else
            {
                fmMain.Text = "Main Window";
            }

        }

        void box_SizeChanged(object sender, EventArgs e)
        {
            ClippingWindow = new myRectangle(new Vector(gc.Parent.Width / 4, 3 * gc.Parent.Height / 4, false), new Vector(3 * (gc.Parent.Width / 4), (gc.Parent.Height / 4), false));
            UpdateLogger();
        }
        #endregion

    }
}
