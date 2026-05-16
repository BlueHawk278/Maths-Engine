using MathsEngine.WinForms.Views.Pure;

namespace MathsEngine.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadView(UserControl newUserControl)
        {
            
            mainContentPanel.Controls.Clear();
            newUserControl.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(newUserControl);
            newUserControl.BringToFront();
        }

        
        private void pureButton_Click(object sender, EventArgs e)
        {
            LoadView(new PureHub());
        }
    }
}
