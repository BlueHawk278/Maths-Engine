using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathsEngine.WinForms.View.Mechanics;
using WinForms.Forms;

namespace MathsEngine.WinForms.Forms
{
    public partial class MechanicsMenu : Form
    {
        public MechanicsMenu()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();

            Hide();
        }

        private void NewtonsLawsButton_Click(object sender, EventArgs e)
        {
            var newtonsLawForm = new NewtonsLawsForm();
            newtonsLawForm.Show();

            Hide();
        }

        private void UniformAccelerationButton_Click(object sender, EventArgs e)
        {
            var uniformAccelerationForm = new UniformAccelerationForm();
            uniformAccelerationForm.Show();

            Hide();
        }
    }
}
