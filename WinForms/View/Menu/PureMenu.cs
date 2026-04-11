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
    public partial class PureMenu : UserControl
    {
        private readonly MainForm _mainForm;

        public PureMenu(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _mainForm.GoHome();
        }

        private void PythagorasButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new PythagorasControl(_mainForm));
        }

        private void TrigonometryButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new TrigonometryMenu(_mainForm));
        }
    }
}
