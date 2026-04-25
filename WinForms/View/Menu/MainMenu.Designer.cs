namespace MathsEngine.WinForms.View.Menu
{
    partial class MainMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            pureMenuButton = new Button();
            mechanicsButton = new Button();
            statisticsButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 21F);
            titleLabel.Location = new Point(220, 100);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(212, 38);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MATHS ENGINE";
            // 
            // pureMenuButton
            // 
            pureMenuButton.Location = new Point(101, 218);
            pureMenuButton.Name = "pureMenuButton";
            pureMenuButton.Size = new Size(444, 125);
            pureMenuButton.TabIndex = 1;
            pureMenuButton.Text = "Pure:\r\nPythagoras Theorem, Trigonometry, Matrices, CoordinateGeometry\r\n\r\n";
            pureMenuButton.UseVisualStyleBackColor = true;
            pureMenuButton.Click += pureMenuButton_Click;
            // 
            // mechanicsButton
            // 
            mechanicsButton.Location = new Point(103, 368);
            mechanicsButton.Name = "mechanicsButton";
            mechanicsButton.Size = new Size(444, 125);
            mechanicsButton.TabIndex = 2;
            mechanicsButton.Text = "Mechanics:\r\nUniform Acceleration\r\nNewton's Law's Equations\r\n\r\n";
            mechanicsButton.UseVisualStyleBackColor = true;
            mechanicsButton.Click += mechanicsButton_Click;
            // 
            // statisticsButton
            // 
            statisticsButton.Location = new Point(103, 518);
            statisticsButton.Name = "statisticsButton";
            statisticsButton.Size = new Size(446, 125);
            statisticsButton.TabIndex = 3;
            statisticsButton.Text = "Statistics:\r\nBivariate Analysis\r\nStandard Deviation\r\nMean, Median, Mode etc.\r\n";
            statisticsButton.UseVisualStyleBackColor = true;
            statisticsButton.Click += statisticsButton_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statisticsButton);
            Controls.Add(mechanicsButton);
            Controls.Add(pureMenuButton);
            Controls.Add(titleLabel);
            Name = "MainMenu";
            Size = new Size(650, 800);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button pureMenuButton;
        private Button mechanicsButton;
        private Button statisticsButton;
    }
}
