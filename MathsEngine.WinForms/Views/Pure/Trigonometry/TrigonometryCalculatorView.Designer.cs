namespace MathsEngine.WinForms.Views.Pure.Trigonometry
{
    partial class TrigonometryCalculatorView
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
            backButton = new MathsEngine.WinForms.Controls.Navigation.BackButton();
            explanationTextBox = new RichTextBox();
            calculateButton = new MathsEngine.WinForms.Controls.Navigation.CalculateButton();
            clearButton = new MathsEngine.WinForms.Controls.Navigation.ClearButton();
            inputPanel = new Panel();
            calculateMissingAngleButton = new RadioButton();
            AngleTextBox = new TextBox();
            angleLabel = new Label();
            hypotenuseLabel = new Label();
            CalculateOtherSideButton = new RadioButton();
            CheckValidCalculationButton = new RadioButton();
            AdjacentTextBox = new TextBox();
            OppositeTextBox = new TextBox();
            HypotenuseTextBox = new TextBox();
            adjacentLabel = new Label();
            oppositeLabel = new Label();
            panel1 = new Panel();
            ResultTextBox = new TextBox();
            ResultLabel = new Label();
            trigTitleLabel = new MathsEngine.WinForms.Controls.Display.TitleLabel();
            TargetSideComboBox = new ComboBox();
            inputPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.ForeColor = Color.Black;
            backButton.Location = new Point(10, 10);
            backButton.Name = "backButton";
            backButton.Size = new Size(100, 50);
            backButton.TabIndex = 1;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // explanationTextBox
            // 
            explanationTextBox.Location = new Point(459, 90);
            explanationTextBox.Name = "explanationTextBox";
            explanationTextBox.ReadOnly = true;
            explanationTextBox.Size = new Size(300, 367);
            explanationTextBox.TabIndex = 9;
            explanationTextBox.Text = "";
            // 
            // calculateButton
            // 
            calculateButton.FlatStyle = FlatStyle.Flat;
            calculateButton.Font = new Font("Segoe UI", 15F);
            calculateButton.ForeColor = Color.Black;
            calculateButton.Location = new Point(158, 500);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(250, 60);
            calculateButton.TabIndex = 8;
            calculateButton.Text = "Calculate";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // clearButton
            // 
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 15F);
            clearButton.ForeColor = Color.Black;
            clearButton.Location = new Point(158, 420);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(250, 60);
            clearButton.TabIndex = 7;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(TargetSideComboBox);
            inputPanel.Controls.Add(calculateMissingAngleButton);
            inputPanel.Controls.Add(AngleTextBox);
            inputPanel.Controls.Add(angleLabel);
            inputPanel.Controls.Add(hypotenuseLabel);
            inputPanel.Controls.Add(CalculateOtherSideButton);
            inputPanel.Controls.Add(CheckValidCalculationButton);
            inputPanel.Controls.Add(AdjacentTextBox);
            inputPanel.Controls.Add(OppositeTextBox);
            inputPanel.Controls.Add(HypotenuseTextBox);
            inputPanel.Controls.Add(adjacentLabel);
            inputPanel.Controls.Add(oppositeLabel);
            inputPanel.Location = new Point(158, 90);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(250, 250);
            inputPanel.TabIndex = 6;
            // 
            // calculateMissingAngleButton
            // 
            calculateMissingAngleButton.AutoSize = true;
            calculateMissingAngleButton.Location = new Point(15, 163);
            calculateMissingAngleButton.Name = "calculateMissingAngleButton";
            calculateMissingAngleButton.Size = new Size(152, 19);
            calculateMissingAngleButton.TabIndex = 12;
            calculateMissingAngleButton.TabStop = true;
            calculateMissingAngleButton.Text = "Calculate Missing Angle";
            calculateMissingAngleButton.UseVisualStyleBackColor = true;
            calculateMissingAngleButton.CheckedChanged += calculateMissingAngleButton_CheckedChanged;
            // 
            // AngleTextBox
            // 
            AngleTextBox.Location = new Point(122, 102);
            AngleTextBox.Name = "AngleTextBox";
            AngleTextBox.Size = new Size(100, 23);
            AngleTextBox.TabIndex = 11;
            // 
            // angleLabel
            // 
            angleLabel.AutoSize = true;
            angleLabel.Location = new Point(15, 105);
            angleLabel.Name = "angleLabel";
            angleLabel.Size = new Size(41, 15);
            angleLabel.TabIndex = 10;
            angleLabel.Text = "Angle:";
            // 
            // hypotenuseLabel
            // 
            hypotenuseLabel.AutoSize = true;
            hypotenuseLabel.Location = new Point(15, 15);
            hypotenuseLabel.Name = "hypotenuseLabel";
            hypotenuseLabel.Size = new Size(74, 15);
            hypotenuseLabel.TabIndex = 9;
            hypotenuseLabel.Text = "Hypotenuse:";
            // 
            // CalculateOtherSideButton
            // 
            CalculateOtherSideButton.AutoSize = true;
            CalculateOtherSideButton.Location = new Point(15, 138);
            CalculateOtherSideButton.Name = "CalculateOtherSideButton";
            CalculateOtherSideButton.Size = new Size(143, 19);
            CalculateOtherSideButton.TabIndex = 8;
            CalculateOtherSideButton.TabStop = true;
            CalculateOtherSideButton.Text = "Calculate Missing Side";
            CalculateOtherSideButton.UseVisualStyleBackColor = true;
            CalculateOtherSideButton.CheckedChanged += CalculateOtherSideButton_CheckedChanged;
            // 
            // CheckValidCalculationButton
            // 
            CheckValidCalculationButton.AutoSize = true;
            CheckValidCalculationButton.Location = new Point(15, 188);
            CheckValidCalculationButton.Name = "CheckValidCalculationButton";
            CheckValidCalculationButton.Size = new Size(149, 19);
            CheckValidCalculationButton.TabIndex = 7;
            CheckValidCalculationButton.TabStop = true;
            CheckValidCalculationButton.Text = "Check Valid Calculation";
            CheckValidCalculationButton.UseVisualStyleBackColor = true;
            CheckValidCalculationButton.CheckedChanged += CheckValidCalculationButton_CheckedChanged;
            // 
            // AdjacentTextBox
            // 
            AdjacentTextBox.Location = new Point(122, 72);
            AdjacentTextBox.Name = "AdjacentTextBox";
            AdjacentTextBox.Size = new Size(100, 23);
            AdjacentTextBox.TabIndex = 5;
            // 
            // OppositeTextBox
            // 
            OppositeTextBox.Location = new Point(122, 42);
            OppositeTextBox.Name = "OppositeTextBox";
            OppositeTextBox.Size = new Size(100, 23);
            OppositeTextBox.TabIndex = 4;
            // 
            // HypotenuseTextBox
            // 
            HypotenuseTextBox.Location = new Point(122, 12);
            HypotenuseTextBox.Name = "HypotenuseTextBox";
            HypotenuseTextBox.Size = new Size(100, 23);
            HypotenuseTextBox.TabIndex = 3;
            // 
            // adjacentLabel
            // 
            adjacentLabel.AutoSize = true;
            adjacentLabel.Location = new Point(15, 75);
            adjacentLabel.Name = "adjacentLabel";
            adjacentLabel.Size = new Size(57, 15);
            adjacentLabel.TabIndex = 2;
            adjacentLabel.Text = "Adjacent:";
            // 
            // oppositeLabel
            // 
            oppositeLabel.AutoSize = true;
            oppositeLabel.Location = new Point(15, 45);
            oppositeLabel.Name = "oppositeLabel";
            oppositeLabel.Size = new Size(58, 15);
            oppositeLabel.TabIndex = 1;
            oppositeLabel.Text = "Opposite:";
            // 
            // panel1
            // 
            panel1.Controls.Add(ResultTextBox);
            panel1.Controls.Add(ResultLabel);
            panel1.Location = new Point(158, 350);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 45);
            panel1.TabIndex = 10;
            // 
            // ResultTextBox
            // 
            ResultTextBox.Location = new Point(77, 15);
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.ReadOnly = true;
            ResultTextBox.Size = new Size(145, 23);
            ResultTextBox.TabIndex = 1;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 12F);
            ResultLabel.Location = new Point(15, 13);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(56, 21);
            ResultLabel.TabIndex = 0;
            ResultLabel.Text = "Result:";
            // 
            // trigTitleLabel
            // 
            trigTitleLabel.AutoSize = true;
            trigTitleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            trigTitleLabel.ForeColor = Color.Black;
            trigTitleLabel.Location = new Point(160, 30);
            trigTitleLabel.Name = "trigTitleLabel";
            trigTitleLabel.Size = new Size(833, 37);
            trigTitleLabel.TabIndex = 11;
            trigTitleLabel.Text = "Welcome to the Right-Angled Triangle Trigonometry Calculator";
            // 
            // TargetSideComboBox
            // 
            TargetSideComboBox.FormattingEnabled = true;
            TargetSideComboBox.Items.AddRange(new object[] { "Hypotenuse", "Opposite", "Adjacent" });
            TargetSideComboBox.Location = new Point(15, 213);
            TargetSideComboBox.Name = "TargetSideComboBox";
            TargetSideComboBox.Size = new Size(149, 23);
            TargetSideComboBox.TabIndex = 13;
            // 
            // TrigonometryCalculatorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(trigTitleLabel);
            Controls.Add(panel1);
            Controls.Add(explanationTextBox);
            Controls.Add(calculateButton);
            Controls.Add(clearButton);
            Controls.Add(inputPanel);
            Controls.Add(backButton);
            Name = "TrigonometryCalculatorView";
            Size = new Size(1164, 657);
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.Navigation.BackButton backButton;
        private RichTextBox explanationTextBox;
        private Controls.Navigation.CalculateButton calculateButton;
        private Controls.Navigation.ClearButton clearButton;
        private Panel inputPanel;
        private RadioButton CalculateOtherSideButton;
        private RadioButton CheckValidCalculationButton;
        private TextBox AdjacentTextBox;
        private TextBox OppositeTextBox;
        private TextBox HypotenuseTextBox;
        private Label adjacentLabel;
        private Label oppositeLabel;
        private Label hypotenuseLabel;
        private TextBox AngleTextBox;
        private Label angleLabel;
        private RadioButton calculateMissingAngleButton;
        private Panel panel1;
        private TextBox ResultTextBox;
        private Label ResultLabel;
        private Controls.Display.TitleLabel trigTitleLabel;
        private ComboBox TargetSideComboBox;
    }
}
