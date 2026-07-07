using MathsEngine.WinForms.Views.Pure;

namespace MathsEngine.WinForms.Views.Pure.Trigonometry
{
    public partial class TrigonometryCalculatorView : UserControl
    {
        public TrigonometryCalculatorView()
        {
            InitializeComponent();

            ThemeManager.ApplyTheme(this);

            backButton1.BackRequested += (_, _) =>
            {
                if (FindForm() is MainForm mainForm)
                {
                    mainForm.LoadView(new PureHub());
                }
            };
        }

        private void CalculateOtherSideButton_CheckedChanged(object sender, EventArgs e)
        {
            // If we're calculating a missing side, the angle is required.
            if (CalculateOtherSideButton.Checked)
            {
                AngleTextBox.Enabled = true;
            }
        }

        private void calculateMissingAngleButton_CheckedChanged(object sender, EventArgs e)
        {
            // If we're calculating the missing angle, disable angle input.
            if (calculateMissingAngleButton.Checked)
            {
                AngleTextBox.Enabled = false;
                AngleTextBox.Clear();
            }
        }
    }
}
