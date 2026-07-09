namespace MathsEngine.WinForms.Views.Statistics
{
    partial class StatisticsHub
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
            dispersionButton = new Button();
            bivariateAnalysisButton = new Button();
            SuspendLayout();
            // 
            // dispersionButton
            // 
            dispersionButton.Location = new Point(150, 140);
            dispersionButton.Name = "dispersionButton";
            dispersionButton.Size = new Size(200, 90);
            dispersionButton.TabIndex = 2;
            dispersionButton.Text = "Central tendency and Dispersion";
            dispersionButton.UseVisualStyleBackColor = true;
            dispersionButton.Click += dispersionButton_Click;
            // 
            // bivariateAnalysisButton
            // 
            bivariateAnalysisButton.Location = new Point(400, 140);
            bivariateAnalysisButton.Name = "bivariateAnalysisButton";
            bivariateAnalysisButton.Size = new Size(200, 90);
            bivariateAnalysisButton.TabIndex = 3;
            bivariateAnalysisButton.Text = "Bivariate Analysis";
            bivariateAnalysisButton.UseVisualStyleBackColor = true;
            bivariateAnalysisButton.Click += bivariateAnalysisButton_Click;
            // 
            // StatisticsHub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bivariateAnalysisButton);
            Controls.Add(dispersionButton);
            Name = "StatisticsHub";
            Controls.SetChildIndex(dispersionButton, 0);
            Controls.SetChildIndex(bivariateAnalysisButton, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button dispersionButton;
        private Button bivariateAnalysisButton;
    }
}
