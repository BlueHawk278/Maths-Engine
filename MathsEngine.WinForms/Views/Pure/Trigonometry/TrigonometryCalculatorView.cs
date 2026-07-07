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
            if (CalculateOtherSideButton.Checked)
            {
                AngleTextBox.Enabled = true;
            }
        }

        private void calculateMissingAngleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (calculateMissingAngleButton.Checked)
            {
                AngleTextBox.Enabled = false;
                AngleTextBox.Clear();
            }
        }
    }
}
