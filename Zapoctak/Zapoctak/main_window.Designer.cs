namespace Zapoctak
{
    partial class main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_window));
            this.Board = new System.Windows.Forms.Panel();
            this.InfoPanel = new System.Windows.Forms.Label();
            this.Settings = new Zapoctak.ButtonEllipse();
            this.Save = new Zapoctak.ButtonEllipse();
            this.DijkstraButton = new Zapoctak.ButtonEllipse();
            this.AddVertex = new Zapoctak.ButtonEllipse();
            this.AddEdge = new Zapoctak.ButtonEllipse();
            this.RemoveVertex = new Zapoctak.ButtonEllipse();
            this.RemoveEdge = new Zapoctak.ButtonEllipse();
            this.buttonEllipse2 = new Zapoctak.ButtonEllipse();
            this.ShowMenu = new Zapoctak.ButtonEllipse();
            this.SuspendLayout();
            // 
            // Board
            // 
            this.Board.Location = new System.Drawing.Point(0, -1);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(1478, 631);
            this.Board.TabIndex = 10;
            this.Board.Click += new System.EventHandler(this.Board_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.AutoSize = true;
            this.InfoPanel.Location = new System.Drawing.Point(12, 635);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(97, 17);
            this.InfoPanel.TabIndex = 11;
            this.InfoPanel.Text = "INFOPANEL...";
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.SystemColors.Control;
            this.Settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Settings.BackgroundImage")));
            this.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Settings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Settings.Location = new System.Drawing.Point(0, 551);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(69, 63);
            this.Settings.TabIndex = 9;
            this.Settings.UseVisualStyleBackColor = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            this.Settings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseDown);
            this.Settings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseUp);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.Control;
            this.Save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Save.BackgroundImage")));
            this.Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Save.Location = new System.Drawing.Point(0, 482);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(69, 63);
            this.Save.TabIndex = 8;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            this.Save.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Save_MouseDown);
            this.Save.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Save_MouseUp);
            // 
            // DijkstraButton
            // 
            this.DijkstraButton.BackColor = System.Drawing.SystemColors.Control;
            this.DijkstraButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DijkstraButton.BackgroundImage")));
            this.DijkstraButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DijkstraButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DijkstraButton.Location = new System.Drawing.Point(0, 413);
            this.DijkstraButton.Name = "DijkstraButton";
            this.DijkstraButton.Size = new System.Drawing.Size(69, 63);
            this.DijkstraButton.TabIndex = 7;
            this.DijkstraButton.UseVisualStyleBackColor = false;
            this.DijkstraButton.Click += new System.EventHandler(this.DijkstraButton_Click);
            this.DijkstraButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DijkstraButton_MouseDown);
            this.DijkstraButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DijkstraButton_MouseUp);
            // 
            // AddVertex
            // 
            this.AddVertex.BackColor = System.Drawing.SystemColors.Control;
            this.AddVertex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddVertex.BackgroundImage")));
            this.AddVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddVertex.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddVertex.Location = new System.Drawing.Point(0, 68);
            this.AddVertex.Name = "AddVertex";
            this.AddVertex.Size = new System.Drawing.Size(69, 63);
            this.AddVertex.TabIndex = 6;
            this.AddVertex.UseVisualStyleBackColor = false;
            this.AddVertex.Click += new System.EventHandler(this.AddVertex_Click);
            this.AddVertex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddVertex_MouseDown);
            this.AddVertex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AddVertex_MouseUp);
            // 
            // AddEdge
            // 
            this.AddEdge.BackColor = System.Drawing.SystemColors.Control;
            this.AddEdge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddEdge.BackgroundImage")));
            this.AddEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddEdge.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddEdge.Location = new System.Drawing.Point(0, 137);
            this.AddEdge.Name = "AddEdge";
            this.AddEdge.Size = new System.Drawing.Size(69, 63);
            this.AddEdge.TabIndex = 5;
            this.AddEdge.UseVisualStyleBackColor = false;
            this.AddEdge.Click += new System.EventHandler(this.AddEdge_Click);
            this.AddEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddEdge_MouseDown);
            this.AddEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AddEdge_MouseUp);
            // 
            // RemoveVertex
            // 
            this.RemoveVertex.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveVertex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveVertex.BackgroundImage")));
            this.RemoveVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveVertex.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RemoveVertex.Location = new System.Drawing.Point(0, 206);
            this.RemoveVertex.Name = "RemoveVertex";
            this.RemoveVertex.Size = new System.Drawing.Size(69, 63);
            this.RemoveVertex.TabIndex = 4;
            this.RemoveVertex.UseVisualStyleBackColor = false;
            this.RemoveVertex.Click += new System.EventHandler(this.RemoveVertex_Click);
            this.RemoveVertex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RemoveVertex_MouseDown);
            this.RemoveVertex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveVertex_MouseUp);
            // 
            // RemoveEdge
            // 
            this.RemoveEdge.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveEdge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveEdge.BackgroundImage")));
            this.RemoveEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveEdge.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RemoveEdge.Location = new System.Drawing.Point(0, 275);
            this.RemoveEdge.Name = "RemoveEdge";
            this.RemoveEdge.Size = new System.Drawing.Size(69, 63);
            this.RemoveEdge.TabIndex = 3;
            this.RemoveEdge.UseVisualStyleBackColor = false;
            this.RemoveEdge.Click += new System.EventHandler(this.RemoveEdge_Click);
            this.RemoveEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RemoveEdge_MouseDown);
            this.RemoveEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveEdge_MouseUp);
            // 
            // buttonEllipse2
            // 
            this.buttonEllipse2.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEllipse2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEllipse2.BackgroundImage")));
            this.buttonEllipse2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEllipse2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonEllipse2.Location = new System.Drawing.Point(0, 344);
            this.buttonEllipse2.Name = "buttonEllipse2";
            this.buttonEllipse2.Size = new System.Drawing.Size(69, 63);
            this.buttonEllipse2.TabIndex = 2;
            this.buttonEllipse2.UseVisualStyleBackColor = false;
            this.buttonEllipse2.Click += new System.EventHandler(this.buttonEllipse2_Click);
            this.buttonEllipse2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonEllipse2_MouseDown);
            this.buttonEllipse2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonEllipse2_MouseUp);
            // 
            // ShowMenu
            // 
            this.ShowMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ShowMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShowMenu.BackgroundImage")));
            this.ShowMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ShowMenu.ImageKey = "(žádná)";
            this.ShowMenu.Location = new System.Drawing.Point(0, -1);
            this.ShowMenu.Name = "ShowMenu";
            this.ShowMenu.Size = new System.Drawing.Size(69, 63);
            this.ShowMenu.TabIndex = 1;
            this.ShowMenu.UseVisualStyleBackColor = false;
            this.ShowMenu.Click += new System.EventHandler(this.buttonEllipse1_Click);
            this.ShowMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowMenu_MouseDown);
            this.ShowMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowMenu_MouseUp);
            // 
            // main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1479, 661);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DijkstraButton);
            this.Controls.Add(this.AddVertex);
            this.Controls.Add(this.AddEdge);
            this.Controls.Add(this.RemoveVertex);
            this.Controls.Add(this.RemoveEdge);
            this.Controls.Add(this.buttonEllipse2);
            this.Controls.Add(this.ShowMenu);
            this.Controls.Add(this.Board);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "main_window";
            this.Text = "Graph Editor";
            this.Load += new System.EventHandler(this.main_window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ButtonEllipse ShowMenu;
        private ButtonEllipse buttonEllipse2;
        private ButtonEllipse RemoveEdge;
        private ButtonEllipse RemoveVertex;
        private ButtonEllipse AddEdge;
        private ButtonEllipse AddVertex;
        private ButtonEllipse DijkstraButton;
        private ButtonEllipse Save;
        private ButtonEllipse Settings;
        private System.Windows.Forms.Panel Board;
        private System.Windows.Forms.Label InfoPanel;
    }
}