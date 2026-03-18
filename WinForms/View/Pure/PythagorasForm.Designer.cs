namespace MathsEngine.WinForms.Forms.Pure
{
    partial class PythagorasForm
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
            TextBoxHypotenuse = new TextBox();
            TextBoxSideB = new TextBox();
            TextBoxSideA = new TextBox();
            HypotenuseLabel = new Label();
            LabelSideB = new Label();
            LabelSideA = new Label();
            FindOtherSideRadioButton = new RadioButton();
            FindHypotenuseRadioButton = new RadioButton();
            pictureBox1 = new PictureBox();
            InputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // InputPanel
            // 
            InputPanel.Controls.Add(TextBoxHypotenuse);
            InputPanel.Controls.Add(TextBoxSideB);
            InputPanel.Controls.Add(TextBoxSideA);
            InputPanel.Controls.Add(HypotenuseLabel);
            InputPanel.Controls.Add(LabelSideB);
            InputPanel.Controls.Add(LabelSideA);
            InputPanel.Controls.Add(FindOtherSideRadioButton);
            InputPanel.Controls.Add(FindHypotenuseRadioButton);
            // 
            // TextBoxHypotenuse
            // 
            TextBoxHypotenuse.Location = new Point(166, 160);
            TextBoxHypotenuse.Name = "TextBoxHypotenuse";
            TextBoxHypotenuse.Size = new Size(100, 23);
            TextBoxHypotenuse.TabIndex = 7;
            // 
            // TextBoxSideB
            // 
            TextBoxSideB.Location = new Point(166, 128);
            TextBoxSideB.Name = "TextBoxSideB";
            TextBoxSideB.Size = new Size(100, 23);
            TextBoxSideB.TabIndex = 6;
            // 
            // TextBoxSideA
            // 
            TextBoxSideA.Location = new Point(166, 94);
            TextBoxSideA.Name = "TextBoxSideA";
            TextBoxSideA.Size = new Size(100, 23);
            TextBoxSideA.TabIndex = 5;
            // 
            // HypotenuseLabel
            // 
            HypotenuseLabel.AutoSize = true;
            HypotenuseLabel.Location = new Point(18, 163);
            HypotenuseLabel.Name = "HypotenuseLabel";
            HypotenuseLabel.Size = new Size(71, 15);
            HypotenuseLabel.TabIndex = 4;
            HypotenuseLabel.Text = "Hypotenuse";
            // 
            // LabelSideB
            // 
            LabelSideB.AutoSize = true;
            LabelSideB.Location = new Point(19, 131);
            LabelSideB.Name = "LabelSideB";
            LabelSideB.Size = new Size(42, 15);
            LabelSideB.TabIndex = 3;
            LabelSideB.Text = "Side B:";
            // 
            // LabelSideA
            // 
            LabelSideA.AutoSize = true;
            LabelSideA.Location = new Point(18, 97);
            LabelSideA.Name = "LabelSideA";
            LabelSideA.Size = new Size(43, 15);
            LabelSideA.TabIndex = 2;
            LabelSideA.Text = "Side A:";
            // 
            // FindOtherSideRadioButton
            // 
            FindOtherSideRadioButton.AutoSize = true;
            FindOtherSideRadioButton.Location = new Point(18, 53);
            FindOtherSideRadioButton.Name = "FindOtherSideRadioButton";
            FindOtherSideRadioButton.Size = new Size(106, 19);
            FindOtherSideRadioButton.TabIndex = 1;
            FindOtherSideRadioButton.TabStop = true;
            FindOtherSideRadioButton.Text = "Find Other Side";
            FindOtherSideRadioButton.UseVisualStyleBackColor = true;
            // 
            // FindHypotenuseRadioButton
            // 
            FindHypotenuseRadioButton.AutoSize = true;
            FindHypotenuseRadioButton.Location = new Point(18, 17);
            FindHypotenuseRadioButton.Name = "FindHypotenuseRadioButton";
            FindHypotenuseRadioButton.Size = new Size(115, 19);
            FindHypotenuseRadioButton.TabIndex = 0;
            FindHypotenuseRadioButton.TabStop = true;
            FindHypotenuseRadioButton.Text = "Find Hypotenuse";
            FindHypotenuseRadioButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(291, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(331, 215);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // PythagorasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(pictureBox1);
            Name = "PythagorasForm";
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(BackButton, 0);
            InputPanel.ResumeLayout(false);
            InputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton FindOtherSideRadioButton;
        private RadioButton FindHypotenuseRadioButton;
        private Label HypotenuseLabel;
        private Label LabelSideB;
        private Label LabelSideA;
        private TextBox TextBoxSideA;
        private TextBox TextBoxHypotenuse;
        private TextBox TextBoxSideB;
        private PictureBox pictureBox1;
    }
}