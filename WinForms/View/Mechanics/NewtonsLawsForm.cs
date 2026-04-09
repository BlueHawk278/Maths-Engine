using MathsEngine.WinForms.Forms;
using WinForms.Forms;
using WinForms.View;

namespace MathsEngine.WinForms.View.Mechanics
{
    public partial class NewtonsLawsForm : BaseCalculatorForm
    {
        public NewtonsLawsForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mechanicsMenuForm = new MechanicsMenu();
            mechanicsMenuForm.Show();

            Hide();
        }
    }
}
