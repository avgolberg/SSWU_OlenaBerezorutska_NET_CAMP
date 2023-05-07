
namespace TrafficLightsWinForms
{
    partial class FormDisplay
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisplay));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tl3 = new System.Windows.Forms.PictureBox();
            this.intersection = new System.Windows.Forms.PictureBox();
            this.tl2 = new System.Windows.Forms.PictureBox();
            this.tl4 = new System.Windows.Forms.PictureBox();
            this.tl1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tl3
            // 
            this.tl3.BackColor = System.Drawing.Color.Transparent;
            this.tl3.Image = ((System.Drawing.Image)(resources.GetObject("tl3.Image")));
            this.tl3.Location = new System.Drawing.Point(142, 194);
            this.tl3.Name = "tl3";
            this.tl3.Size = new System.Drawing.Size(32, 71);
            this.tl3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tl3.TabIndex = 0;
            this.tl3.TabStop = false;
            // 
            // intersection
            // 
            this.intersection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intersection.Image = ((System.Drawing.Image)(resources.GetObject("intersection.Image")));
            this.intersection.Location = new System.Drawing.Point(0, 0);
            this.intersection.Name = "intersection";
            this.intersection.Size = new System.Drawing.Size(800, 450);
            this.intersection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.intersection.TabIndex = 1;
            this.intersection.TabStop = false;
            // 
            // tl2
            // 
            this.tl2.BackColor = System.Drawing.Color.Transparent;
            this.tl2.Image = ((System.Drawing.Image)(resources.GetObject("tl2.Image")));
            this.tl2.Location = new System.Drawing.Point(387, 25);
            this.tl2.Name = "tl2";
            this.tl2.Size = new System.Drawing.Size(32, 71);
            this.tl2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tl2.TabIndex = 2;
            this.tl2.TabStop = false;
            // 
            // tl4
            // 
            this.tl4.BackColor = System.Drawing.Color.Transparent;
            this.tl4.Image = ((System.Drawing.Image)(resources.GetObject("tl4.Image")));
            this.tl4.Location = new System.Drawing.Point(610, 194);
            this.tl4.Name = "tl4";
            this.tl4.Size = new System.Drawing.Size(32, 71);
            this.tl4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tl4.TabIndex = 3;
            this.tl4.TabStop = false;
            // 
            // tl1
            // 
            this.tl1.BackColor = System.Drawing.Color.Transparent;
            this.tl1.Image = ((System.Drawing.Image)(resources.GetObject("tl1.Image")));
            this.tl1.Location = new System.Drawing.Point(387, 352);
            this.tl1.Name = "tl1";
            this.tl1.Size = new System.Drawing.Size(32, 71);
            this.tl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tl1.TabIndex = 4;
            this.tl1.TabStop = false;
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tl1);
            this.Controls.Add(this.tl4);
            this.Controls.Add(this.tl2);
            this.Controls.Add(this.tl3);
            this.Controls.Add(this.intersection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormDisplay";
            this.Text = "Traffic Lights";
            ((System.ComponentModel.ISupportInitialize)(this.tl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox tl3;
        private System.Windows.Forms.PictureBox intersection;
        private System.Windows.Forms.PictureBox tl2;
        private System.Windows.Forms.PictureBox tl4;
        private System.Windows.Forms.PictureBox tl1;
    }
}

