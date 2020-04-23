﻿namespace Maze
    {
        partial class MazeForm
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.nudInset = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBraid = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.pbMask = new System.Windows.Forms.PictureBox();
            this.btnLoadMask = new System.Windows.Forms.Button();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.btnLongestPath = new System.Windows.Forms.Button();
            this.btnDrawPath = new System.Windows.Forms.Button();
            this.btnColorize = new System.Windows.Forms.Button();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRNGSeed = new System.Windows.Forms.NumericUpDown();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAlgorithm = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStartPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPathLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbMaze = new System.Windows.Forms.PictureBox();
            this.cmsPickStart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rbWeave = new System.Windows.Forms.RadioButton();
            this.rbUpsilon = new System.Windows.Forms.RadioButton();
            this.rbTriangle = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbPolar = new System.Windows.Forms.RadioButton();
            this.tsmiPickStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPickEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBraid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRNGSeed)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.nudInset);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.nudBraid);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.pbMask);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadMask);
            this.splitContainer1.Panel1.Controls.Add(this.btnAnimate);
            this.splitContainer1.Panel1.Controls.Add(this.btnLongestPath);
            this.splitContainer1.Panel1.Controls.Add(this.btnDrawPath);
            this.splitContainer1.Panel1.Controls.Add(this.btnColorize);
            this.splitContainer1.Panel1.Controls.Add(this.btnPickColor);
            this.splitContainer1.Panel1.Controls.Add(this.pbColor);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.nudRNGSeed);
            this.splitContainer1.Panel1.Controls.Add(this.btnDraw);
            this.splitContainer1.Panel1.Controls.Add(this.btnStep);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cbAlgorithm);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.pbMaze);
            this.splitContainer1.Size = new System.Drawing.Size(1196, 919);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(17, 870);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Inset";
            // 
            // nudInset
            // 
            this.nudInset.DecimalPlaces = 1;
            this.nudInset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudInset.Location = new System.Drawing.Point(17, 890);
            this.nudInset.Margin = new System.Windows.Forms.Padding(4);
            this.nudInset.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudInset.Name = "nudInset";
            this.nudInset.Size = new System.Drawing.Size(160, 22);
            this.nudInset.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(17, 822);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Braid Ratio";
            // 
            // nudBraid
            // 
            this.nudBraid.DecimalPlaces = 1;
            this.nudBraid.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBraid.Location = new System.Drawing.Point(17, 842);
            this.nudBraid.Margin = new System.Windows.Forms.Padding(4);
            this.nudBraid.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudBraid.Name = "nudBraid";
            this.nudBraid.Size = new System.Drawing.Size(160, 22);
            this.nudBraid.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSquare);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(228, 176);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Style";
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Checked = true;
            this.rbSquare.Location = new System.Drawing.Point(8, 23);
            this.rbSquare.Margin = new System.Windows.Forms.Padding(4);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(75, 21);
            this.rbSquare.TabIndex = 0;
            this.rbSquare.TabStop = true;
            this.rbSquare.Text = "Square";
            this.rbSquare.UseVisualStyleBackColor = true;
            this.rbSquare.CheckedChanged += new System.EventHandler(this.rbSquare_CheckedChanged);
            // 
            // pbMask
            // 
            this.pbMask.Location = new System.Drawing.Point(16, 671);
            this.pbMask.Margin = new System.Windows.Forms.Padding(4);
            this.pbMask.Name = "pbMask";
            this.pbMask.Size = new System.Drawing.Size(160, 148);
            this.pbMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMask.TabIndex = 14;
            this.pbMask.TabStop = false;
            // 
            // btnLoadMask
            // 
            this.btnLoadMask.Location = new System.Drawing.Point(16, 635);
            this.btnLoadMask.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadMask.Name = "btnLoadMask";
            this.btnLoadMask.Size = new System.Drawing.Size(160, 28);
            this.btnLoadMask.TabIndex = 13;
            this.btnLoadMask.Text = "Load Mask";
            this.btnLoadMask.UseVisualStyleBackColor = true;
            this.btnLoadMask.Click += new System.EventHandler(this.btnLoadMask_Click);
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(16, 370);
            this.btnAnimate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(160, 28);
            this.btnAnimate.TabIndex = 12;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // btnLongestPath
            // 
            this.btnLongestPath.Location = new System.Drawing.Point(16, 599);
            this.btnLongestPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnLongestPath.Name = "btnLongestPath";
            this.btnLongestPath.Size = new System.Drawing.Size(160, 28);
            this.btnLongestPath.TabIndex = 11;
            this.btnLongestPath.Text = "Draw Longest Path";
            this.btnLongestPath.UseVisualStyleBackColor = true;
            this.btnLongestPath.Click += new System.EventHandler(this.btnLongestPath_Click);
            // 
            // btnDrawPath
            // 
            this.btnDrawPath.Location = new System.Drawing.Point(16, 564);
            this.btnDrawPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrawPath.Name = "btnDrawPath";
            this.btnDrawPath.Size = new System.Drawing.Size(160, 28);
            this.btnDrawPath.TabIndex = 10;
            this.btnDrawPath.Text = "Draw Path";
            this.btnDrawPath.UseVisualStyleBackColor = true;
            this.btnDrawPath.Click += new System.EventHandler(this.btnDrawPath_Click);
            // 
            // btnColorize
            // 
            this.btnColorize.Location = new System.Drawing.Point(16, 522);
            this.btnColorize.Margin = new System.Windows.Forms.Padding(4);
            this.btnColorize.Name = "btnColorize";
            this.btnColorize.Size = new System.Drawing.Size(160, 34);
            this.btnColorize.TabIndex = 9;
            this.btnColorize.Text = "Colorize";
            this.btnColorize.UseVisualStyleBackColor = true;
            this.btnColorize.Click += new System.EventHandler(this.btnColorize_Click);
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(63, 479);
            this.btnPickColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(113, 34);
            this.btnPickColor.TabIndex = 8;
            this.btnPickColor.Text = "Color";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Red;
            this.pbColor.Location = new System.Drawing.Point(16, 479);
            this.pbColor.Margin = new System.Windows.Forms.Padding(4);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(39, 34);
            this.pbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbColor.TabIndex = 7;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 442);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(17, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seed";
            // 
            // nudRNGSeed
            // 
            this.nudRNGSeed.Location = new System.Drawing.Point(17, 215);
            this.nudRNGSeed.Margin = new System.Windows.Forms.Padding(4);
            this.nudRNGSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudRNGSeed.Name = "nudRNGSeed";
            this.nudRNGSeed.Size = new System.Drawing.Size(160, 22);
            this.nudRNGSeed.TabIndex = 4;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(16, 406);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(160, 28);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.DrawMaze);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(17, 335);
            this.btnStep.Margin = new System.Windows.Forms.Padding(4);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(160, 28);
            this.btnStep.TabIndex = 3;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.StepMaze);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 297);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(160, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ResetMaze);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 244);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algorithm";
            // 
            // cbAlgorithm
            // 
            this.cbAlgorithm.FormattingEnabled = true;
            this.cbAlgorithm.Items.AddRange(new object[] {
            "BinaryTree"});
            this.cbAlgorithm.Location = new System.Drawing.Point(17, 263);
            this.cbAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.cbAlgorithm.Name = "cbAlgorithm";
            this.cbAlgorithm.Size = new System.Drawing.Size(160, 24);
            this.cbAlgorithm.TabIndex = 0;
            this.cbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.ResetMaze);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStartPoint,
            this.tsslEndPoint,
            this.tsslPathLength});
            this.statusStrip1.Location = new System.Drawing.Point(0, 893);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(898, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStartPoint
            // 
            this.tsslStartPoint.Name = "tsslStartPoint";
            this.tsslStartPoint.Size = new System.Drawing.Size(47, 20);
            this.tsslStartPoint.Text = "Start: ";
            // 
            // tsslEndPoint
            // 
            this.tsslEndPoint.Name = "tsslEndPoint";
            this.tsslEndPoint.Size = new System.Drawing.Size(41, 20);
            this.tsslEndPoint.Text = "End: ";
            // 
            // tsslPathLength
            // 
            this.tsslPathLength.Name = "tsslPathLength";
            this.tsslPathLength.Size = new System.Drawing.Size(93, 20);
            this.tsslPathLength.Text = "Path Length: ";
            // 
            // pbMaze
            // 
            this.pbMaze.BackColor = System.Drawing.Color.White;
            this.pbMaze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMaze.ContextMenuStrip = this.cmsPickStart;
            this.pbMaze.Location = new System.Drawing.Point(4, 4);
            this.pbMaze.Margin = new System.Windows.Forms.Padding(4);
            this.pbMaze.Name = "pbMaze";
            this.pbMaze.Size = new System.Drawing.Size(550, 550);
            this.pbMaze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMaze.TabIndex = 0;
            this.pbMaze.TabStop = false;
            this.pbMaze.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMaze_MouseDown);
            // 
            // cmsPickStart
            // 
            this.cmsPickStart.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPickStart.Name = "cmsPickStart";
            this.cmsPickStart.Size = new System.Drawing.Size(61, 4);
            // 
            // rbWeave
            // 
            this.rbWeave.Location = new System.Drawing.Point(0, 0);
            this.rbWeave.Name = "rbWeave";
            this.rbWeave.Size = new System.Drawing.Size(104, 24);
            this.rbWeave.TabIndex = 0;
            // 
            // rbUpsilon
            // 
            this.rbUpsilon.Location = new System.Drawing.Point(0, 0);
            this.rbUpsilon.Name = "rbUpsilon";
            this.rbUpsilon.Size = new System.Drawing.Size(104, 24);
            this.rbUpsilon.TabIndex = 0;
            // 
            // rbTriangle
            // 
            this.rbTriangle.Location = new System.Drawing.Point(0, 0);
            this.rbTriangle.Name = "rbTriangle";
            this.rbTriangle.Size = new System.Drawing.Size(104, 24);
            this.rbTriangle.TabIndex = 0;
            // 
            // rbHex
            // 
            this.rbHex.Location = new System.Drawing.Point(0, 0);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(104, 24);
            this.rbHex.TabIndex = 0;
            // 
            // rbPolar
            // 
            this.rbPolar.Location = new System.Drawing.Point(0, 0);
            this.rbPolar.Name = "rbPolar";
            this.rbPolar.Size = new System.Drawing.Size(104, 24);
            this.rbPolar.TabIndex = 0;
            // 
            // tsmiPickStart
            // 
            this.tsmiPickStart.Name = "tsmiPickStart";
            this.tsmiPickStart.Size = new System.Drawing.Size(157, 24);
            this.tsmiPickStart.Text = "Pick as Start";
            // 
            // tsmiPickEnd
            // 
            this.tsmiPickEnd.Name = "tsmiPickEnd";
            this.tsmiPickEnd.Size = new System.Drawing.Size(157, 24);
            this.tsmiPickEnd.Text = "Pick as End";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG files|*.png|JPEG files|*.jpg";
            // 
            // colorDialog1
            // 
            this.colorDialog1.SolidColorOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Images|*.png";
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 919);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MazeForm";
            this.ShowIcon = false;
            this.Text = "Mazes!";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudInset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBraid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRNGSeed)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaze)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.SplitContainer splitContainer1;
            private System.Windows.Forms.Button btnStep;
            private System.Windows.Forms.Button btnReset;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.ComboBox cbAlgorithm;
            private System.Windows.Forms.PictureBox pbMaze;
            private System.Windows.Forms.Button btnDraw;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.NumericUpDown nudRNGSeed;
            private System.Windows.Forms.Button btnSave;
            private System.Windows.Forms.SaveFileDialog saveFileDialog1;
            private System.Windows.Forms.Button btnPickColor;
            private System.Windows.Forms.PictureBox pbColor;
            private System.Windows.Forms.ColorDialog colorDialog1;
            private System.Windows.Forms.Button btnColorize;
            private System.Windows.Forms.ContextMenuStrip cmsPickStart;
            private System.Windows.Forms.ToolStripMenuItem tsmiPickStart;
            private System.Windows.Forms.StatusStrip statusStrip1;
            private System.Windows.Forms.ToolStripStatusLabel tsslStartPoint;
            private System.Windows.Forms.ToolStripStatusLabel tsslEndPoint;
            private System.Windows.Forms.ToolStripMenuItem tsmiPickEnd;
            private System.Windows.Forms.Button btnDrawPath;
            private System.Windows.Forms.Button btnLongestPath;
            private System.Windows.Forms.ToolStripStatusLabel tsslPathLength;
            private System.Windows.Forms.Button btnAnimate;
            private System.Windows.Forms.PictureBox pbMask;
            private System.Windows.Forms.Button btnLoadMask;
            private System.Windows.Forms.OpenFileDialog openFileDialog1;
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.RadioButton rbPolar;
            private System.Windows.Forms.RadioButton rbSquare;
            private System.Windows.Forms.RadioButton rbHex;
            private System.Windows.Forms.RadioButton rbTriangle;
            private System.Windows.Forms.RadioButton rbUpsilon;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.NumericUpDown nudBraid;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.NumericUpDown nudInset;
            private System.Windows.Forms.RadioButton rbWeave;
        }
    }