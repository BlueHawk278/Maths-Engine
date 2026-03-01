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
            PythagorasLabel = new Label();
            InputPanel = new Panel();
            TextBoxHypotenuse = new TextBox();
            TextBoxSideB = new TextBox();
            TextBoxSideA = new TextBox();
            HypotenuseLabel = new Label();
            LabelSideB = new Label();
            LabelSideA = new Label();
            FindOtherSideRadioButton = new RadioButton();
            FindHypotenuseRadioButton = new RadioButton();
            ResultPanel = new Panel();
            ResultLabel = new Label();
            ResultPanelLabel = new Label();
            CalculateButton = new Button();
            ClearButton = new Button();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            InputPanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PythagorasLabel
            // 
            PythagorasLabel.AutoSize = true;
            PythagorasLabel.Font = new Font("Segoe UI", 18F);
            PythagorasLabel.Location = new Point(206, 48);
            PythagorasLabel.Name = "PythagorasLabel";
            PythagorasLabel.Size = new Size(234, 32);
            PythagorasLabel.TabIndex = 2;
            PythagorasLabel.Text = "Pythagoras Theorem";
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
            InputPanel.Location = new Point(12, 116);
            InputPanel.Name = "InputPanel";
            InputPanel.Size = new Size(273, 215);
            InputPanel.TabIndex = 3;
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
            FindOtherSideRadioButton.CheckedChanged += FindOtherSideRadioButton_CheckedChanged;
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
            FindHypotenuseRadioButton.CheckedChanged += FindHypotenuseRadioButton_CheckedChanged;
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(ResultLabel);
            ResultPanel.Controls.Add(ResultPanelLabel);
            ResultPanel.Location = new Point(12, 337);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(610, 77);
            ResultPanel.TabIndex = 4;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(23, 46);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 15);
            ResultLabel.TabIndex = 3;
            // 
            // ResultPanelLabel
            // 
            ResultPanelLabel.AutoSize = true;
            ResultPanelLabel.Location = new Point(18, 18);
            ResultPanelLabel.Name = "ResultPanelLabel";
            ResultPanelLabel.Size = new Size(39, 15);
            ResultPanelLabel.TabIndex = 2;
            ResultPanelLabel.Text = "Result";
            // 
            // CalculateButton
            // 
            CalculateButton.Font = new Font("Segoe UI", 15F);
            CalculateButton.Location = new Point(348, 689);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(150, 60);
            CalculateButton.TabIndex = 6;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Segoe UI", 15F);
            ClearButton.Location = new Point(147, 688);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(150, 60);
            ClearButton.TabIndex = 7;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(291, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(331, 215);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 420);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(610, 262);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // PythagorasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Controls.Add(ClearButton);
            Controls.Add(CalculateButton);
            Controls.Add(ResultPanel);
            Controls.Add(InputPanel);
            Controls.Add(PythagorasLabel);
            Name = "PythagorasForm";
            Controls.SetChildIndex(PythagorasLabel, 0);
            Controls.SetChildIndex(InputPanel, 0);
            Controls.SetChildIndex(ResultPanel, 0);
            Controls.SetChildIndex(CalculateButton, 0);
            Controls.SetChildIndex(ClearButton, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(richTextBox1, 0);
            Controls.SetChildIndex(BackButton, 0);
            InputPanel.ResumeLayout(false);
            InputPanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PythagorasLabel;
        private Panel InputPanel;
        private RadioButton FindOtherSideRadioButton;
        private RadioButton FindHypotenuseRadioButton;
        private Label HypotenuseLabel;
        private Label LabelSideB;
        private Label LabelSideA;
        private TextBox TextBoxSideA;
        private TextBox TextBoxHypotenuse;
        private TextBox TextBoxSideB;
        private Panel ResultPanel;
        private Button CalculateButton;
        private Button ClearButton;
        private PictureBox pictureBox1;
        private Label ResultPanelLabel;
        private Label ResultLabel;
        private RichTextBox richTextBox1;
    }
}