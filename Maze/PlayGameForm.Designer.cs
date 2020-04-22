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
            this.btnDrawPath = new System.Windows.Forms.Button();
            this.btnColorize = new System.Windows.Forms.Button();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStartPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPathLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbMaze = new System.Windows.Forms.PictureBox();
            this.cmsPickStart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPickStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPickEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaze)).BeginInit();
            this.cmsPickStart.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnColorize);
            this.splitContainer1.Panel1.Controls.Add(this.btnPickColor);
            this.splitContainer1.Panel1.Controls.Add(this.pbColor);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnDraw);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.pbMaze);
            this.splitContainer1.Panel2.Controls.Add(this.btnReset);
            this.splitContainer1.Size = new System.Drawing.Size(1196, 919);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
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
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(63, 240);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(160, 28);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.DrawMaze);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(725, 13);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(160, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ResetMaze);
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
            this.cmsPickStart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPickStart,
            this.tsmiPickEnd});
            this.cmsPickStart.Name = "cmsPickStart";
            this.cmsPickStart.Size = new System.Drawing.Size(158, 52);
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
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaze)).EndInit();
            this.cmsPickStart.ResumeLayout(false);
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