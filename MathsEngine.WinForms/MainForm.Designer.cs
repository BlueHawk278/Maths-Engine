namespace MathsEngine.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            topMenuStrip = new MenuStrip();
            sideBarPanel = new Panel();
            statisticsButton = new Button();
            mechanicsButton = new Button();
            pureButton = new Button();
            homeButton = new Button();
            mainContentPanel = new Panel();
            sideBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topMenuStrip
            // 
            topMenuStrip.Location = new Point(0, 0);
            topMenuStrip.Name = "topMenuStrip";
            topMenuStrip.Size = new Size(1264, 24);
            topMenuStrip.TabIndex = 0;
            topMenuStrip.Text = "TopMenu";
            // 
            // sideBarPanel
            // 
            sideBarPanel.Controls.Add(statisticsButton);
            sideBarPanel.Controls.Add(mechanicsButton);
            sideBarPanel.Controls.Add(pureButton);
            sideBarPanel.Controls.Add(homeButton);
            sideBarPanel.Dock = DockStyle.Left;
            sideBarPanel.Location = new Point(0, 24);
            sideBarPanel.Name = "sideBarPanel";
            sideBarPanel.Size = new Size(100, 657);
            sideBarPanel.TabIndex = 1;
            // 
            // statisticsButton
            // 
            statisticsButton.Location = new Point(12, 145);
            statisticsButton.Name = "statisticsButton";
            statisticsButton.Size = new Size(75, 23);
            statisticsButton.TabIndex = 3;
            statisticsButton.Text = "Statistics";
            statisticsButton.UseVisualStyleBackColor = true;
            // 
            // mechanicsButton
            // 
            mechanicsButton.Location = new Point(12, 105);
            mechanicsButton.Name = "mechanicsButton";
            mechanicsButton.Size = new Size(75, 23);
            mechanicsButton.TabIndex = 2;
            mechanicsButton.Text = "Mechanics";
            mechanicsButton.UseVisualStyleBackColor = true;
            // 
            // pureButton
            // 
            pureButton.Location = new Point(12, 65);
            pureButton.Name = "pureButton";
            pureButton.Size = new Size(75, 23);
            pureButton.TabIndex = 1;
            pureButton.Text = "Pure\r\n";
            pureButton.UseVisualStyleBackColor = true;
            pureButton.Click += this.pureButton_Click;
            // 
            // homeButton
            // 
            homeButton.Location = new Point(12, 25);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(75, 23);
            homeButton.TabIndex = 0;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = true;
            // 
            // mainContentPanel
            // 
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(100, 24);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1164, 657);
            mainContentPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(mainContentPanel);
            Controls.Add(sideBarPanel);
            Controls.Add(topMenuStrip);
            MainMenuStrip = topMenuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maths Engine";
            Load += Form1_Load;
            sideBarPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip topMenuStrip;
        private Panel sideBarPanel;
        private Panel mainContentPanel;
        private Button statisticsButton;
        private Button mechanicsButton;
        private Button pureButton;
        private Button homeButton;
    }
}
