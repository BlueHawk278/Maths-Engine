using MathsEngine.WinForms.Forms;
using WinForms.Forms;

namespace MathsEngine.WinForms.View.Menu
{
    public partial class MainMenu : UserControl
    {
        private readonly MainForm _mainForm;

        public MainMenu(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void pureMenuButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new PureMenu(_mainForm));
        }

        private void mechanicsButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new MechanicsMenu(_mainForm));
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new StatisticsMenu(_mainForm));
        }
    }
}
