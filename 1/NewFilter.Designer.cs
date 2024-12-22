namespace _1
{
    partial class NewFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFilter));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Open = new System.Windows.Forms.Button();
            this.detection = new System.Windows.Forms.Button();
            this.Smoothing = new System.Windows.Forms.Button();
            this.Blur = new System.Windows.Forms.Button();
            this.Laplacian = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(8, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 35);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(88, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 297);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.Color.Transparent;
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.Location = new System.Drawing.Point(442, 4);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(46, 43);
            this.Open.TabIndex = 2;
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // detection
            // 
            this.detection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.detection.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detection.ForeColor = System.Drawing.Color.White;
            this.detection.Location = new System.Drawing.Point(12, 398);
            this.detection.Name = "detection";
            this.detection.Size = new System.Drawing.Size(100, 45);
            this.detection.TabIndex = 3;
            this.detection.Text = "canny edge";
            this.detection.UseVisualStyleBackColor = false;
            this.detection.Click += new System.EventHandler(this.detection_Click);
            // 
            // Smoothing
            // 
            this.Smoothing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.Smoothing.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Smoothing.ForeColor = System.Drawing.Color.White;
            this.Smoothing.Location = new System.Drawing.Point(138, 398);
            this.Smoothing.Name = "Smoothing";
            this.Smoothing.Size = new System.Drawing.Size(100, 45);
            this.Smoothing.TabIndex = 4;
            this.Smoothing.Text = "Smoothing";
            this.Smoothing.UseVisualStyleBackColor = false;
            this.Smoothing.Click += new System.EventHandler(this.Smoothing_Click);
            // 
            // Blur
            // 
            this.Blur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.Blur.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blur.ForeColor = System.Drawing.Color.White;
            this.Blur.Location = new System.Drawing.Point(388, 398);
            this.Blur.Name = "Blur";
            this.Blur.Size = new System.Drawing.Size(100, 45);
            this.Blur.TabIndex = 5;
            this.Blur.Text = "Blur";
            this.Blur.UseVisualStyleBackColor = false;
            this.Blur.Click += new System.EventHandler(this.Blur_Click);
            // 
            // Laplacian
            // 
            this.Laplacian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.Laplacian.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Laplacian.ForeColor = System.Drawing.Color.White;
            this.Laplacian.Location = new System.Drawing.Point(264, 398);
            this.Laplacian.Name = "Laplacian";
            this.Laplacian.Size = new System.Drawing.Size(100, 45);
            this.Laplacian.TabIndex = 6;
            this.Laplacian.Text = "Laplacian";
            this.Laplacian.UseVisualStyleBackColor = false;
            this.Laplacian.Click += new System.EventHandler(this.Laplacian_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Your Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Open";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Back";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(3, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(493, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "_________________________________________________________________________________" +
    "";
            // 
            // NewFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(500, 461);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Blur);
            this.Controls.Add(this.Laplacian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Smoothing);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.detection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "NewFilter";
            this.Text = "NewFilter";
            this.Load += new System.EventHandler(this.NewFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button detection;
        private System.Windows.Forms.Button Smoothing;
        private System.Windows.Forms.Button Blur;
        private System.Windows.Forms.Button Laplacian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}