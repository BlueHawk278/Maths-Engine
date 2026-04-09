namespace MathsEngine.WinForms.Forms
{
    partial class PureMenu
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
            PythagorasButton = new Button();
            TrigonometryButton = new Button();
            MatricesButton = new Button();
            CoordinateGeoButton = new Button();
            AlgebraButton = new Button();
            TitleLabel = new Label();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            BackButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // PythagorasButton
            // 
            PythagorasButton.Location = new Point(125, 200);
            PythagorasButton.Name = "PythagorasButton";
            PythagorasButton.Size = new Size(400, 50);
            PythagorasButton.TabIndex = 0;
            PythagorasButton.Text = "Pythagoras Theorem";
            PythagorasButton.UseVisualStyleBackColor = true;
            PythagorasButton.Click += PythagorasButton_Click;
            // 
            // TrigonometryButton
            // 
            TrigonometryButton.Location = new Point(125, 280);
            TrigonometryButton.Name = "TrigonometryButton";
            TrigonometryButton.Size = new Size(400, 50);
            TrigonometryButton.TabIndex = 1;
            TrigonometryButton.Text = "Trigonometry\r\n";
            TrigonometryButton.UseVisualStyleBackColor = true;
            // 
            // MatricesButton
            // 
            MatricesButton.Location = new Point(125, 360);
            MatricesButton.Name = "MatricesButton";
            MatricesButton.Size = new Size(400, 50);
            MatricesButton.TabIndex = 2;
            MatricesButton.Text = "Matrices";
            MatricesButton.UseVisualStyleBackColor = true;
            // 
            // CoordinateGeoButton
            // 
            CoordinateGeoButton.Location = new Point(125, 440);
            CoordinateGeoButton.Name = "CoordinateGeoButton";
            CoordinateGeoButton.Size = new Size(400, 50);
            CoordinateGeoButton.TabIndex = 3;
            CoordinateGeoButton.Text = "Coordinate Geometry";
            CoordinateGeoButton.UseVisualStyleBackColor = true;
            // 
            // AlgebraButton
            // 
            AlgebraButton.Location = new Point(125, 520);
            AlgebraButton.Name = "AlgebraButton";
            AlgebraButton.Size = new Size(400, 50);
            AlgebraButton.TabIndex = 4;
            AlgebraButton.Text = "Algebra";
            AlgebraButton.UseVisualStyleBackColor = true;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 25F);
            TitleLabel.Location = new Point(163, 120);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(324, 46);
            TitleLabel.TabIndex = 5;
            TitleLabel.Text = "PURE MATHS MENU";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, editToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 6;
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
            // BackButton
            // 
            BackButton.Location = new Point(12, 50);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(100, 30);
            BackButton.TabIndex = 7;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // PureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(BackButton);
            Controls.Add(menuStrip1);
            Controls.Add(TitleLabel);
            Controls.Add(AlgebraButton);
            Controls.Add(CoordinateGeoButton);
            Controls.Add(MatricesButton);
            Controls.Add(TrigonometryButton);
            Controls.Add(PythagorasButton);
            Name = "PureForm";
            Text = "PureForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PythagorasButton;
        private Button TrigonometryButton;
        private Button MatricesButton;
        private Button CoordinateGeoButton;
        private Button AlgebraButton;
        private Label TitleLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button BackButton;
    }
}