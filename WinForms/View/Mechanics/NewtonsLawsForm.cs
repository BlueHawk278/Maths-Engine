using MathsEngine.WinForms.Forms;
using WinForms.Forms;

namespace MathsEngine.WinForms.View.Mechanics
{
    public partial class NewtonsLawsForm : BaseCalculatorControl
    {
        public NewtonsLawsForm(MainForm mainForm) : base(mainForm) 
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainForm.LoadView(new MechanicsMenu(MainForm));
        }
    }
}
