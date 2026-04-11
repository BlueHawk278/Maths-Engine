using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathsEngine.WinForms.View;
using WinForms.Forms;

namespace MathsEngine.WinForms.Forms.Pure
{
    public partial class RightAngleTrigControl : BaseCalculatorControl
    {
        public RightAngleTrigControl()
        {
            InitializeComponent();
        }

        public RightAngleTrigControl(MainForm mainForm) : base(mainForm)
        {
            InitializeComponent();
        }
    }
}
