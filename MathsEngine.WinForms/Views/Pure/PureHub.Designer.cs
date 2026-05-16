namespace MathsEngine.WinForms.Views.Pure
{
    partial class PureHub
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
            pureTitleLabel = new Label();
            algebraButton = new Button();
            coordGeometryButton = new Button();
            matricesButton = new Button();
            pythagorasButton = new Button();
            trigonometryButton = new Button();
            SuspendLayout();
            // 
            // pureTitleLabel
            // 
            pureTitleLabel.AutoSize = true;
            pureTitleLabel.Font = new Font("Segoe UI", 20F);
            pureTitleLabel.Location = new Point(50, 25);
            pureTitleLabel.Name = "pureTitleLabel";
            pureTitleLabel.Size = new Size(321, 37);
            pureTitleLabel.TabIndex = 0;
            pureTitleLabel.Text = "Welcome to the Pure Hub";
            // 
            // algebraButton
            // 
            algebraButton.Font = new Font("Segoe UI", 15F);
            algebraButton.Location = new Point(50, 100);
            algebraButton.Name = "algebraButton";
            algebraButton.Size = new Size(200, 90);
            algebraButton.TabIndex = 1;
            algebraButton.Text = "Algebra";
            algebraButton.UseVisualStyleBackColor = true;
            // 
            // coordGeometryButton
            // 
            coordGeometryButton.Font = new Font("Segoe UI", 15F);
            coordGeometryButton.Location = new Point(300, 100);
            coordGeometryButton.Name = "coordGeometryButton";
            coordGeometryButton.Size = new Size(200, 90);
            coordGeometryButton.TabIndex = 2;
            coordGeometryButton.Text = "Co-ordinate Geometry";
            coordGeometryButton.UseVisualStyleBackColor = true;
            // 
            // matricesButton
            // 
            matricesButton.Font = new Font("Segoe UI", 15F);
            matricesButton.Location = new Point(50, 250);
            matricesButton.Name = "matricesButton";
            matricesButton.Size = new Size(200, 90);
            matricesButton.TabIndex = 3;
            matricesButton.Text = "Matrices";
            matricesButton.UseVisualStyleBackColor = true;
            // 
            // pythagorasButton
            // 
            pythagorasButton.Font = new Font("Segoe UI", 15F);
            pythagorasButton.Location = new Point(300, 250);
            pythagorasButton.Name = "pythagorasButton";
            pythagorasButton.Size = new Size(200, 90);
            pythagorasButton.TabIndex = 4;
            pythagorasButton.Text = "Pythagoras Theorem";
            pythagorasButton.UseVisualStyleBackColor = true;
            // 
            // trigonometryButton
            // 
            trigonometryButton.Font = new Font("Segoe UI", 15F);
            trigonometryButton.Location = new Point(50, 400);
            trigonometryButton.Name = "trigonometryButton";
            trigonometryButton.Size = new Size(200, 90);
            trigonometryButton.TabIndex = 5;
            trigonometryButton.Text = "Trigonometry";
            trigonometryButton.UseVisualStyleBackColor = true;
            // 
            // PureHub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(trigonometryButton);
            Controls.Add(pythagorasButton);
            Controls.Add(matricesButton);
            Controls.Add(coordGeometryButton);
            Controls.Add(algebraButton);
            Controls.Add(pureTitleLabel);
            Name = "PureHub";
            Size = new Size(1164, 657);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label pureTitleLabel;
        private Button algebraButton;
        private Button coordGeometryButton;
        private Button matricesButton;
        private Button pythagorasButton;
        private Button trigonometryButton;
    }
}
