using MathsEngine.WinForms.Views;
using MathsEngine.WinForms.Views.Pure;

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
            // Default view when the app starts.
            LoadView(new Home());
        }

        public void LoadView(UserControl newUserControl)
        {
            //mainContentPanel.SuspendLayout();

            // Dispose the current control because it's not needed anymore.
            if (mainContentPanel.Controls.Count > 0)
            {
                var old = mainContentPanel.Controls[0];
                mainContentPanel.Controls.Clear();
                old.Dispose();
            }

            newUserControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(newUserControl);
            newUserControl.BringToFront();

            //mainContentPanel.ResumeLayout();
        }
        
        private void pureButton_Click(object sender, EventArgs e)
        {
            LoadView(new PureHub());
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            LoadView(new Home());
        }

        private void mechanicsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mechanics view is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Statistics view is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
