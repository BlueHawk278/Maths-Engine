namespace MathsEngine.WinForms.Forms
{
    partial class StatisticsMenu
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            TitleLabel = new Label();
            BivariateAnalysisButton = new Button();
            DispersionButton = new Button();
            AveragesButton = new Button();
            BackButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, editToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 20);
            toolStripMenuItem1.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 25F);
            TitleLabel.Location = new Point(202, 120);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(246, 46);
            TitleLabel.TabIndex = 8;
            TitleLabel.Text = "Statistics Menu";
            // 
            // BivariateAnalysisButton
            // 
            BivariateAnalysisButton.Location = new Point(125, 200);
            BivariateAnalysisButton.Name = "BivariateAnalysisButton";
            BivariateAnalysisButton.Size = new Size(400, 50);
            BivariateAnalysisButton.TabIndex = 9;
            BivariateAnalysisButton.Text = "Bivariate Analysis";
            BivariateAnalysisButton.UseVisualStyleBackColor = true;
            // 
            // DispersionButton
            // 
            DispersionButton.Location = new Point(125, 280);
            DispersionButton.Name = "DispersionButton";
            DispersionButton.Size = new Size(400, 50);
            DispersionButton.TabIndex = 10;
            DispersionButton.Text = "Dispersion / Standard Deviation";
            DispersionButton.UseVisualStyleBackColor = true;
            // 
            // AveragesButton
            // 
            AveragesButton.Location = new Point(125, 360);
            AveragesButton.Name = "AveragesButton";
            AveragesButton.Size = new Size(400, 50);
            AveragesButton.TabIndex = 11;
            AveragesButton.Text = "Averages / Measures of Dispersion";
            AveragesButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 50);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(100, 30);
            BackButton.TabIndex = 12;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // StatisticsMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(BackButton);
            Controls.Add(AveragesButton);
            Controls.Add(DispersionButton);
            Controls.Add(BivariateAnalysisButton);
            Controls.Add(TitleLabel);
            Controls.Add(menuStrip1);
            Name = "StatisticsMenu";
            Text = "StatisticsMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label TitleLabel;
        private Button BivariateAnalysisButton;
        private Button DispersionButton;
        private Button AveragesButton;
        private Button BackButton;
    }
}