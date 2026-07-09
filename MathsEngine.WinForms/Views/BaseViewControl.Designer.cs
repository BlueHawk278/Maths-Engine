namespace MathsEngine.WinForms.Views
{
    partial class BaseViewControl
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
            lblTitle = new MathsEngine.WinForms.Controls.Display.TitleLabel();
            BackButton = new MathsEngine.WinForms.Controls.Navigation.BackButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(161, 71);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(177, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Default Title";
            // 
            // BackButton
            // 
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.ForeColor = Color.Black;
            BackButton.Location = new Point(19, 15);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(100, 50);
            BackButton.TabIndex = 1;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            // 
            // BaseViewControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BackButton);
            Controls.Add(lblTitle);
            Name = "BaseViewControl";
            Size = new Size(697, 487);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.Display.TitleLabel lblTitle;
        private Controls.Navigation.BackButton BackButton;
    }
}
