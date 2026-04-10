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
    public partial class TrigonometryMenu : BaseForm
    {
        public TrigonometryMenu()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var pureMenuForm = new PureMenu();
            pureMenuForm.Show();

            Hide();
        }

        private void rightAngleButton_Click(object sender, EventArgs e)
        {
            var rightAngleTrigForm = new RightAngleTrigForm();
            rightAngleTrigForm.Show();

            Hide();
        }
    }
}
