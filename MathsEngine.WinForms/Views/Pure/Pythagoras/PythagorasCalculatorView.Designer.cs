namespace MathsEngine.WinForms.Views.Pure.Pythagoras
{
    partial class PythagorasCalculatorView
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
            backButton1 = new MathsEngine.WinForms.Controls.Navigation.BackButton();
            viewTitleLabel = new Label();
            inputPanel = new Panel();
            CalculateOtherSideButton = new RadioButton();
            CheckValidCalculationButton = new RadioButton();
            HypotenuseButton = new RadioButton();
            TextBoxHypotenuse = new TextBox();
            TextBoxSideB = new TextBox();
            TextBoxSideA = new TextBox();
            hypotenuseLabel = new Label();
            SideLabelB = new Label();
            sideLabelA = new Label();
            clearButton = new MathsEngine.WinForms.Controls.Navigation.ClearButton();
            calculateButton1 = new MathsEngine.WinForms.Controls.Navigation.CalculateButton();
            explanationTextBox = new RichTextBox();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // backButton1
            // 
            backButton1.FlatStyle = FlatStyle.Flat;
            backButton1.ForeColor = Color.Black;
            backButton1.Location = new Point(10, 10);
            backButton1.Name = "backButton1";
            backButton1.Size = new Size(100, 50);
            backButton1.TabIndex = 0;
            backButton1.Text = "Back";
            backButton1.UseVisualStyleBackColor = true;
            // 
            // viewTitleLabel
            // 
            viewTitleLabel.AutoSize = true;
            viewTitleLabel.Font = new Font("Segoe UI", 20F);
            viewTitleLabel.Location = new Point(158, 28);
            viewTitleLabel.Name = "viewTitleLabel";
            viewTitleLabel.Size = new Size(582, 37);
            viewTitleLabel.TabIndex = 1;
            viewTitleLabel.Text = "Welcome to the Pythagoras Theorem Calculator";
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(CalculateOtherSideButton);
            inputPanel.Controls.Add(CheckValidCalculationButton);
            inputPanel.Controls.Add(HypotenuseButton);
            inputPanel.Controls.Add(TextBoxHypotenuse);
            inputPanel.Controls.Add(TextBoxSideB);
            inputPanel.Controls.Add(TextBoxSideA);
            inputPanel.Controls.Add(hypotenuseLabel);
            inputPanel.Controls.Add(SideLabelB);
            inputPanel.Controls.Add(sideLabelA);
            inputPanel.Location = new Point(158, 90);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(250, 200);
            inputPanel.TabIndex = 2;
            // 
            // CalculateOtherSideButton
            // 
            CalculateOtherSideButton.AutoSize = true;
            CalculateOtherSideButton.Location = new Point(15, 138);
            CalculateOtherSideButton.Name = "CalculateOtherSideButton";
            CalculateOtherSideButton.Size = new Size(132, 19);
            CalculateOtherSideButton.TabIndex = 8;
            CalculateOtherSideButton.TabStop = true;
            CalculateOtherSideButton.Text = "Calculate Other Side";
            CalculateOtherSideButton.UseVisualStyleBackColor = true;
            // 
            // CheckValidCalculationButton
            // 
            CheckValidCalculationButton.AutoSize = true;
            CheckValidCalculationButton.Location = new Point(15, 163);
            CheckValidCalculationButton.Name = "CheckValidCalculationButton";
            CheckValidCalculationButton.Size = new Size(149, 19);
            CheckValidCalculationButton.TabIndex = 7;
            CheckValidCalculationButton.TabStop = true;
            CheckValidCalculationButton.Text = "Check Valid Calculation";
            CheckValidCalculationButton.UseVisualStyleBackColor = true;
            // 
            // HypotenuseButton
            // 
            HypotenuseButton.AutoSize = true;
            HypotenuseButton.Location = new Point(15, 113);
            HypotenuseButton.Name = "HypotenuseButton";
            HypotenuseButton.Size = new Size(141, 19);
            HypotenuseButton.TabIndex = 6;
            HypotenuseButton.TabStop = true;
            HypotenuseButton.Text = "Calculate Hypotenuse";
            HypotenuseButton.UseVisualStyleBackColor = true;
            // 
            // TextBoxHypotenuse
            // 
            TextBoxHypotenuse.Location = new Point(122, 72);
            TextBoxHypotenuse.Name = "TextBoxHypotenuse";
            TextBoxHypotenuse.Size = new Size(100, 23);
            TextBoxHypotenuse.TabIndex = 5;
            // 
            // TextBoxSideB
            // 
            TextBoxSideB.Location = new Point(122, 42);
            TextBoxSideB.Name = "TextBoxSideB";
            TextBoxSideB.Size = new Size(100, 23);
            TextBoxSideB.TabIndex = 4;
            // 
            // TextBoxSideA
            // 
            TextBoxSideA.Location = new Point(122, 12);
            TextBoxSideA.Name = "TextBoxSideA";
            TextBoxSideA.Size = new Size(100, 23);
            TextBoxSideA.TabIndex = 3;
            // 
            // hypotenuseLabel
            // 
            hypotenuseLabel.AutoSize = true;
            hypotenuseLabel.Location = new Point(15, 75);
            hypotenuseLabel.Name = "hypotenuseLabel";
            hypotenuseLabel.Size = new Size(74, 15);
            hypotenuseLabel.TabIndex = 2;
            hypotenuseLabel.Text = "Hypotenuse:";
            // 
            // SideLabelB
            // 
            SideLabelB.AutoSize = true;
            SideLabelB.Location = new Point(15, 45);
            SideLabelB.Name = "SideLabelB";
            SideLabelB.Size = new Size(42, 15);
            SideLabelB.TabIndex = 1;
            SideLabelB.Text = "Side B:";
            // 
            // sideLabelA
            // 
            sideLabelA.AutoSize = true;
            sideLabelA.Location = new Point(15, 15);
            sideLabelA.Name = "sideLabelA";
            sideLabelA.Size = new Size(43, 15);
            sideLabelA.TabIndex = 0;
            sideLabelA.Text = "Side A:";
            // 
            // clearButton
            // 
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 15F);
            clearButton.ForeColor = Color.Black;
            clearButton.Location = new Point(158, 322);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(250, 60);
            clearButton.TabIndex = 3;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // calculateButton1
            // 
            calculateButton1.FlatStyle = FlatStyle.Flat;
            calculateButton1.Font = new Font("Segoe UI", 15F);
            calculateButton1.ForeColor = Color.Black;
            calculateButton1.Location = new Point(158, 397);
            calculateButton1.Name = "calculateButton1";
            calculateButton1.Size = new Size(250, 60);
            calculateButton1.TabIndex = 4;
            calculateButton1.Text = "Calculate";
            calculateButton1.UseVisualStyleBackColor = true;
            // 
            // explanationTextBox
            // 
            explanationTextBox.Location = new Point(459, 90);
            explanationTextBox.Name = "explanationTextBox";
            explanationTextBox.ReadOnly = true;
            explanationTextBox.Size = new Size(300, 367);
            explanationTextBox.TabIndex = 5;
            explanationTextBox.Text = "";
            // 
            // CalculatorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(explanationTextBox);
            Controls.Add(calculateButton1);
            Controls.Add(clearButton);
            Controls.Add(inputPanel);
            Controls.Add(viewTitleLabel);
            Controls.Add(backButton1);
            Name = "CalculatorView";
            Size = new Size(1164, 657);
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.Navigation.BackButton backButton1;
        private Label viewTitleLabel;
        private Panel inputPanel;
        private RadioButton CalculateOtherSideButton;
        private RadioButton CheckValidCalculationButton;
        private RadioButton HypotenuseButton;
        private TextBox TextBoxHypotenuse;
        private TextBox TextBoxSideB;
        private TextBox TextBoxSideA;
        private Label hypotenuseLabel;
        private Label SideLabelB;
        private Label sideLabelA;
        private Controls.Navigation.ClearButton clearButton;
        private Controls.Navigation.CalculateButton calculateButton1;
        private RichTextBox explanationTextBox;
    }
}
