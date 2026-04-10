namespace MathsEngine.WinForms.View.Mechanics
{
    partial class NewtonsLawsForm
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
        // a comment to force a change
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ForceRadioButton = new RadioButton();
            MassRadioButton = new RadioButton();
            AccelerationRadioButton = new RadioButton();
            ForceLabel = new Label();
            MassLabel = new Label();
            AccelerationLabel = new Label();
            ForceTextBox = new TextBox();
            MassTextBox = new TextBox();
            AccelerationTextBox = new TextBox();
            ResultLabel = new Label();
            InputPanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // InputPanel
            // 
            InputPanel.Controls.Add(AccelerationTextBox);
            InputPanel.Controls.Add(MassTextBox);
            InputPanel.Controls.Add(ForceTextBox);
            InputPanel.Controls.Add(AccelerationLabel);
            InputPanel.Controls.Add(MassLabel);
            InputPanel.Controls.Add(ForceLabel);
            InputPanel.Controls.Add(AccelerationRadioButton);
            InputPanel.Controls.Add(MassRadioButton);
            InputPanel.Controls.Add(ForceRadioButton);
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(ResultLabel);
            ResultPanel.Controls.SetChildIndex(ResultPanelLabel, 0);
            ResultPanel.Controls.SetChildIndex(ResultValueLabel, 0);
            ResultPanel.Controls.SetChildIndex(ResultLabel, 0);
            // 
            // ForceRadioButton
            // 
            ForceRadioButton.AutoSize = true;
            ForceRadioButton.Location = new Point(18, 19);
            ForceRadioButton.Name = "ForceRadioButton";
            ForceRadioButton.Size = new Size(80, 19);
            ForceRadioButton.TabIndex = 0;
            ForceRadioButton.TabStop = true;
            ForceRadioButton.Text = "Find Force";
            ForceRadioButton.UseVisualStyleBackColor = true;
            // 
            // MassRadioButton
            // 
            MassRadioButton.AutoSize = true;
            MassRadioButton.Location = new Point(18, 44);
            MassRadioButton.Name = "MassRadioButton";
            MassRadioButton.Size = new Size(78, 19);
            MassRadioButton.TabIndex = 1;
            MassRadioButton.TabStop = true;
            MassRadioButton.Text = "Find Mass";
            MassRadioButton.UseVisualStyleBackColor = true;
            // 
            // AccelerationRadioButton
            // 
            AccelerationRadioButton.AutoSize = true;
            AccelerationRadioButton.Location = new Point(135, 19);
            AccelerationRadioButton.Name = "AccelerationRadioButton";
            AccelerationRadioButton.Size = new Size(117, 19);
            AccelerationRadioButton.TabIndex = 2;
            AccelerationRadioButton.TabStop = true;
            AccelerationRadioButton.Text = "Find Acceleration";
            AccelerationRadioButton.UseVisualStyleBackColor = true;
            // 
            // ForceLabel
            // 
            ForceLabel.AutoSize = true;
            ForceLabel.Location = new Point(18, 97);
            ForceLabel.Name = "ForceLabel";
            ForceLabel.Size = new Size(42, 15);
            ForceLabel.TabIndex = 3;
            ForceLabel.Text = "Force: ";
            // 
            // MassLabel
            // 
            MassLabel.AutoSize = true;
            MassLabel.Location = new Point(18, 128);
            MassLabel.Name = "MassLabel";
            MassLabel.Size = new Size(37, 15);
            MassLabel.TabIndex = 4;
            MassLabel.Text = "Mass:";
            // 
            // AccelerationLabel
            // 
            AccelerationLabel.AutoSize = true;
            AccelerationLabel.Location = new Point(18, 159);
            AccelerationLabel.Name = "AccelerationLabel";
            AccelerationLabel.Size = new Size(76, 15);
            AccelerationLabel.TabIndex = 5;
            AccelerationLabel.Text = "Acceleration:";
            // 
            // ForceTextBox
            // 
            ForceTextBox.Location = new Point(166, 97);
            ForceTextBox.Name = "ForceTextBox";
            ForceTextBox.Size = new Size(100, 23);
            ForceTextBox.TabIndex = 6;
            // 
            // MassTextBox
            // 
            MassTextBox.Location = new Point(166, 128);
            MassTextBox.Name = "MassTextBox";
            MassTextBox.Size = new Size(100, 23);
            MassTextBox.TabIndex = 7;
            // 
            // AccelerationTextBox
            // 
            AccelerationTextBox.Location = new Point(166, 159);
            AccelerationTextBox.Name = "AccelerationTextBox";
            AccelerationTextBox.Size = new Size(100, 23);
            AccelerationTextBox.TabIndex = 8;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(193, 34);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 15);
            ResultLabel.TabIndex = 4;
            // 
            // NewtonsLawsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Name = "NewtonsLawsForm";
            Text = "NewtonsLawsForm";
            InputPanel.ResumeLayout(false);
            InputPanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton ForceRadioButton;
        private RadioButton MassRadioButton;
        private RadioButton AccelerationRadioButton;
        private Label ForceLabel;
        private Label AccelerationLabel;
        private Label MassLabel;
        private TextBox ForceTextBox;
        private TextBox MassTextBox;
        private TextBox AccelerationTextBox;
        private Label ResultLabel;
    }
}