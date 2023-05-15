
namespace TrafficLightsWinForms.Displays
{
    partial class ComplexIntersectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplexIntersectionForm));
            this.intersection = new System.Windows.Forms.PictureBox();
            this.tl2 = new System.Windows.Forms.PictureBox();
            this.tl3 = new System.Windows.Forms.PictureBox();
            this.tl1 = new System.Windows.Forms.PictureBox();
            this.tl4 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.intersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl4)).BeginInit();
            this.SuspendLayout();
            // 
            // intersection
            // 
            this.intersection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intersection.Image = ((System.Drawing.Image)(resources.GetObject("intersection.Image")));
            this.intersection.Location = new System.Drawing.Point(0, 0);
            this.intersection.Name = "intersection";
            this.intersection.Size = new System.Drawing.Size(802, 627);
            this.intersection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.intersection.TabIndex = 2;
            this.intersection.TabStop = false;
            // 
            // tl2
            // 
            this.tl2.BackColor = System.Drawing.Color.Transparent;
            this.tl2.Image = ((System.Drawing.Image)(resources.GetObject("tl2.Image")));
            this.tl2.Location = new System.Drawing.Point(536, 471);
            this.tl2.Name = "tl2";
            this.tl2.Size = new System.Drawing.Size(51, 66);
            this.tl2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tl2.TabIndex = 3;
            this.tl2.TabStop = false;
            // 
            // tl3
            // 
            this.tl3.BackColor = System.Drawing.Color.Transparent;
            this.tl3.Image = ((System.Drawing.Image)(resources.GetObject("tl3.Image")));
            this.tl3.Location = new System.Drawing.Point(617, 198);
            this.tl3.Name = "tl3";
            this.tl3.Size = new System.Drawing.Size(32, 71);
            this.tl3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tl3.TabIndex = 4;
            this.tl3.TabStop = false;
            // 
            // tl1
            // 
            this.tl1.BackColor = System.Drawing.Color.Transparent;
            this.tl1.Image = ((System.Drawing.Image)(resources.GetObject("tl1.Image")));
            this.tl1.Location = new System.Drawing.Point(224, 88);
            this.tl1.Name = "tl1";
            this.tl1.Size = new System.Drawing.Size(52, 66);
            this.tl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tl1.TabIndex = 5;
            this.tl1.TabStop = false;
            // 
            // tl4
            // 
            this.tl4.BackColor = System.Drawing.Color.Transparent;
            this.tl4.Image = ((System.Drawing.Image)(resources.GetObject("tl4.Image")));
            this.tl4.Location = new System.Drawing.Point(153, 354);
            this.tl4.Name = "tl4";
            this.tl4.Size = new System.Drawing.Size(32, 71);
            this.tl4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tl4.TabIndex = 6;
            this.tl4.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ComplexIntersectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 627);
            this.Controls.Add(this.tl4);
            this.Controls.Add(this.tl1);
            this.Controls.Add(this.tl3);
            this.Controls.Add(this.tl2);
            this.Controls.Add(this.intersection);
            this.Name = "ComplexIntersectionForm";
            this.Text = "ComplexIntersectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.intersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox intersection;
        private System.Windows.Forms.PictureBox tl2;
        private System.Windows.Forms.PictureBox tl3;
        private System.Windows.Forms.PictureBox tl1;
        private System.Windows.Forms.PictureBox tl4;
        private System.Windows.Forms.Timer timer;
    }
}