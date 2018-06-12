namespace Diem
{
    partial class LoadingAnimation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingAnimation));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.circleprocess = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loading ...";
            // 
            // circleprocess
            // 
            this.circleprocess.animated = true;
            this.circleprocess.animationIterval = 5;
            this.circleprocess.animationSpeed = 10;
            this.circleprocess.BackColor = System.Drawing.Color.White;
            this.circleprocess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circleprocess.BackgroundImage")));
            this.circleprocess.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.circleprocess.ForeColor = System.Drawing.Color.White;
            this.circleprocess.LabelVisible = false;
            this.circleprocess.LineProgressThickness = 8;
            this.circleprocess.LineThickness = 5;
            this.circleprocess.Location = new System.Drawing.Point(129, 282);
            this.circleprocess.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.circleprocess.MaxValue = 100;
            this.circleprocess.Name = "circleprocess";
            this.circleprocess.ProgressBackColor = System.Drawing.SystemColors.Control;
            this.circleprocess.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.circleprocess.Size = new System.Drawing.Size(75, 75);
            this.circleprocess.TabIndex = 3;
            this.circleprocess.Value = 0;
            // 
            // LoadingAnimation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(339, 551);
            this.Controls.Add(this.circleprocess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(800, 800);
            this.Name = "LoadingAnimation";
            this.Text = "LoadingAnimation";
            this.Load += new System.EventHandler(this.timer1_Tick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCircleProgressbar circleprocess;
    }
}