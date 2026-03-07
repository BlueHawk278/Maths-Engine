using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathsEngine.WinForms.Forms.Pure;
using WinForms.Forms;

namespace MathsEngine.WinForms.Forms
{
    public partial class PureForm : Form
    {
        public PureForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();

            Hide();
        }

        private void PythagorasButton_Click(object sender, EventArgs e)
        {
            var pythagorasForm = new PythagorasForm();
            pythagorasForm.Show();

            Hide();
        }
    }
}
