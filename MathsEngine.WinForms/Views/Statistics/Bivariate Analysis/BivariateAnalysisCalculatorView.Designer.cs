using MathsEngine.WinForms.Core.Styling;

namespace MathsEngine.WinForms.Views.Statistics.Bivariate_Analysis
{
    partial class BivariateAnalysisCalculatorView
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
            StepsTextBox = new RichTextBox();
            _containerPanel = new Panel();
            _numericUpDown1 = new NumericUpDown();
            lblChoose = new Label();
            _lblSigmaDifferenceSquared = new Label();
            _lblCorrelation = new Label();
            _lblCorrelationInterpretation = new Label();
            _dataGridView = new DataGridView();
            _calculateButton = new MathsEngine.WinForms.Controls.Navigation.CalculateButton();
            _clearButton = new MathsEngine.WinForms.Controls.Navigation.ClearButton();
            _containerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // StepsTextBox
            // 
            StepsTextBox.Location = new Point(575, 10);
            StepsTextBox.Name = "StepsTextBox";
            StepsTextBox.ReadOnly = true;
            StepsTextBox.Size = new Size(340, 365);
            StepsTextBox.TabIndex = 6;
            StepsTextBox.Text = "";
            // 
            // _containerPanel
            // 
            _containerPanel.BorderStyle = BorderStyle.FixedSingle;
            _containerPanel.Controls.Add(_numericUpDown1);
            _containerPanel.Controls.Add(lblChoose);
            _containerPanel.Controls.Add(_lblSigmaDifferenceSquared);
            _containerPanel.Controls.Add(_lblCorrelation);
            _containerPanel.Controls.Add(_lblCorrelationInterpretation);
            _containerPanel.Controls.Add(_dataGridView);
            _containerPanel.Location = new Point(10, 100);
            _containerPanel.Name = "_containerPanel";
            _containerPanel.Size = new Size(525, 290);
            _containerPanel.TabIndex = 7;
            // 
            // _numericUpDown1
            // 
            _numericUpDown1.Location = new Point(190, 15);
            _numericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            _numericUpDown1.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            _numericUpDown1.Name = "_numericUpDown1";
            _numericUpDown1.Size = new Size(60, 23);
            _numericUpDown1.TabIndex = 0;
            _numericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 0 });
            _numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            // 
            // lblChoose
            // 
            lblChoose.AutoSize = true;
            lblChoose.Location = new Point(15, 15);
            lblChoose.Name = "lblChoose";
            lblChoose.Size = new Size(146, 15);
            lblChoose.TabIndex = 1;
            lblChoose.Text = "Number of Data Columns:";
            // 
            // _lblSigmaDifferenceSquared
            // 
            _lblSigmaDifferenceSquared.AutoSize = true;
            _lblSigmaDifferenceSquared.Location = new Point(20, 230);
            _lblSigmaDifferenceSquared.Name = "_lblSigmaDifferenceSquared";
            _lblSigmaDifferenceSquared.Size = new Size(38, 15);
            _lblSigmaDifferenceSquared.TabIndex = 2;
            _lblSigmaDifferenceSquared.Text = "Σd² = ";
            // 
            // _lblCorrelation
            // 
            _lblCorrelation.AutoSize = true;
            _lblCorrelation.Location = new Point(15, 265);
            _lblCorrelation.Name = "_lblCorrelation";
            _lblCorrelation.Size = new Size(141, 15);
            _lblCorrelation.TabIndex = 3;
            _lblCorrelation.Text = "Correlation Coefficient = ";
            // 
            // _lblCorrelationInterpretation
            // 
            _lblCorrelationInterpretation.AutoSize = true;
            _lblCorrelationInterpretation.Location = new Point(245, 265);
            _lblCorrelationInterpretation.Name = "_lblCorrelationInterpretation";
            _lblCorrelationInterpretation.Size = new Size(85, 15);
            _lblCorrelationInterpretation.TabIndex = 4;
            _lblCorrelationInterpretation.Text = "Interpretation: ";
            // 
            // _dataGridView
            // 
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.Location = new Point(15, 50);
            _dataGridView.Name = "_dataGridView";
            _dataGridView.RowHeadersVisible = false;
            _dataGridView.Size = new Size(493, 210);
            _dataGridView.TabIndex = 5;
            // 
            // _calculateButton
            // 
            _calculateButton.FlatStyle = FlatStyle.Flat;
            _calculateButton.ForeColor = Color.Black;
            _calculateButton.Location = new Point(10, 400);
            _calculateButton.Name = "_calculateButton";
            _calculateButton.Size = new Size(250, 60);
            _calculateButton.TabIndex = 8;
            _calculateButton.Text = "Calculate";
            _calculateButton.Click += calculateButton_Click;
            // 
            // _clearButton
            // 
            _clearButton.FlatStyle = FlatStyle.Flat;
            _clearButton.ForeColor = Color.Black;
            _clearButton.Location = new Point(285, 400);
            _clearButton.Name = "_clearButton";
            _clearButton.Size = new Size(250, 60);
            _clearButton.TabIndex = 9;
            _clearButton.Text = "Clear";
            _clearButton.Click += clearButton_Click;
            // 
            // BivariateAnalysisCalculatorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StepsTextBox);
            Controls.Add(_calculateButton);
            Controls.Add(_clearButton);
            Controls.Add(_containerPanel);
            Name = "BivariateAnalysisCalculatorView";
            Size = new Size(997, 480);
            Controls.SetChildIndex(_containerPanel, 0);
            Controls.SetChildIndex(_clearButton, 0);
            Controls.SetChildIndex(_calculateButton, 0);
            Controls.SetChildIndex(StepsTextBox, 0);
            _containerPanel.ResumeLayout(false);
            _containerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox StepsTextBox;
        private Panel _containerPanel;
        private NumericUpDown _numericUpDown1;
        private Label lblChoose;
        private DataGridView _dataGridView;
        private Controls.Navigation.CalculateButton _calculateButton;
        private Controls.Navigation.ClearButton _clearButton;
        private Label _lblSigmaDifferenceSquared;
        private Label _lblCorrelation;
        private Label _lblCorrelationInterpretation;
    }
}