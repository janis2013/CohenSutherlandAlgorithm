/*
 * This project is free for ANY use.
 * That's all, have fun!
 * 
 * - Janis Dähne
*/





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using Cohen_Sutherland.GraphicCores;
using Cohen_Sutherland._2DObject;

using System.Collections.ObjectModel;

namespace Cohen_Sutherland
{
    public partial class FormMain : Form
    {



        public Logic logic;

        private SaveFileDialog dialog;

        private ColorDialog cdialog;

        private int TimerCount = 0;



        private List<Vector> CurrentClickedVectors = new List<Vector>();


        //matrix Deltas

        float prevNumTransformationX = 0;
        float prevNumTransformationY = 0;

        float prevNumScalationX = 0;
        float prevNumScalationY = 0;

        float prevNumRotationDegrees = 0;

        public bool NumWasSetByProgram = false;

        public bool NextPointIsPointOfOrigin = false;

        private bool ShowCoordinates = true;

        private Vector prevSelected = new Vector(-1, -1, false);


        public FormMain()
        {
            InitializeComponent();


            cdialog = new ColorDialog();

            cdialog.Color = GraphicCore.NormalDotColor.Color;
            toolStripTextBoxCohenSutherlandFarbe.BackColor = cdialog.Color;

            dialog = new SaveFileDialog();
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.OverwritePrompt = true;
            dialog.Filter = " Bitmaps (*.bmp)|*.bmp|All Files (*.*)|*.*";
            dialog.Title = "Save as Bitmap";

            //Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"

            toolStripTextBoxCohenSutherlandOpacy.LostFocus += new EventHandler(toolStripTextBoxCohenSutherlandOpacity_LostFocus);
            toolStripTextBoxDotRadius.LostFocus += new EventHandler(toolStripTextBoxDotRadius_LostFocus);

            lvLogger.Columns.Add(new ColumnHeader() { Text = "Position", Width = 100 });
            lvLogger.Columns.Add(new ColumnHeader() { Text = "Outcode", Width = 70 });
            lvLogger.Columns.Add(new ColumnHeader() { Text = "Marked", Width = 70 });


            logic = new Logic(this.pbStage, this, lvLogger);

            logic.OnVectorClicked += new Action<Vector>(logic_OnVectorClicked);


            drawPointsToolStripMenuItem_Click(this, new EventArgs());

            lvLogger.HideSelection = false; //to show selection even if listview lost focus

            lvLogger.Focus();

        }



        public void AddClickedVectors(params Vector[] ClickedVectors)
        {

            foreach (var v in ClickedVectors)
            {
                this.CurrentClickedVectors.Add(v);
            }
            AssignMatrices();
        }

        public void ClearClickedVectors()
        {
            this.CurrentClickedVectors.Clear();

            this.panelRotation.Enabled = false;
            this.panelScale.Enabled = false;
            this.panelTranslation.Enabled = false;
        }

        public void AssignMatrices()
        {

            if (this.CurrentClickedVectors.Count > 0)
            {
                Vector v = this.CurrentClickedVectors[this.CurrentClickedVectors.Count - 1];
                this.dataTranslationMatrix.DataSource = v.Translation;
                this.dataScaleMatrix.DataSource = v.Scale;
                this.dataRotationMatrix.DataSource = v.Rotation;

                NumWasSetByProgram = true;


                if (this.CurrentClickedVectors.Count == 1)
                {

                    this.numTranslationX.Value = (decimal)v.Translation.Rows[0].Field<float>(2);
                    this.numTranslationY.Value = (decimal)v.Translation.Rows[1].Field<float>(2);

                    this.numScaleX.Value = (decimal)v.Scale.Rows[0].Field<float>(0);
                    this.numScaleY.Value = (decimal)v.Scale.Rows[1].Field<float>(1);

                    this.numRotation.Value = (decimal)v.degrees;

                    prevNumTransformationX = v.Translation.Rows[0].Field<float>(2);
                    prevNumTransformationY = v.Translation.Rows[1].Field<float>(2);

                    prevNumScalationX = v.Scale.Rows[0].Field<float>(0);
                    prevNumScalationY = v.Scale.Rows[1].Field<float>(1);

                    prevNumRotationDegrees = v.degrees;


                }
                else if (this.CurrentClickedVectors.Count > 1) // we need to get the right delta for all
                {
                    this.numTranslationX.Value = 0;
                    this.numTranslationY.Value = 0;

                    this.numScaleX.Value = 0;
                    this.numScaleY.Value = 0;

                    this.numRotation.Value = 0;

                    prevNumTransformationX = 0;
                    prevNumTransformationY = 0;

                    prevNumScalationX = 0;
                    prevNumScalationY = 0;

                    prevNumRotationDegrees = 0;

                }

                NumWasSetByProgram = false;


                this.panelRotation.Enabled = true;
                this.panelScale.Enabled = true;
                this.panelTranslation.Enabled = true;
            }

        }


        void logic_OnVectorClicked(Vector obj)
        {
            //this.CurrentClickedVectors.Clear();

            //this.CurrentClickedVectors.Add(obj);

            this.ClearClickedVectors();


            prevSelected.Marked = false;

            int index = logic.AllVectors.FindIndex((vect) => vect.X == obj.X && vect.Y == obj.Y);

            foreach (ListViewItem item in lvLogger.Items)
            {
                item.Selected = false;
            }

            logic.CurrentOnMainFormSelectedVector = obj; //we just want to show the Marked = true on the selected vector

            obj.Marked = true;

            if (index != -1)
            {
                lvLogger.Items[index].Selected = true;
            }

            this.AddClickedVectors(obj);

            prevSelected = obj;

            logic.CurrentOnMainFormSelectedVector = null; //now we can clear all Marked = ? states

            lvLogger.Focus(); // to show selection

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            ImageTimer.Enabled = true;

            panelTranslation.Visible = true;
            panelRotation.Visible = false;
            panelScale.Visible = false;

            translationToolStripMenuItem.Checked = true;
            rotationToolStripMenuItem.Checked = false;
            scaleToolStripMenuItem.Checked = false;

            //matrix stuff - assign

            numTranslationX.ValueChanged += new EventHandler(numTranslationX_ValueChanged);
            numTranslationY.ValueChanged += new EventHandler(numTranslationY_ValueChanged);

            numScaleX.ValueChanged += new EventHandler(numScaleX_ValueChanged);
            numScaleY.ValueChanged += new EventHandler(numScaleY_ValueChanged);

            numRotation.ValueChanged += new EventHandler(numRotation_ValueChanged);
        }




        void numRotation_ValueChanged(object sender, EventArgs e)
        {
            if (!NumWasSetByProgram)
            {
                //calculate delta
                float Delta = (float)numRotation.Value - prevNumRotationDegrees;

                //assign new value to matrices
                foreach (var v in this.CurrentClickedVectors)
                {
                    v.AssignToRotationMatrix(Delta);
                }

                prevNumRotationDegrees = (float)numRotation.Value;
                logic.UpdateLogger();
            }

        }

        void numScaleY_ValueChanged(object sender, EventArgs e)
        {
            if (!NumWasSetByProgram)
            {
                //calculate delta
                float Delta = (float)numScaleY.Value - prevNumScalationY;

                //assign new value to matrices
                foreach (var v in this.CurrentClickedVectors)
                {
                    v.AssignToScalationMatrix_Y(Delta);
                }

                prevNumScalationY = (float)numScaleY.Value;
                logic.UpdateLogger();
            }
        }

        void numScaleX_ValueChanged(object sender, EventArgs e)
        {
            if (!NumWasSetByProgram)
            {
                //calculate delta
                float Delta = (float)numScaleX.Value - prevNumScalationX;

                //assign new value to matrices
                foreach (var v in this.CurrentClickedVectors)
                {
                    v.AssignToScalationMatrix_X(Delta);
                }

                prevNumScalationX = (float)numScaleX.Value;
                logic.UpdateLogger();
            }
        }

        void numTranslationY_ValueChanged(object sender, EventArgs e)
        {
            if (!NumWasSetByProgram)
            {
                //calculate delta
                float Delta = (float)numTranslationY.Value - prevNumTransformationY;

                //assign new value to matrices
                foreach (var v in this.CurrentClickedVectors)
                {
                    v.AssignToTranslationMatrix_Y(Delta);
                }

                prevNumTransformationY = (float)numTranslationY.Value;
                logic.UpdateLogger();
            }
        }

        void numTranslationX_ValueChanged(object sender, EventArgs e)
        {
            if (!NumWasSetByProgram)
            {
                //calculate delta
                float Delta = (float)numTranslationX.Value - prevNumTransformationX;

                //assign new value to matrices
                foreach (var v in this.CurrentClickedVectors)
                {
                    v.AssignToTranslationMatrix_X(Delta);
                }

                prevNumTransformationX = (float)numTranslationX.Value;
                logic.UpdateLogger();
            }
        }



        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            this.pbStage.Image = logic.GetImage();

        }



        private void drawPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawPointsToolStripMenuItem.Checked == false)
            {
                logic.drawingMode = DrawingMode.Points;

                drawPointsToolStripMenuItem.Checked = true;
                drawTrianglesToolStripMenuItem.Checked = false;
                drawLinesToolStripMenuItem.Checked = false;
                toolStripStatusLabelStatus.Text = "Drawing Mode: Points";
            }
            else
            {
                logic.drawingMode = DrawingMode.None;
                drawPointsToolStripMenuItem.Checked = false;
                toolStripStatusLabelStatus.Text = "Drawing Mode: None";
            }

        }

        private void drawTrianglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawTrianglesToolStripMenuItem.Checked == false)
            {
                logic.drawingMode = DrawingMode.Triangles;
                drawTrianglesToolStripMenuItem.Checked = true;
                drawPointsToolStripMenuItem.Checked = false;
                drawLinesToolStripMenuItem.Checked = false;
                toolStripStatusLabelStatus.Text = "Drawing Mode: Triangles";
            }
            else
            {
                logic.drawingMode = DrawingMode.None;
                drawTrianglesToolStripMenuItem.Checked = false;
                toolStripStatusLabelStatus.Text = "Drawing Mode: None";
            }

        }

        private void drawLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drawLinesToolStripMenuItem.Checked == false)
            {
                logic.drawingMode = DrawingMode.Lines;
                drawLinesToolStripMenuItem.Checked = true;
                drawTrianglesToolStripMenuItem.Checked = false;
                drawPointsToolStripMenuItem.Checked = false;
                toolStripStatusLabelStatus.Text = "Drawing Mode: Lines";

            }
            else
            {
                logic.drawingMode = DrawingMode.None;
                drawLinesToolStripMenuItem.Checked = false;
                toolStripStatusLabelStatus.Text = "Drawing Mode: None";
            }
        }


        private void turnOffonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (turnOffonToolStripMenuItem.Checked == true) // turn off
            {
                turnOffonToolStripMenuItem.Checked = false;
                turnOffonToolStripMenuItem.Text = "Turn on";
                logic.UseCohenSutherlandAlgorithm = false;
                captionToolStripMenuItem.Checked = true;
                captionToolStripMenuItem_Click(this, new EventArgs());
                captionToolStripMenuItem.Enabled = false;
            }
            else //turn on
            {
                turnOffonToolStripMenuItem.Checked = true;
                turnOffonToolStripMenuItem.Text = "Turn off";
                logic.UseCohenSutherlandAlgorithm = true;
                captionToolStripMenuItem.Enabled = true;

            }

            this.logic.UpdateLogger();
        }

        private void captionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (captionToolStripMenuItem.Checked == true) // don't draw caption
            {
                captionToolStripMenuItem.Checked = false;
                logic.DrawCaption = false;

            }
            else //draw caption
            {
                captionToolStripMenuItem.Checked = true;
                logic.DrawCaption = true;

            }
        }

        private void showCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showCoordinatesToolStripMenuItem.Checked == true)
            {
                logic.ShowCoordinates = false;
                showCoordinatesToolStripMenuItem.Checked = false;
            }
            else
            {
                logic.ShowCoordinates = true;
                showCoordinatesToolStripMenuItem.Checked = true;
            }
        }

        private void newSketchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            logic.ClearImage();
            //logic.gc.Point_of_Origin.ResetCoordinatesAndMatrices();
            this.ClearClickedVectors();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dialog.FileName;
                Bitmap currImage = logic.GetImage();
                currImage.Save(filename);
            }


        }

        private void toolStripTextBoxCohenSutherlandOpacy_TextChanged(object sender, EventArgs e)
        {
            string text = toolStripTextBoxCohenSutherlandOpacy.Text.Trim();
            if (text != "")
            {
                string newText = "";
                for (int i = 0; i < (text.Length > 3 ? 3 : text.Length); i++)
                {
                    if (char.IsDigit(text[i]))
                    {
                        newText += text[i];
                    }
                }
                toolStripTextBoxCohenSutherlandOpacy.Text = newText;
                toolStripTextBoxCohenSutherlandOpacy.SelectionStart = toolStripTextBoxCohenSutherlandOpacy.Text.Length;

            }

        }

        void toolStripTextBoxCohenSutherlandOpacity_LostFocus(object sender, EventArgs e)
        {
            //if you click to exit the menu better disable drawing
            logic.drawingMode = DrawingMode.None;
            drawLinesToolStripMenuItem.Checked = false;
            drawTrianglesToolStripMenuItem.Checked = false;
            drawPointsToolStripMenuItem.Checked = false;


            if (toolStripTextBoxCohenSutherlandOpacy.Text == "")
            {
                toolStripTextBoxCohenSutherlandOpacy.Text = "45";
                GraphicCore.Cohen_Sutherland_Opacity = 45;
            }
            else
            {
                int opacy;
                bool success = int.TryParse(toolStripTextBoxCohenSutherlandOpacy.Text, out opacy);
                if (success && opacy >= 0 && opacy <= 255)
                {
                    GraphicCore.Cohen_Sutherland_Opacity = opacy;
                }
                else
                {
                    //throw whatever
                }
            }

        }


        private void toolStripTextBoxCohenSutherlandFarbe_Click(object sender, EventArgs e)
        {
            if (cdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GraphicCore.NormalDotColor = new SolidBrush(cdialog.Color);
                GraphicCore.NormalLineColor = new Pen(cdialog.Color, GraphicCore.NormalLineColor.Width);
                //GraphicCore.Cohen_Sutherland_LinesColor = new Pen(cdialog.Color, GraphicCore.Cohen_Sutherland_LinesColor.Width);

                toolStripTextBoxCohenSutherlandFarbe.BackColor = cdialog.Color;
            }

            this.Focus();

        }

        private void toolStripTextBoxCohenSutherlandFarbe_TextChanged(object sender, EventArgs e)
        {
            toolStripTextBoxCohenSutherlandFarbe.Text = "";

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            //updates the lazy listview
            if (TimerCount == 2)
            {
                TimerCount = 0;
                Updater.Stop();
                return;
            }
            if (logic != null)
            {
                logic.UpdateLogger();
            }
            TimerCount++;


        }

        private void refresListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logic != null)
            {
                logic.UpdateLogger();
            }
        }

        private void translationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panelTranslation.Visible = true;
            panelRotation.Visible = false;
            panelScale.Visible = false;

            translationToolStripMenuItem.Checked = true;
            rotationToolStripMenuItem.Checked = false;
            scaleToolStripMenuItem.Checked = false;

        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTranslation.Visible = false;
            panelRotation.Visible = false;
            panelScale.Visible = true;

            translationToolStripMenuItem.Checked = false;
            rotationToolStripMenuItem.Checked = false;
            scaleToolStripMenuItem.Checked = true;
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTranslation.Visible = false;
            panelRotation.Visible = true;
            panelScale.Visible = false;

            translationToolStripMenuItem.Checked = false;
            rotationToolStripMenuItem.Checked = true;
            scaleToolStripMenuItem.Checked = false;

        }


        private void resetAllMatricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var v in this.CurrentClickedVectors)
            {
                v.SetUpTranslationMatrix();
            }
            foreach (var v in this.CurrentClickedVectors)
            {
                v.SetUpScaleMatrix();
            }
            foreach (var v in this.CurrentClickedVectors)
            {
                v.SetUpRotationMatrix();
            }
            AssignMatrices();
            logic.UpdateLogger();
        }

        private void setNewCoordOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.NextPointIsPointOfOrigin = true;
        }

        private void resetCoordOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //logic.gc.Point_of_Origin.X = 0;
            //logic.gc.Point_of_Origin.Y = 0;
        }

        private void showCoordinatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (showCoordinatesToolStripMenuItem.Checked == true)
            {
                showCoordinatesToolStripMenuItem.Checked = false;
                logic.ShowCoordinates = showCoordinatesToolStripMenuItem.Checked;
            }
            else
            {
                showCoordinatesToolStripMenuItem.Checked = true;
            }




        }


        private void toolStripTextBoxCohenSutherlandOpacity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripTextBoxCohenSutherlandOpacity_LostFocus(this, new EventArgs());
            }
        }


        private void toolStripTextBoxDotRadius_TextChanged(object sender, EventArgs e)
        {
            string text = toolStripTextBoxDotRadius.Text.Trim();
            if (text != "")
            {
                string newText = "";
                for (int i = 0; i < (text.Length > 2 ? 2 : text.Length); i++)
                {
                    if (char.IsDigit(text[i]))
                    {
                        newText += text[i];
                    }
                }
                toolStripTextBoxDotRadius.Text = newText;
                toolStripTextBoxDotRadius.SelectionStart = toolStripTextBoxDotRadius.Text.Length;

            }
        }

        private void toolStripTextBoxDotRadius_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripTextBoxDotRadius_LostFocus(this, new EventArgs());
            }
        }

        void toolStripTextBoxDotRadius_LostFocus(object sender, EventArgs e)
        {

            if (toolStripTextBoxDotRadius.Text == "")
            {
                toolStripTextBoxDotRadius.Text = "10";
                GraphicCore.DotRadius = 10;
            }
            else
            {
                int dotradius;
                bool success = int.TryParse(toolStripTextBoxDotRadius.Text, out dotradius);
                if (success && dotradius >= 0 && dotradius <= 99)
                {
                    GraphicCore.DotRadius = dotradius;
                }
                else
                {
                    //throw whatever
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was written by Janis Dähne.\nIt's free for any use.","About");
        }






    }
}
