using MathsEngine.WinForms.Controls.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsEngine.WinForms.Views.Pure.Matrices
{
    public partial class MatricesCalculatorView : BaseViewControl
    {
        public MatricesCalculatorView()
        {
            InitializeComponent();

            TitleLabel = "Matrices Calculator";

            ThemeManager.ApplyTheme(this);
        }

        protected override void btnBack_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
            {
                mainForm.LoadView(new PureHub());
            }
        }
    }
}
