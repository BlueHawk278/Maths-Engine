namespace WinForms.View
{
    partial class BaseCalculatorForm
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
            TitleLabel = new Label();
            InputPanel = new Panel();
            ResultPanel = new Panel();
            ResultValueLabel = new Label();
            ResultPanelLabel = new Label();
            CalculateButton = new Button();
            ClearButton = new Button();
            StepsTextBox = new RichTextBox();
            ResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 18F);
            TitleLabel.Location = new Point(206, 48);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(0, 32);
            TitleLabel.TabIndex = 2;
            // 
            // InputPanel
            // 
            InputPanel.Location = new Point(12, 116);
            InputPanel.Name = "InputPanel";
            InputPanel.Size = new Size(273, 215);
            InputPanel.TabIndex = 3;
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(ResultValueLabel);
            ResultPanel.Controls.Add(ResultPanelLabel);
            ResultPanel.Location = new Point(12, 337);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(610, 77);
            ResultPanel.TabIndex = 4;
            // 
            // ResultValueLabel
            // 
            ResultValueLabel.AutoSize = true;
            ResultValueLabel.Location = new Point(23, 46);
            ResultValueLabel.Name = "ResultValueLabel";
            ResultValueLabel.Size = new Size(0, 15);
            ResultValueLabel.TabIndex = 3;
            // 
            // ResultPanelLabel
            // 
            ResultPanelLabel.AutoSize = true;
            ResultPanelLabel.Location = new Point(18, 18);
            ResultPanelLabel.Name = "ResultPanelLabel";
            ResultPanelLabel.Size = new Size(39, 15);
            ResultPanelLabel.TabIndex = 2;
            ResultPanelLabel.Text = "Result";
            // 
            // CalculateButton
            // 
            CalculateButton.Font = new Font("Segoe UI", 15F);
            CalculateButton.Location = new Point(348, 689);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(150, 60);
            CalculateButton.TabIndex = 6;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Segoe UI", 15F);
            ClearButton.Location = new Point(147, 688);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(150, 60);
            ClearButton.TabIndex = 7;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // StepsTextBox
            // 
            StepsTextBox.Location = new Point(12, 420);
            StepsTextBox.Name = "StepsTextBox";
            StepsTextBox.ReadOnly = true;
            StepsTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            StepsTextBox.Size = new Size(610, 262);
            StepsTextBox.TabIndex = 9;
            StepsTextBox.Text = "";
            // 
            // BaseCalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(StepsTextBox);
            Controls.Add(ClearButton);
            Controls.Add(CalculateButton);
            Controls.Add(ResultPanel);
            Controls.Add(InputPanel);
            Controls.Add(TitleLabel);
            Name = "BaseCalculatorForm";
            Controls.SetChildIndex(TitleLabel, 0);
            Controls.SetChildIndex(InputPanel, 0);
            Controls.SetChildIndex(ResultPanel, 0);
            Controls.SetChildIndex(CalculateButton, 0);
            Controls.SetChildIndex(ClearButton, 0);
            Controls.SetChildIndex(StepsTextBox, 0);
            Controls.SetChildIndex(BackButton, 0);
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label TitleLabel;
        protected Panel InputPanel;
        protected Panel ResultPanel;
        protected Label ResultPanelLabel;
        protected Label ResultValueLabel;
        protected Button CalculateButton;
        protected Button ClearButton;
        protected RichTextBox StepsTextBox;
    }
}