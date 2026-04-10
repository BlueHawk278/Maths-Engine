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
using MathsEngine.WinForms.View.Menu;
using WinForms.Forms;

namespace MathsEngine.WinForms.Forms
{
    public partial class PureMenu : Form
    {
        public PureMenu()
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

        private void TrigonometryButton_Click(object sender, EventArgs e)
        {
            var trigonometryMenuForm = new TrigonometryMenu();
            trigonometryMenuForm.Show();

            Hide();
        }
    }
}
