using MathsEngine.Presentation.Presenters.Pure.PythagorasTheorem;
using MathsEngine.WinForms.Views.Pure;

namespace MathsEngine.WinForms.Views.Pure.Pythagoras
{
    public partial class PythagorasCalculatorView : UserControl, IPythagorasView
    {
        private PythagorasPresenter _presenter;

        public PythagorasCalculatorView()
        {
            InitializeComponent();
            _presenter = new PythagorasPresenter(this);
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
            {
                mainForm.LoadView(new PureHub());
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculateAttempted?.Invoke(this, EventArgs.Empty);
        }

        public void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public double? SideA
        {
            get => double.TryParse(TextBoxSideA.Text, out double a) ? a : null;
            set => TextBoxSideA.Text = Convert.ToString(value);
        }

        public double? SideB
        {
            get => double.TryParse(TextBoxSideB.Text, out double b) ? b : null;
            set => TextBoxSideB.Text = Convert.ToString(value);
        }

        public double? Hypotenuse
        {
            get => double.TryParse(TextBoxHypotenuse.Text, out double h) ? h : null;
            set => TextBoxHypotenuse.Text = Convert.ToString(value);
        }
        public bool FindHypotenuseChecked
        {
            get => HypotenuseButton.Checked;
            set => HypotenuseButton.Checked = value;
        }

        public bool FindOtherSideChecked
        {
            get => OtherSideButton.Checked;
            set => OtherSideButton.Checked = value;
        }

        public string Result { get => ResultTextBox.Text; set => ResultTextBox.Text = value; }
        public string Steps { get => StepsTextBox.Text; set => StepsTextBox.Text = value; }

        public event EventHandler CalculateAttempted;
        public event EventHandler ClearAttempted;
    }
}
