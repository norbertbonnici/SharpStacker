namespace SharpStacker
{
    partial class SharpStacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpStacker));
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.contrastSlider = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalNoF = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFrameNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.alphaSlider = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbFine = new System.Windows.Forms.RadioButton();
            this.rbCoarse = new System.Windows.Forms.RadioButton();
            this.deleteImage = new System.Windows.Forms.Button();
            this.deletedStatus = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastSlider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaSlider)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(106, 30);
            this.btnUp.Margin = new System.Windows.Forms.Padding(6);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(132, 44);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.MoveImage);
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(106, 150);
            this.btnDown.Margin = new System.Windows.Forms.Padding(6);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(132, 44);
            this.btnDown.TabIndex = 0;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.MoveImage);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeft.Enabled = false;
            this.btnLeft.Location = new System.Drawing.Point(10, 30);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(6);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(96, 164);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.MoveImage);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRight.Enabled = false;
            this.btnRight.Location = new System.Drawing.Point(238, 30);
            this.btnRight.Margin = new System.Windows.Forms.Padding(6);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(96, 164);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.MoveImage);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openImage";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(740, 44);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenImage);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToDisk);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenu});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 36);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsMenu
            // 
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(324, 38);
            this.settingsMenu.Text = "Settings";
            this.settingsMenu.Click += new System.EventHandler(this.OpenSettings);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenu});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutMenu
            // 
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(179, 38);
            this.aboutMenu.Text = "About";
            this.aboutMenu.Click += new System.EventHandler(this.OpenAboutMenu);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(12, 92);
            this.btnNext.Margin = new System.Windows.Forms.Padding(6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(96, 44);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.MoveFrame);
            // 
            // btnBack
            // 
            this.btnBack.Enabled = false;
            this.btnBack.Location = new System.Drawing.Point(12, 37);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 44);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.MoveFrame);
            // 
            // contrastSlider
            // 
            this.contrastSlider.AccessibleName = "Contrast";
            this.contrastSlider.Enabled = false;
            this.contrastSlider.Location = new System.Drawing.Point(12, 62);
            this.contrastSlider.Margin = new System.Windows.Forms.Padding(6);
            this.contrastSlider.Maximum = 100;
            this.contrastSlider.Minimum = -100;
            this.contrastSlider.Name = "contrastSlider";
            this.contrastSlider.Size = new System.Drawing.Size(312, 90);
            this.contrastSlider.TabIndex = 4;
            this.contrastSlider.Tag = "Contrast";
            this.contrastSlider.TickFrequency = 10;
            this.contrastSlider.Value = 1;
            this.contrastSlider.Scroll += new System.EventHandler(this.ScrollContrastSlider);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnRight);
            this.groupBox1.Controls.Add(this.btnLeft);
            this.groupBox1.Location = new System.Drawing.Point(24, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.groupBox1.Size = new System.Drawing.Size(344, 204);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move image";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deletedStatus);
            this.groupBox2.Controls.Add(this.deleteImage);
            this.groupBox2.Controls.Add(this.lblTotalNoF);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblFrameNumber);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Location = new System.Drawing.Point(24, 285);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(344, 146);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Iterate Stack";
            // 
            // lblTotalNoF
            // 
            this.lblTotalNoF.AutoSize = true;
            this.lblTotalNoF.Location = new System.Drawing.Point(189, 90);
            this.lblTotalNoF.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalNoF.Name = "lblTotalNoF";
            this.lblTotalNoF.Size = new System.Drawing.Size(24, 25);
            this.lblTotalNoF.TabIndex = 8;
            this.lblTotalNoF.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "of";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFrameNumber
            // 
            this.lblFrameNumber.AutoSize = true;
            this.lblFrameNumber.Location = new System.Drawing.Point(189, 58);
            this.lblFrameNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFrameNumber.Name = "lblFrameNumber";
            this.lblFrameNumber.Size = new System.Drawing.Size(24, 25);
            this.lblFrameNumber.TabIndex = 8;
            this.lblFrameNumber.Text = "0";
            this.lblFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Page";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.alphaSlider);
            this.groupBox3.Controls.Add(this.contrastSlider);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(376, 162);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(340, 269);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control image";
            // 
            // alphaSlider
            // 
            this.alphaSlider.AccessibleName = "Contrast";
            this.alphaSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.alphaSlider.Enabled = false;
            this.alphaSlider.Location = new System.Drawing.Point(16, 171);
            this.alphaSlider.Margin = new System.Windows.Forms.Padding(6);
            this.alphaSlider.Maximum = 255;
            this.alphaSlider.Name = "alphaSlider";
            this.alphaSlider.Size = new System.Drawing.Size(312, 90);
            this.alphaSlider.TabIndex = 4;
            this.alphaSlider.Tag = "Alpha";
            this.alphaSlider.TickFrequency = 16;
            this.alphaSlider.Value = 255;
            this.alphaSlider.Scroll += new System.EventHandler(this.ScrollAlphaSlider);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Alpha";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contrast";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbFine);
            this.groupBox4.Controls.Add(this.rbCoarse);
            this.groupBox4.Location = new System.Drawing.Point(382, 54);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.groupBox4.Size = new System.Drawing.Size(334, 96);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tuner";
            // 
            // rbFine
            // 
            this.rbFine.AutoSize = true;
            this.rbFine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbFine.Location = new System.Drawing.Point(132, 43);
            this.rbFine.Margin = new System.Windows.Forms.Padding(6);
            this.rbFine.Name = "rbFine";
            this.rbFine.Size = new System.Drawing.Size(182, 34);
            this.rbFine.TabIndex = 1;
            this.rbFine.Text = "Fine";
            this.rbFine.UseVisualStyleBackColor = true;
            this.rbFine.CheckedChanged += new System.EventHandler(this.fineCoarse_CheckedChanged);
            // 
            // rbCoarse
            // 
            this.rbCoarse.AutoSize = true;
            this.rbCoarse.Checked = true;
            this.rbCoarse.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbCoarse.Location = new System.Drawing.Point(20, 43);
            this.rbCoarse.Margin = new System.Windows.Forms.Padding(6);
            this.rbCoarse.Name = "rbCoarse";
            this.rbCoarse.Size = new System.Drawing.Size(112, 34);
            this.rbCoarse.TabIndex = 0;
            this.rbCoarse.TabStop = true;
            this.rbCoarse.Text = "Coarse";
            this.rbCoarse.UseVisualStyleBackColor = true;
            this.rbCoarse.CheckedChanged += new System.EventHandler(this.fineCoarse_CheckedChanged);
            // 
            // deleteImage
            // 
            this.deleteImage.Enabled = false;
            this.deleteImage.Location = new System.Drawing.Point(240, 90);
            this.deleteImage.Name = "deleteImage";
            this.deleteImage.Size = new System.Drawing.Size(95, 43);
            this.deleteImage.TabIndex = 9;
            this.deleteImage.Text = "Delete";
            this.deleteImage.UseVisualStyleBackColor = true;
            this.deleteImage.Click += new System.EventHandler(this.deleteImage_Click);
            // 
            // deletedStatus
            // 
            this.deletedStatus.Enabled = false;
            this.deletedStatus.Location = new System.Drawing.Point(291, 36);
            this.deletedStatus.Name = "deletedStatus";
            this.deletedStatus.Size = new System.Drawing.Size(42, 38);
            this.deletedStatus.TabIndex = 10;
            this.deletedStatus.UseVisualStyleBackColor = true;
            // 
            // SharpStacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(740, 442);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SharpStacker";
            this.Text = "Sharp Stacker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastSlider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaSlider)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TrackBar contrastSlider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalNoF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFrameNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar alphaSlider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbFine;
        private System.Windows.Forms.RadioButton rbCoarse;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button deleteImage;
        private System.Windows.Forms.Button deletedStatus;
    }
}

