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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
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
            ResultValueLabel = new Label();
            ResultNameLabel = new Label();
            StepsPanel = new Panel();
            CalculateButton = new Button();
            ClearButton = new Button();
            menuStrip1.SuspendLayout();
            InputPanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, editToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 20);
            toolStripMenuItem1.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
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
            InputPanel.Size = new Size(610, 200);
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
            // ResultPanel
            // 
            ResultPanel.Controls.Add(ResultValueLabel);
            ResultPanel.Controls.Add(ResultNameLabel);
            ResultPanel.Location = new Point(12, 337);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(610, 62);
            ResultPanel.TabIndex = 4;
            // 
            // ResultValueLabel
            // 
            ResultValueLabel.AutoSize = true;
            ResultValueLabel.Location = new Point(166, 24);
            ResultValueLabel.Name = "ResultValueLabel";
            ResultValueLabel.Size = new Size(38, 15);
            ResultValueLabel.TabIndex = 1;
            ResultValueLabel.Text = "label1";
            // 
            // ResultNameLabel
            // 
            ResultNameLabel.AutoSize = true;
            ResultNameLabel.Location = new Point(18, 24);
            ResultNameLabel.Name = "ResultNameLabel";
            ResultNameLabel.Size = new Size(128, 15);
            ResultNameLabel.TabIndex = 0;
            ResultNameLabel.Text = "Hypotenuse/OtherSide";
            // 
            // StepsPanel
            // 
            StepsPanel.Location = new Point(12, 420);
            StepsPanel.Name = "StepsPanel";
            StepsPanel.Size = new Size(610, 155);
            StepsPanel.TabIndex = 5;
            // 
            // CalculateButton
            // 
            CalculateButton.Font = new Font("Segoe UI", 15F);
            CalculateButton.Location = new Point(252, 610);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(144, 62);
            CalculateButton.TabIndex = 6;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Segoe UI", 15F);
            ClearButton.Location = new Point(252, 688);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(144, 61);
            ClearButton.TabIndex = 7;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            // 
            // PythagorasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(ClearButton);
            Controls.Add(CalculateButton);
            Controls.Add(StepsPanel);
            Controls.Add(ResultPanel);
            Controls.Add(InputPanel);
            Controls.Add(PythagorasLabel);
            Controls.Add(menuStrip1);
            Name = "PythagorasForm";
            Text = "Maths Engine";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            InputPanel.ResumeLayout(false);
            InputPanel.PerformLayout();
            ResultPanel.ResumeLayout(false);
            ResultPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
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
        private Label ResultValueLabel;
        private Label ResultNameLabel;
        private Panel StepsPanel;
        private Button CalculateButton;
        private Button ClearButton;
    }
}