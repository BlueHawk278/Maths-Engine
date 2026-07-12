using MathsEngine.Core.Modules.Pure.Trigonometry;
using MathsEngine.Presentation.Presenters.Pure.Trigonometry;

namespace MathsEngine.WinForms.Views.Pure.Trigonometry
{
    public partial class TrigonometryCalculatorView : UserControl, ITrigonometryView
    {
        private TrigonometryPresenter _presenter;

        public TrigonometryCalculatorView()
        {
            InitializeComponent();

            ThemeManager.ApplyTheme(this);

            _presenter = new TrigonometryPresenter(this);
        }

        private void CalculateOtherSideButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isSideCalculation = CalculateOtherSideButton.Checked;
            AngleTextBox.Enabled = isSideCalculation;
            TargetSideComboBox.Enabled = isSideCalculation;

            if (!isSideCalculation)
            {
                TargetSideComboBox.SelectedIndex = -1; // Reset selection
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

        private void CheckValidCalculationButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckValidCalculationButton.Checked)
            {
                AngleTextBox.Enabled = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
                mainForm.LoadView(new PureHub());
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAttempted.Invoke(this, EventArgs.Empty);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculateAttempted.Invoke(this, EventArgs.Empty);
        }

        public void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public double? Hypotenuse
        {
            get => double.TryParse(HypotenuseTextBox.Text, out double h) ? h : null;
            set => HypotenuseTextBox.Text = Convert.ToString(value);
        }

        public double? Opposite
        {
            get => double.TryParse(OppositeTextBox.Text, out double o) ? o : null;
            set => OppositeTextBox.Text = Convert.ToString(value);
        }

        public double? Adjacent
        {
            get => double.TryParse(AdjacentTextBox.Text, out double a) ? a : null;
            set => AdjacentTextBox.Text = Convert.ToString(value);
        }

        public double? Angle
        {
            get => double.TryParse(AngleTextBox.Text, out double angle) ? angle : null;
            set => AngleTextBox.Text = Convert.ToString(value);
        }

        public bool FindOtherSideChecked
        {
            get => CalculateOtherSideButton.Checked;
            set => CalculateOtherSideButton.Checked = value;
        }

        public bool FindMissingAngleChecked
        {
            get => calculateMissingAngleButton.Checked;
            set => calculateMissingAngleButton.Checked = value;
        }

        public bool CheckValidCalculationChecked
        {
            get => CheckValidCalculationButton.Checked;
            set => CheckValidCalculationButton.Checked = value;
        }

        public SideType? TargetSide
        {
            get
            {
                if (TargetSideComboBox.SelectedItem == null) return null;

                string selected = TargetSideComboBox.SelectedItem.ToString();
                return selected switch
                {
                    "Hypotenuse" => SideType.Hypotenuse,
                    "Opposite" => SideType.Opposite,
                    "Adjacent" => SideType.Adjacent,
                    _ => null
                };
            }
            set
            {
                if (value == null)
                {
                    TargetSideComboBox.SelectedIndex = -1;
                }
                else
                {
                    TargetSideComboBox.SelectedItem = value.ToString();
                }
            }
        }

        public string Result
        {
            get => ResultTextBox.Text;
            set => ResultTextBox.Text = value;
        }

        public string Steps
        {
            get => explanationTextBox.Text;
            set => explanationTextBox.Text = value;
        }

        public event EventHandler CalculateAttempted;
        public event EventHandler ClearAttempted;
    }
}
