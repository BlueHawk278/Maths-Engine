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
using MathsEngine.WinForms.Forms.Pure;
using WinForms.Forms;

namespace MathsEngine.WinForms.View.Menu
{
    public partial class TrigonometryMenu : UserControl
    {
        private readonly MainForm _mainForm;

        public TrigonometryMenu(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new PureMenu(_mainForm));
        }

        private void rightAngleButton_Click(object sender, EventArgs e)
        {
            _mainForm.LoadView(new RightAngleTrigForm(_mainForm));
        }
    }
}
