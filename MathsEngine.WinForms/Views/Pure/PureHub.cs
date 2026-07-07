using MathsEngine.WinForms.Views.Pure.Pythagoras;
using MathsEngine.WinForms.Views.Pure.Trigonometry;
using MathsEngine.WinForms.Views;

namespace MathsEngine.WinForms.Views.Pure
{
    public partial class PureHub : UserControl
    {
        public PureHub()
        {
            InitializeComponent();

            ThemeManager.ApplyTheme(this);

            // Navigation: go back to the Home view.
            backButton1.BackRequested += (_, _) =>
            {
                if (FindForm() is MainForm mainForm)
                {
                    mainForm.LoadView(new Home());
                }
            };
        }

        private void pythagorasButton_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
            {
                mainForm.LoadView(new PythagorasCalculatorView());
            }
        }

        private void algebraButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Algebra is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void coordGeometryButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Co-ordinate Geometry is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void matricesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Matrices is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void trigonometryButton_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
            {
                mainForm.LoadView(new TrigonometryCalculatorView());
            }
        }
    }
}
