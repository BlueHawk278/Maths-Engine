namespace MathsEngine.WinForms.Views.Pure
{
    partial class PureHub
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            algebraButton = new Button();
            coordGeometryButton = new Button();
            matricesButton = new Button();
            pythagorasButton = new Button();
            trigonometryButton = new Button();
            SuspendLayout();
            // 
            // algebraButton
            // 
            algebraButton.Font = new Font("Segoe UI", 15F);
            algebraButton.Location = new Point(149, 103);
            algebraButton.Name = "algebraButton";
            algebraButton.Size = new Size(200, 90);
            algebraButton.TabIndex = 1;
            algebraButton.Text = "Algebra";
            algebraButton.UseVisualStyleBackColor = true;
            algebraButton.Click += algebraButton_Click;
            // 
            // coordGeometryButton
            // 
            coordGeometryButton.Font = new Font("Segoe UI", 15F);
            coordGeometryButton.Location = new Point(399, 103);
            coordGeometryButton.Name = "coordGeometryButton";
            coordGeometryButton.Size = new Size(200, 90);
            coordGeometryButton.TabIndex = 2;
            coordGeometryButton.Text = "Co-ordinate Geometry";
            coordGeometryButton.UseVisualStyleBackColor = true;
            coordGeometryButton.Click += coordGeometryButton_Click;
            // 
            // matricesButton
            // 
            matricesButton.Font = new Font("Segoe UI", 15F);
            matricesButton.Location = new Point(149, 253);
            matricesButton.Name = "matricesButton";
            matricesButton.Size = new Size(200, 90);
            matricesButton.TabIndex = 3;
            matricesButton.Text = "Matrices";
            matricesButton.UseVisualStyleBackColor = true;
            matricesButton.Click += matricesButton_Click;
            // 
            // pythagorasButton
            // 
            pythagorasButton.Font = new Font("Segoe UI", 15F);
            pythagorasButton.Location = new Point(399, 253);
            pythagorasButton.Name = "pythagorasButton";
            pythagorasButton.Size = new Size(200, 90);
            pythagorasButton.TabIndex = 4;
            pythagorasButton.Text = "Pythagoras Theorem";
            pythagorasButton.UseVisualStyleBackColor = true;
            pythagorasButton.Click += pythagorasButton_Click;
            // 
            // trigonometryButton
            // 
            trigonometryButton.Font = new Font("Segoe UI", 15F);
            trigonometryButton.Location = new Point(149, 403);
            trigonometryButton.Name = "trigonometryButton";
            trigonometryButton.Size = new Size(200, 90);
            trigonometryButton.TabIndex = 5;
            trigonometryButton.Text = "Trigonometry";
            trigonometryButton.UseVisualStyleBackColor = true;
            trigonometryButton.Click += trigonometryButton_Click;
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
            Name = "PureHub";
            Size = new Size(1164, 657);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button algebraButton;
        private Button coordGeometryButton;
        private Button matricesButton;
        private Button pythagorasButton;
        private Button trigonometryButton;
    }
}