namespace Zapoctak
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonEllipse1 = new Zapoctak.ButtonEllipse();
            this.buttonEllipse2 = new Zapoctak.ButtonEllipse();
            this.buttonEllipse3 = new Zapoctak.ButtonEllipse();
            this.buttonEllipse4 = new Zapoctak.ButtonEllipse();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // buttonEllipse1
            // 
            this.buttonEllipse1.Location = new System.Drawing.Point(421, 57);
            this.buttonEllipse1.Name = "buttonEllipse1";
            this.buttonEllipse1.Size = new System.Drawing.Size(183, 41);
            this.buttonEllipse1.TabIndex = 0;
            this.buttonEllipse1.Text = "New Graph";
            this.buttonEllipse1.UseVisualStyleBackColor = true;
            this.buttonEllipse1.Click += new System.EventHandler(this.buttonEllipse1_Click);
            // 
            // buttonEllipse2
            // 
            this.buttonEllipse2.Location = new System.Drawing.Point(421, 104);
            this.buttonEllipse2.Name = "buttonEllipse2";
            this.buttonEllipse2.Size = new System.Drawing.Size(183, 41);
            this.buttonEllipse2.TabIndex = 1;
            this.buttonEllipse2.Text = "Open Graph";
            this.buttonEllipse2.UseVisualStyleBackColor = true;
            this.buttonEllipse2.Click += new System.EventHandler(this.buttonEllipse2_Click);
            // 
            // buttonEllipse3
            // 
            this.buttonEllipse3.Location = new System.Drawing.Point(421, 151);
            this.buttonEllipse3.Name = "buttonEllipse3";
            this.buttonEllipse3.Size = new System.Drawing.Size(192, 61);
            this.buttonEllipse3.TabIndex = 2;
            this.buttonEllipse3.Text = "Programming Documentation (Czech)";
            this.buttonEllipse3.UseVisualStyleBackColor = true;
            this.buttonEllipse3.Click += new System.EventHandler(this.buttonEllipse3_Click);
            // 
            // buttonEllipse4
            // 
            this.buttonEllipse4.Location = new System.Drawing.Point(421, 209);
            this.buttonEllipse4.Name = "buttonEllipse4";
            this.buttonEllipse4.Size = new System.Drawing.Size(183, 52);
            this.buttonEllipse4.TabIndex = 3;
            this.buttonEllipse4.Text = "User Documentation (Czech)";
            this.buttonEllipse4.UseVisualStyleBackColor = true;
            this.buttonEllipse4.Click += new System.EventHandler(this.buttonEllipse4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(421, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Directed";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(523, 13);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 21);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Weighted";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(625, 384);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonEllipse4);
            this.Controls.Add(this.buttonEllipse3);
            this.Controls.Add(this.buttonEllipse2);
            this.Controls.Add(this.buttonEllipse1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Graph Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonEllipse buttonEllipse1;
        private ButtonEllipse buttonEllipse2;
        private ButtonEllipse buttonEllipse3;
        private ButtonEllipse buttonEllipse4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

