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
using WinForms.Forms;
using WinForms.View;

namespace MathsEngine.WinForms.View.Mechanics
{
    public partial class UniformAccelerationForm : BaseCalculatorForm
    {
        public UniformAccelerationForm()
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
