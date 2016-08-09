namespace Viewer17
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxCur = new System.Windows.Forms.TextBox();
            this.timerChangeAct = new System.Windows.Forms.Timer(this.components);
            this.labelDst = new System.Windows.Forms.Label();
            this.labelSrc = new System.Windows.Forms.Label();
            this.labelOpe = new System.Windows.Forms.Label();
            this.buttonMax = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonDir = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.BackColor = System.Drawing.Color.Transparent;
            this.labelTotal.ForeColor = System.Drawing.Color.Gray;
            this.labelTotal.Location = new System.Drawing.Point(392, 361);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(100, 12);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.Text = "/ Total";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.ForeColor = System.Drawing.Color.Gray;
            this.labelName.Location = new System.Drawing.Point(12, 361);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "FileName";
            // 
            // textBoxCur
            // 
            this.textBoxCur.BackColor = System.Drawing.Color.Black;
            this.textBoxCur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCur.ForeColor = System.Drawing.Color.Gray;
            this.textBoxCur.Location = new System.Drawing.Point(389, 346);
            this.textBoxCur.MaxLength = 5;
            this.textBoxCur.Name = "textBoxCur";
            this.textBoxCur.Size = new System.Drawing.Size(100, 12);
            this.textBoxCur.TabIndex = 6;
            this.textBoxCur.Text = "1";
            this.textBoxCur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timerChangeAct
            // 
            this.timerChangeAct.Tick += new System.EventHandler(this.timerChangeAct_Tick);
            // 
            // labelDst
            // 
            this.labelDst.AutoSize = true;
            this.labelDst.BackColor = System.Drawing.Color.Transparent;
            this.labelDst.ForeColor = System.Drawing.Color.Gray;
            this.labelDst.Location = new System.Drawing.Point(12, 420);
            this.labelDst.Name = "labelDst";
            this.labelDst.Size = new System.Drawing.Size(44, 12);
            this.labelDst.TabIndex = 10;
            this.labelDst.Text = "-> b.jpg";
            // 
            // labelSrc
            // 
            this.labelSrc.AutoSize = true;
            this.labelSrc.BackColor = System.Drawing.Color.Transparent;
            this.labelSrc.ForeColor = System.Drawing.Color.Gray;
            this.labelSrc.Location = new System.Drawing.Point(12, 406);
            this.labelSrc.Name = "labelSrc";
            this.labelSrc.Size = new System.Drawing.Size(28, 12);
            this.labelSrc.TabIndex = 9;
            this.labelSrc.Text = "a.jpg";
            // 
            // labelOpe
            // 
            this.labelOpe.AutoSize = true;
            this.labelOpe.BackColor = System.Drawing.Color.Transparent;
            this.labelOpe.ForeColor = System.Drawing.Color.Gray;
            this.labelOpe.Location = new System.Drawing.Point(12, 392);
            this.labelOpe.Name = "labelOpe";
            this.labelOpe.Size = new System.Drawing.Size(32, 12);
            this.labelOpe.TabIndex = 8;
            this.labelOpe.Text = "Move";
            // 
            // buttonMax
            // 
            this.buttonMax.BackColor = System.Drawing.Color.Transparent;
            this.buttonMax.FlatAppearance.BorderSize = 0;
            this.buttonMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMax.Image = global::Viewer17.Properties.Resources.arrow_out;
            this.buttonMax.Location = new System.Drawing.Point(674, 0);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(30, 28);
            this.buttonMax.TabIndex = 2;
            this.buttonMax.UseVisualStyleBackColor = false;
            this.buttonMax.Click += new System.EventHandler(this.buttonMax_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSetting.Image = ((System.Drawing.Image)(resources.GetObject("buttonSetting.Image")));
            this.buttonSetting.Location = new System.Drawing.Point(30, 0);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(30, 28);
            this.buttonSetting.TabIndex = 1;
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // buttonDir
            // 
            this.buttonDir.BackColor = System.Drawing.Color.Transparent;
            this.buttonDir.FlatAppearance.BorderSize = 0;
            this.buttonDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDir.Image = ((System.Drawing.Image)(resources.GetObject("buttonDir.Image")));
            this.buttonDir.Location = new System.Drawing.Point(0, 0);
            this.buttonDir.Name = "buttonDir";
            this.buttonDir.Size = new System.Drawing.Size(30, 28);
            this.buttonDir.TabIndex = 0;
            this.buttonDir.UseVisualStyleBackColor = false;
            this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.ForeColor = System.Drawing.Color.Black;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(12, 40);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(40, 300);
            this.buttonPrev.TabIndex = 3;
            this.buttonPrev.UseVisualStyleBackColor = false;
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.ForeColor = System.Drawing.Color.Black;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(452, 40);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(40, 300);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.UseVisualStyleBackColor = false;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.Black;
            this.pictureBoxPreview.Location = new System.Drawing.Point(52, 40);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxPreview.TabIndex = 1;
            this.pictureBoxPreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.buttonMax);
            this.Controls.Add(this.buttonSetting);
            this.Controls.Add(this.buttonDir);
            this.Controls.Add(this.labelOpe);
            this.Controls.Add(this.labelSrc);
            this.Controls.Add(this.labelDst);
            this.Controls.Add(this.textBoxCur);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.pictureBoxPreview);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewer17";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.Button buttonDir;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.TextBox textBoxCur;
        private System.Windows.Forms.Timer timerChangeAct;
        private System.Windows.Forms.Label labelDst;
        private System.Windows.Forms.Label labelSrc;
        private System.Windows.Forms.Label labelOpe;
    }
}