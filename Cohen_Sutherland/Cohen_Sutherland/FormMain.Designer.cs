namespace Cohen_Sutherland
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSketchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawTrianglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CohenSutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOffonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxCohenSutherlandOpacy = new System.Windows.Forms.ToolStripTextBox();
            this.ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxCohenSutherlandFarbe = new System.Windows.Forms.ToolStripTextBox();
            this.dotRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxDotRadius = new System.Windows.Forms.ToolStripTextBox();
            this.MatricesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllMatricesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbStage = new System.Windows.Forms.PictureBox();
            this.ImageTimer = new System.Windows.Forms.Timer(this.components);
            this.lvLogger = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelTranslation = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataTranslationMatrix = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numTranslationY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numTranslationX = new System.Windows.Forms.NumericUpDown();
            this.panelRotation = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numRotation = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataRotationMatrix = new System.Windows.Forms.DataGridView();
            this.panelScale = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataScaleMatrix = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numScaleY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numScaleX = new System.Windows.Forms.NumericUpDown();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStage)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelTranslation.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTranslationMatrix)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslationX)).BeginInit();
            this.panelRotation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotation)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRotationMatrix)).BeginInit();
            this.panelScale.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataScaleMatrix)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.CohenSutherlandToolStripMenuItem,
            this.MatricesToolStripMenuItem,
            this.OptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSketchToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // newSketchToolStripMenuItem1
            // 
            this.newSketchToolStripMenuItem1.Name = "newSketchToolStripMenuItem1";
            this.newSketchToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newSketchToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.newSketchToolStripMenuItem1.Text = "New Skectch";
            this.newSketchToolStripMenuItem1.Click += new System.EventHandler(this.newSketchToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveAsToolStripMenuItem.Text = "Save As bmp";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawPointsToolStripMenuItem,
            this.drawLinesToolStripMenuItem,
            this.drawTrianglesToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // drawPointsToolStripMenuItem
            // 
            this.drawPointsToolStripMenuItem.Name = "drawPointsToolStripMenuItem";
            this.drawPointsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.drawPointsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.drawPointsToolStripMenuItem.Text = "Draw Points";
            this.drawPointsToolStripMenuItem.Click += new System.EventHandler(this.drawPointsToolStripMenuItem_Click);
            // 
            // drawLinesToolStripMenuItem
            // 
            this.drawLinesToolStripMenuItem.Name = "drawLinesToolStripMenuItem";
            this.drawLinesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.drawLinesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.drawLinesToolStripMenuItem.Text = "Draw Lines";
            this.drawLinesToolStripMenuItem.Click += new System.EventHandler(this.drawLinesToolStripMenuItem_Click);
            // 
            // drawTrianglesToolStripMenuItem
            // 
            this.drawTrianglesToolStripMenuItem.Name = "drawTrianglesToolStripMenuItem";
            this.drawTrianglesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.drawTrianglesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.drawTrianglesToolStripMenuItem.Text = "Draw Triangles";
            this.drawTrianglesToolStripMenuItem.Click += new System.EventHandler(this.drawTrianglesToolStripMenuItem_Click);
            // 
            // CohenSutherlandToolStripMenuItem
            // 
            this.CohenSutherlandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnOffonToolStripMenuItem,
            this.captionToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.ColorToolStripMenuItem,
            this.dotRadiusToolStripMenuItem});
            this.CohenSutherlandToolStripMenuItem.Name = "CohenSutherlandToolStripMenuItem";
            this.CohenSutherlandToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.CohenSutherlandToolStripMenuItem.Text = "Cohen Sutherland / Vectors";
            // 
            // turnOffonToolStripMenuItem
            // 
            this.turnOffonToolStripMenuItem.Name = "turnOffonToolStripMenuItem";
            this.turnOffonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.turnOffonToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.turnOffonToolStripMenuItem.Text = "Turn on";
            this.turnOffonToolStripMenuItem.Click += new System.EventHandler(this.turnOffonToolStripMenuItem_Click);
            // 
            // captionToolStripMenuItem
            // 
            this.captionToolStripMenuItem.Enabled = false;
            this.captionToolStripMenuItem.Name = "captionToolStripMenuItem";
            this.captionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.captionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.captionToolStripMenuItem.Text = "Caption";
            this.captionToolStripMenuItem.Click += new System.EventHandler(this.captionToolStripMenuItem_Click);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxCohenSutherlandOpacy});
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.opacityToolStripMenuItem.Text = "Opacy";
            // 
            // toolStripTextBoxCohenSutherlandOpacy
            // 
            this.toolStripTextBoxCohenSutherlandOpacy.Name = "toolStripTextBoxCohenSutherlandOpacy";
            this.toolStripTextBoxCohenSutherlandOpacy.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxCohenSutherlandOpacy.Text = "45";
            this.toolStripTextBoxCohenSutherlandOpacy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxCohenSutherlandOpacity_KeyUp);
            this.toolStripTextBoxCohenSutherlandOpacy.TextChanged += new System.EventHandler(this.toolStripTextBoxCohenSutherlandOpacy_TextChanged);
            // 
            // ColorToolStripMenuItem
            // 
            this.ColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxCohenSutherlandFarbe});
            this.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem";
            this.ColorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ColorToolStripMenuItem.Text = "Color";
            // 
            // toolStripTextBoxCohenSutherlandFarbe
            // 
            this.toolStripTextBoxCohenSutherlandFarbe.Name = "toolStripTextBoxCohenSutherlandFarbe";
            this.toolStripTextBoxCohenSutherlandFarbe.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxCohenSutherlandFarbe.Click += new System.EventHandler(this.toolStripTextBoxCohenSutherlandFarbe_Click);
            this.toolStripTextBoxCohenSutherlandFarbe.TextChanged += new System.EventHandler(this.toolStripTextBoxCohenSutherlandFarbe_TextChanged);
            // 
            // dotRadiusToolStripMenuItem
            // 
            this.dotRadiusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxDotRadius});
            this.dotRadiusToolStripMenuItem.Name = "dotRadiusToolStripMenuItem";
            this.dotRadiusToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.dotRadiusToolStripMenuItem.Text = "Dot radius";
            // 
            // toolStripTextBoxDotRadius
            // 
            this.toolStripTextBoxDotRadius.Name = "toolStripTextBoxDotRadius";
            this.toolStripTextBoxDotRadius.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxDotRadius.Text = "10";
            this.toolStripTextBoxDotRadius.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxDotRadius_KeyUp);
            this.toolStripTextBoxDotRadius.TextChanged += new System.EventHandler(this.toolStripTextBoxDotRadius_TextChanged);
            // 
            // MatricesToolStripMenuItem
            // 
            this.MatricesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translationToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.resetAllMatricesToolStripMenuItem});
            this.MatricesToolStripMenuItem.Name = "MatricesToolStripMenuItem";
            this.MatricesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.MatricesToolStripMenuItem.Text = "Matrices";
            // 
            // translationToolStripMenuItem
            // 
            this.translationToolStripMenuItem.Name = "translationToolStripMenuItem";
            this.translationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.translationToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.translationToolStripMenuItem.Text = "Translation";
            this.translationToolStripMenuItem.Click += new System.EventHandler(this.translationToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // resetAllMatricesToolStripMenuItem
            // 
            this.resetAllMatricesToolStripMenuItem.Name = "resetAllMatricesToolStripMenuItem";
            this.resetAllMatricesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetAllMatricesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.resetAllMatricesToolStripMenuItem.Text = "Reset all";
            this.resetAllMatricesToolStripMenuItem.Click += new System.EventHandler(this.resetAllMatricesToolStripMenuItem_Click);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCoordinatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "Options";
            // 
            // showCoordinatesToolStripMenuItem
            // 
            this.showCoordinatesToolStripMenuItem.Checked = true;
            this.showCoordinatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCoordinatesToolStripMenuItem.Name = "showCoordinatesToolStripMenuItem";
            this.showCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showCoordinatesToolStripMenuItem.Text = "Show coordinates";
            this.showCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.showCoordinatesToolStripMenuItem_Click_1);
            // 
            // pbStage
            // 
            this.pbStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbStage.Location = new System.Drawing.Point(0, 0);
            this.pbStage.Name = "pbStage";
            this.pbStage.Size = new System.Drawing.Size(571, 494);
            this.pbStage.TabIndex = 1;
            this.pbStage.TabStop = false;
            // 
            // ImageTimer
            // 
            this.ImageTimer.Tick += new System.EventHandler(this.ImageTimer_Tick);
            // 
            // lvLogger
            // 
            this.lvLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLogger.BackColor = System.Drawing.Color.White;
            this.lvLogger.FullRowSelect = true;
            this.lvLogger.GridLines = true;
            this.lvLogger.HideSelection = false;
            this.lvLogger.Location = new System.Drawing.Point(4, 3);
            this.lvLogger.Name = "lvLogger";
            this.lvLogger.Size = new System.Drawing.Size(284, 289);
            this.lvLogger.TabIndex = 2;
            this.lvLogger.UseCompatibleStateImageBehavior = false;
            this.lvLogger.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbStage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(864, 494);
            this.splitContainer1.SplitterDistance = 571;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvLogger);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panelTranslation);
            this.splitContainer2.Panel2.Controls.Add(this.panelRotation);
            this.splitContainer2.Panel2.Controls.Add(this.panelScale);
            this.splitContainer2.Size = new System.Drawing.Size(291, 494);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 7;
            // 
            // panelTranslation
            // 
            this.panelTranslation.Controls.Add(this.groupBox5);
            this.panelTranslation.Controls.Add(this.groupBox6);
            this.panelTranslation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTranslation.Location = new System.Drawing.Point(0, 390);
            this.panelTranslation.Name = "panelTranslation";
            this.panelTranslation.Size = new System.Drawing.Size(291, 195);
            this.panelTranslation.TabIndex = 6;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataTranslationMatrix);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(291, 138);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Translation Matrix";
            // 
            // dataTranslationMatrix
            // 
            this.dataTranslationMatrix.AllowUserToAddRows = false;
            this.dataTranslationMatrix.AllowUserToDeleteRows = false;
            this.dataTranslationMatrix.AllowUserToResizeRows = false;
            this.dataTranslationMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTranslationMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTranslationMatrix.Location = new System.Drawing.Point(3, 16);
            this.dataTranslationMatrix.Name = "dataTranslationMatrix";
            this.dataTranslationMatrix.ReadOnly = true;
            this.dataTranslationMatrix.Size = new System.Drawing.Size(285, 119);
            this.dataTranslationMatrix.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.numTranslationY);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.numTranslationX);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(291, 50);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Translation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y:";
            // 
            // numTranslationY
            // 
            this.numTranslationY.Location = new System.Drawing.Point(136, 19);
            this.numTranslationY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTranslationY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numTranslationY.Name = "numTranslationY";
            this.numTranslationY.Size = new System.Drawing.Size(57, 20);
            this.numTranslationY.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "X:";
            // 
            // numTranslationX
            // 
            this.numTranslationX.Location = new System.Drawing.Point(41, 19);
            this.numTranslationX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTranslationX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numTranslationX.Name = "numTranslationX";
            this.numTranslationX.Size = new System.Drawing.Size(57, 20);
            this.numTranslationX.TabIndex = 0;
            // 
            // panelRotation
            // 
            this.panelRotation.Controls.Add(this.groupBox2);
            this.panelRotation.Controls.Add(this.groupBox1);
            this.panelRotation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRotation.Location = new System.Drawing.Point(0, 195);
            this.panelRotation.Name = "panelRotation";
            this.panelRotation.Size = new System.Drawing.Size(291, 195);
            this.panelRotation.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numRotation);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 50);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotation";
            // 
            // numRotation
            // 
            this.numRotation.DecimalPlaces = 2;
            this.numRotation.Location = new System.Drawing.Point(26, 19);
            this.numRotation.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numRotation.Minimum = new decimal(new int[] {
            1080,
            0,
            0,
            -2147483648});
            this.numRotation.Name = "numRotation";
            this.numRotation.Size = new System.Drawing.Size(72, 20);
            this.numRotation.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataRotationMatrix);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 138);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotation Matrix";
            // 
            // dataRotationMatrix
            // 
            this.dataRotationMatrix.AllowUserToAddRows = false;
            this.dataRotationMatrix.AllowUserToDeleteRows = false;
            this.dataRotationMatrix.AllowUserToResizeRows = false;
            this.dataRotationMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRotationMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataRotationMatrix.Location = new System.Drawing.Point(3, 16);
            this.dataRotationMatrix.Name = "dataRotationMatrix";
            this.dataRotationMatrix.ReadOnly = true;
            this.dataRotationMatrix.Size = new System.Drawing.Size(285, 119);
            this.dataRotationMatrix.TabIndex = 0;
            // 
            // panelScale
            // 
            this.panelScale.Controls.Add(this.groupBox4);
            this.panelScale.Controls.Add(this.groupBox3);
            this.panelScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScale.Location = new System.Drawing.Point(0, 0);
            this.panelScale.Name = "panelScale";
            this.panelScale.Size = new System.Drawing.Size(291, 195);
            this.panelScale.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataScaleMatrix);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 138);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scale Matrix";
            // 
            // dataScaleMatrix
            // 
            this.dataScaleMatrix.AllowUserToAddRows = false;
            this.dataScaleMatrix.AllowUserToDeleteRows = false;
            this.dataScaleMatrix.AllowUserToResizeRows = false;
            this.dataScaleMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataScaleMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataScaleMatrix.Location = new System.Drawing.Point(3, 16);
            this.dataScaleMatrix.Name = "dataScaleMatrix";
            this.dataScaleMatrix.ReadOnly = true;
            this.dataScaleMatrix.Size = new System.Drawing.Size(285, 119);
            this.dataScaleMatrix.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numScaleY);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numScaleX);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 50);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            // 
            // numScaleY
            // 
            this.numScaleY.DecimalPlaces = 1;
            this.numScaleY.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numScaleY.Location = new System.Drawing.Point(136, 19);
            this.numScaleY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numScaleY.Name = "numScaleY";
            this.numScaleY.Size = new System.Drawing.Size(57, 20);
            this.numScaleY.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X:";
            // 
            // numScaleX
            // 
            this.numScaleX.DecimalPlaces = 1;
            this.numScaleX.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numScaleX.Location = new System.Drawing.Point(41, 19);
            this.numScaleX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numScaleX.Name = "numScaleX";
            this.numScaleX.Size = new System.Drawing.Size(57, 20);
            this.numScaleX.TabIndex = 0;
            // 
            // Updater
            // 
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelStatus.Text = "toolStripStatusLabel1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 543);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panelTranslation.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTranslationMatrix)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslationX)).EndInit();
            this.panelRotation.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRotation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataRotationMatrix)).EndInit();
            this.panelScale.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataScaleMatrix)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSketchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CohenSutherlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOffonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MatricesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbStage;
        private System.Windows.Forms.Timer ImageTimer;
        private System.Windows.Forms.ToolStripMenuItem drawPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawTrianglesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCoordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCohenSutherlandOpacy;
        private System.Windows.Forms.ToolStripMenuItem ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCohenSutherlandFarbe;
        private System.Windows.Forms.ListView lvLogger;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Panel panelRotation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numRotation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataRotationMatrix;
        private System.Windows.Forms.Panel panelScale;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataScaleMatrix;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numScaleY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numScaleX;
        private System.Windows.Forms.Panel panelTranslation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataTranslationMatrix;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTranslationY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numTranslationX;
        private System.Windows.Forms.ToolStripMenuItem translationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem resetAllMatricesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dotRadiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxDotRadius;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

