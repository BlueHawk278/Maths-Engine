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

namespace WinForms.Forms
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.BackButton.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void PureButton_Click(object sender, EventArgs e)
        {
            var pureForm = new PureForm();
            pureForm.Show();

            this.Hide();
        }

        private void MechanicsButton_Click(object sender, EventArgs e)
        {
            var mechanicsForm = new MechanicsMenu();
            mechanicsForm.Show();

            this.Hide();
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            var statisticsForm = new StatisticsMenu();
            statisticsForm.Show();

            this.Hide();
        }
    }
}
