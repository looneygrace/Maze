using System;
using System.Windows.Forms;

namespace Maze
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDrawPath = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStartPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPathLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nudInset = new System.Windows.Forms.NumericUpDown();
            this.btnLongestPath = new System.Windows.Forms.Button();
            this.pbMaze = new System.Windows.Forms.PictureBox();
            this.cmsPickStart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnLoadMask = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.nudBraid = new System.Windows.Forms.NumericUpDown();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.pbMask = new System.Windows.Forms.PictureBox();
            this.btnColorize = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.cbAlgorithm = new System.Windows.Forms.ComboBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbWeave = new System.Windows.Forms.RadioButton();
            this.tsmiPickStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPickEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBraid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnDrawPath);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.nudInset);
            this.splitContainer1.Panel2.Controls.Add(this.btnLongestPath);
            this.splitContainer1.Panel2.Controls.Add(this.pbMaze);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoadMask);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.btnPickColor);
            this.splitContainer1.Panel2.Controls.Add(this.nudBraid);
            this.splitContainer1.Panel2.Controls.Add(this.btnAnimate);
            this.splitContainer1.Panel2.Controls.Add(this.pbMask);
            this.splitContainer1.Panel2.Controls.Add(this.btnColorize);
            this.splitContainer1.Panel2.Controls.Add(this.btnStep);
            this.splitContainer1.Panel2.Controls.Add(this.cbAlgorithm);
            this.splitContainer1.Panel2.Controls.Add(this.btnDraw);
            this.splitContainer1.Panel2.Controls.Add(this.pbColor);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1196, 919);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(3, -3);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(225, 49);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ResetMaze);
            // 
            // btnDrawPath
            // 
            this.btnDrawPath.Location = new System.Drawing.Point(20, 149);
            this.btnDrawPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrawPath.Name = "btnDrawPath";
            this.btnDrawPath.Size = new System.Drawing.Size(225, 63);
            this.btnDrawPath.TabIndex = 10;
            this.btnDrawPath.Text = "Draw Path";
            this.btnDrawPath.UseVisualStyleBackColor = true;
            this.btnDrawPath.Click += new System.EventHandler(this.btnDrawPath_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 81);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(225, 60);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.rbSquare);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(228, 57);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Style";
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Checked = true;
            this.rbSquare.Location = new System.Drawing.Point(115, 13);
            this.rbSquare.Margin = new System.Windows.Forms.Padding(4);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(75, 21);
            this.rbSquare.TabIndex = 0;
            this.rbSquare.TabStop = true;
            this.rbSquare.Text = "Square";
            this.rbSquare.UseVisualStyleBackColor = true;
            this.rbSquare.CheckedChanged += new System.EventHandler(this.rbSquare_CheckedChanged);
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
            move += new KeyPressEventHandler( Window_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(17, 1092);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Inset";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nudInset
            // 
            this.nudInset.DecimalPlaces = 1;
            this.nudInset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudInset.Location = new System.Drawing.Point(17, 1112);
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
            // btnLongestPath
            // 
            this.btnLongestPath.Location = new System.Drawing.Point(16, 0);
            this.btnLongestPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnLongestPath.Name = "btnLongestPath";
            this.btnLongestPath.Size = new System.Drawing.Size(160, 28);
            this.btnLongestPath.TabIndex = 11;
            this.btnLongestPath.Text = "Draw Longest Path";
            this.btnLongestPath.UseVisualStyleBackColor = true;
            this.btnLongestPath.Click += new System.EventHandler(this.btnLongestPath_Click);
            // 
            // pbMaze
            // 
            this.pbMaze.BackColor = System.Drawing.Color.White;
            this.pbMaze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMaze.ContextMenuStrip = this.cmsPickStart;
            this.pbMaze.Location = new System.Drawing.Point(16, 36);
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
            // btnLoadMask
            // 
            this.btnLoadMask.Location = new System.Drawing.Point(47, 97);
            this.btnLoadMask.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadMask.Name = "btnLoadMask";
            this.btnLoadMask.Size = new System.Drawing.Size(160, 28);
            this.btnLoadMask.TabIndex = 13;
            this.btnLoadMask.Text = "Load Mask";
            this.btnLoadMask.UseVisualStyleBackColor = true;
            this.btnLoadMask.Click += new System.EventHandler(this.btnLoadMask_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(17, 1044);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Braid Ratio";
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(-27, -10);
            this.btnPickColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(113, 34);
            this.btnPickColor.TabIndex = 8;
            this.btnPickColor.Text = "Color";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);

            // 
            // nudBraid
            // 
            this.nudBraid.DecimalPlaces = 1;
            this.nudBraid.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBraid.Location = new System.Drawing.Point(17, 1064);
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
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(4, -7);
            this.btnAnimate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(160, 28);
            this.btnAnimate.TabIndex = 12;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // pbMask
            // 
            this.pbMask.Location = new System.Drawing.Point(16, 893);
            this.pbMask.Margin = new System.Windows.Forms.Padding(4);
            this.pbMask.Name = "pbMask";
            this.pbMask.Size = new System.Drawing.Size(160, 148);
            this.pbMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMask.TabIndex = 14;
            this.pbMask.TabStop = false;
            // 
            // btnColorize
            // 
            this.btnColorize.Location = new System.Drawing.Point(16, -13);
            this.btnColorize.Margin = new System.Windows.Forms.Padding(4);
            this.btnColorize.Name = "btnColorize";
            this.btnColorize.Size = new System.Drawing.Size(160, 34);
            this.btnColorize.TabIndex = 9;
            this.btnColorize.Text = "Colorize";
            this.btnColorize.UseVisualStyleBackColor = true;
            this.btnColorize.Click += new System.EventHandler(this.btnColorize_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(28, -10);
            this.btnStep.Margin = new System.Windows.Forms.Padding(4);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(160, 28);
            this.btnStep.TabIndex = 3;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.StepMaze);
            // 
            // cbAlgorithm
            // 
            this.cbAlgorithm.FormattingEnabled = true;
            this.cbAlgorithm.Items.AddRange(new object[] {
            "BinaryTree"});
            this.cbAlgorithm.Location = new System.Drawing.Point(47, -3);
            this.cbAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.cbAlgorithm.Name = "cbAlgorithm";
            this.cbAlgorithm.Size = new System.Drawing.Size(160, 24);
            this.cbAlgorithm.TabIndex = 0;
            this.cbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.ResetMaze);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(47, -4);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(160, 28);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.DrawMaze);
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Red;
            this.pbColor.Location = new System.Drawing.Point(125, -26);
            this.pbColor.Margin = new System.Windows.Forms.Padding(4);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(39, 34);
            this.pbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbColor.TabIndex = 7;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(54, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algorithm";
           
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MazeForm";
            this.ShowIcon = false;
            this.Text = "Mazes!";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBraid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnPickColor;
        private KeyPressEventHandler move;
       
       
        
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
        private System.Windows.Forms.RadioButton rbSquare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBraid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudInset;
        private System.Windows.Forms.RadioButton rbWeave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timer1;


    }
    }
 