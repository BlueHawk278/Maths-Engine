namespace WinForms.Forms
{
    partial class MainForm
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
            PureButton = new Button();
            MechanicsButton = new Button();
            StatisticsButton = new Button();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, editToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 0;
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
            // PureButton
            // 
            PureButton.Location = new Point(12, 473);
            PureButton.Name = "PureButton";
            PureButton.Size = new Size(168, 164);
            PureButton.TabIndex = 2;
            PureButton.Text = "📐 Pure Mathematics\r\n\r\nPythagoras Theorem\r\nTrigonometry\r\nMatrices\r\nAlgebra\r\nCoordinate Geometry\r\n";
            PureButton.UseVisualStyleBackColor = true;
            // 
            // MechanicsButton
            // 
            MechanicsButton.Location = new Point(227, 473);
            MechanicsButton.Name = "MechanicsButton";
            MechanicsButton.Size = new Size(168, 164);
            MechanicsButton.TabIndex = 3;
            MechanicsButton.Text = "⚙️ Mechanics \r\n\r\nUVATS Equations\r\nNewton's Laws\r\n";
            MechanicsButton.UseVisualStyleBackColor = true;
            // 
            // StatisticsButton
            // 
            StatisticsButton.Location = new Point(449, 473);
            StatisticsButton.Name = "StatisticsButton";
            StatisticsButton.Size = new Size(168, 164);
            StatisticsButton.TabIndex = 4;
            StatisticsButton.Text = "📊 Statistics\r\n\r\nAverages\r\nBivariate Analysis\r\nStandard Deviation\r\n";
            StatisticsButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(605, 51);
            label1.TabIndex = 5;
            label1.Text = "WELCOME TO THE MATHS ENGINE";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 761);
            Controls.Add(label1);
            Controls.Add(StatisticsButton);
            Controls.Add(MechanicsButton);
            Controls.Add(PureButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Maths Engine";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private Button PureButton;
        private Button MechanicsButton;
        private Button StatisticsButton;
        private Label label1;
    }
}