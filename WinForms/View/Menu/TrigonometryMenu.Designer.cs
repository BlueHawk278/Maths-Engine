namespace MathsEngine.WinForms.View.Menu
{
    partial class TrigonometryMenu
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
            titleLabel = new Label();
            rightAngleButton = new Button();
            nonRightAngleButton = new Button();
            trigGraphsButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 25F);
            titleLabel.Location = new Point(169, 50);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(317, 46);
            titleLabel.TabIndex = 14;
            titleLabel.Text = "Trigonometry Menu";
            // 
            // rightAngleButton
            // 
            rightAngleButton.Location = new Point(169, 172);
            rightAngleButton.Name = "rightAngleButton";
            rightAngleButton.Size = new Size(317, 75);
            rightAngleButton.TabIndex = 15;
            rightAngleButton.Text = "Right-Angled Triangle (SOH-CAH-TOA)";
            rightAngleButton.UseVisualStyleBackColor = true;
            rightAngleButton.Click += rightAngleButton_Click;
            // 
            // nonRightAngleButton
            // 
            nonRightAngleButton.Location = new Point(169, 279);
            nonRightAngleButton.Name = "nonRightAngleButton";
            nonRightAngleButton.Size = new Size(317, 75);
            nonRightAngleButton.TabIndex = 16;
            nonRightAngleButton.Text = "Non-Right-Angled Triangle (Sine Rule & Cosine Rule)";
            nonRightAngleButton.UseVisualStyleBackColor = true;
            // 
            // trigGraphsButton
            // 
            trigGraphsButton.Location = new Point(169, 375);
            trigGraphsButton.Name = "trigGraphsButton";
            trigGraphsButton.Size = new Size(317, 75);
            trigGraphsButton.TabIndex = 17;
            trigGraphsButton.Text = "Trigonometric Graphs and Equation";
            trigGraphsButton.UseVisualStyleBackColor = true;
            // 
            // TrigonometryMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(trigGraphsButton);
            Controls.Add(nonRightAngleButton);
            Controls.Add(rightAngleButton);
            Controls.Add(titleLabel);
            Name = "TrigonometryMenu";
            Text = "TrigonometryMenu";
            Controls.SetChildIndex(titleLabel, 0);
            Controls.SetChildIndex(rightAngleButton, 0);
            Controls.SetChildIndex(nonRightAngleButton, 0);
            Controls.SetChildIndex(trigGraphsButton, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button rightAngleButton;
        private Button nonRightAngleButton;
        private Button trigGraphsButton;
    }
}