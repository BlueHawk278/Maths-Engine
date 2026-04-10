namespace MathsEngine.WinForms.View.Mechanics
{
    partial class UniformAccelerationForm
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
            initialVelocityLabel = new Label();
            finalVelocityLabel = new Label();
            accelerationLabel = new Label();
            timeLabel = new Label();
            displacementLabel = new Label();
            initialVelocityTextBox = new TextBox();
            accelerationTextBox = new TextBox();
            displacementTextBox = new TextBox();
            finalVelocityTextBox = new TextBox();
            timeTextBox = new TextBox();
            ResultLabel = new Label();
            InputPanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // InputPanel
            // 
            InputPanel.Controls.Add(timeTextBox);
            InputPanel.Controls.Add(finalVelocityTextBox);
            InputPanel.Controls.Add(displacementTextBox);
            InputPanel.Controls.Add(accelerationTextBox);
            InputPanel.Controls.Add(initialVelocityTextBox);
            InputPanel.Controls.Add(displacementLabel);
            InputPanel.Controls.Add(timeLabel);
            InputPanel.Controls.Add(accelerationLabel);
            InputPanel.Controls.Add(finalVelocityLabel);
            InputPanel.Controls.Add(initialVelocityLabel);
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(ResultLabel);
            ResultPanel.Controls.SetChildIndex(ResultPanelLabel, 0);
            ResultPanel.Controls.SetChildIndex(ResultValueLabel, 0);
            ResultPanel.Controls.SetChildIndex(ResultLabel, 0);
            //
            // initialVelocityLabel
            // 
            initialVelocityLabel.AutoSize = true;
            initialVelocityLabel.Location = new Point(25, 40);
            initialVelocityLabel.Name = "initialVelocityLabel";
            initialVelocityLabel.Size = new Size(104, 15);
            initialVelocityLabel.TabIndex = 0;
            initialVelocityLabel.Text = "Initial Velocity (u): ";
            // 
            // finalVelocityLabel
            // 
            finalVelocityLabel.AutoSize = true;
            finalVelocityLabel.Location = new Point(25, 70);
            finalVelocityLabel.Name = "finalVelocityLabel";
            finalVelocityLabel.Size = new Size(96, 15);
            finalVelocityLabel.TabIndex = 1;
            finalVelocityLabel.Text = "Final Velocity (v):";
            // 
            // accelerationLabel
            // 
            accelerationLabel.AutoSize = true;
            accelerationLabel.Location = new Point(25, 100);
            accelerationLabel.Name = "accelerationLabel";
            accelerationLabel.Size = new Size(93, 15);
            accelerationLabel.TabIndex = 2;
            accelerationLabel.Text = "Acceleration (a):";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(25, 130);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(52, 15);
            timeLabel.TabIndex = 3;
            timeLabel.Text = "Time (t):";
            // 
            // displacementLabel
            // 
            displacementLabel.AutoSize = true;
            displacementLabel.Location = new Point(25, 160);
            displacementLabel.Name = "displacementLabel";
            displacementLabel.Size = new Size(98, 15);
            displacementLabel.TabIndex = 4;
            displacementLabel.Text = "Displacement (s):";
            // 
            // initialVelocityTextBox
            // 
            initialVelocityTextBox.Location = new Point(170, 37);
            initialVelocityTextBox.Name = "initialVelocityTextBox";
            initialVelocityTextBox.Size = new Size(100, 23);
            initialVelocityTextBox.TabIndex = 5;
            // 
            // accelerationTextBox
            // 
            accelerationTextBox.Location = new Point(170, 97);
            accelerationTextBox.Name = "accelerationTextBox";
            accelerationTextBox.Size = new Size(100, 23);
            accelerationTextBox.TabIndex = 6;
            // 
            // displacementTextBox
            // 
            displacementTextBox.Location = new Point(170, 157);
            displacementTextBox.Name = "displacementTextBox";
            displacementTextBox.Size = new Size(100, 23);
            displacementTextBox.TabIndex = 7;
            // 
            // finalVelocityTextBox
            // 
            finalVelocityTextBox.Location = new Point(170, 67);
            finalVelocityTextBox.Name = "finalVelocityTextBox";
            finalVelocityTextBox.Size = new Size(100, 23);
            finalVelocityTextBox.TabIndex = 8;
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(170, 127);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(100, 23);
            timeTextBox.TabIndex = 9;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(142, 20);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 15);
            ResultLabel.TabIndex = 4;
            // 
            // UniformAccelerationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Name = "UniformAccelerationForm";
            Text = "UniformAccelerationForm";
            InputPanel.ResumeLayout(false);
            InputPanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label initialVelocityLabel;
        private Label displacementLabel;
        private Label timeLabel;
        private Label accelerationLabel;
        private Label finalVelocityLabel;
        private TextBox timeTextBox;
        private TextBox finalVelocityTextBox;
        private TextBox displacementTextBox;
        private TextBox accelerationTextBox;
        private TextBox initialVelocityTextBox;
        private Label ResultLabel;
    }
}