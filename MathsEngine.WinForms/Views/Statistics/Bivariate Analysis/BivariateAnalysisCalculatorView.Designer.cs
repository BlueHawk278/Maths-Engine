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
            // BivariateAnalysisCalculatorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StepsTextBox);
            Name = "BivariateAnalysisCalculatorView";
            Controls.SetChildIndex(StepsTextBox, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox StepsTextBox;
    }
}
