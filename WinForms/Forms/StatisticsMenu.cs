using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Forms;

namespace MathsEngine.WinForms.Forms
{
    public partial class StatisticsMenu : Form
    {
        public StatisticsMenu()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }
    }
}
