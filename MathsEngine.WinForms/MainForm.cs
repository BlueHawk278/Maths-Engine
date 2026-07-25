using MathsEngine.WinForms.Views;
using MathsEngine.WinForms.Views.Pure;
using MathsEngine.WinForms.Views.Statistics;

namespace MathsEngine.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadView(new Home());
        }

        public void LoadView(UserControl newUserControl)
        {
            if (mainContentPanel.Controls.Count > 0)
            {
                var old = mainContentPanel.Controls[0];
                mainContentPanel.Controls.Clear();
                old.Dispose();
            }

            newUserControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(newUserControl);
            newUserControl.BringToFront();
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            LoadView(new Home());
        }

        private void pureButton_Click(object sender, EventArgs e)
        {
            LoadView(new PureHub());
        }

        private void mechanicsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mechanics view is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            LoadView(new StatisticsHub());
        }
    }
}
