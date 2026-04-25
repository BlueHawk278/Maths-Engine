using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathsEngine.WinForms.Forms;
using MathsEngine.WinForms.View.Menu;

namespace WinForms.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void LoadView(UserControl view)
        {
            ContentPanel.SuspendLayout();

            // Dispose the current control if one exists
            if (ContentPanel.Controls.Count > 0)
            {
                var old = ContentPanel.Controls[0];
                ContentPanel.Controls.Clear();
                old.Dispose();
            }

            // Size the new control to fill the panel
            view.Dock = DockStyle.Fill;
            ContentPanel.Controls.Add(view);
            ContentPanel.ResumeLayout();
        }

        public void GoHome()
        {
            if (ContentPanel.Controls.Count > 0)
            {
                var old = ContentPanel.Controls[0];
                ContentPanel.Controls.Clear();
                old.Dispose();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadView(new MainMenu(this));
        }

        private void PureButton_Click(object sender, EventArgs e)
        {
            LoadView(new PureMenu(this));
        }

        private void MechanicsButton_Click(object sender, EventArgs e)
        {
            LoadView(new MechanicsMenu(this));
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            LoadView(new StatisticsMenu(this));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
