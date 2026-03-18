using System;
using System.Windows.Forms;
using WinForms.Presenters.Pure.PythagorasTheorem;
using WinForms.View;

namespace MathsEngine.WinForms.Forms.Pure
{
    public partial class PythagorasForm : BaseCalculatorForm, IPythagorasView
    {
        private readonly PythagorasPresenter _presenter;

        public PythagorasForm()
        {
            InitializeComponent();

            // Use the base calculator chrome
            Title = "Pythagoras Theorem";

            // Bridge base events -> view events expected by presenter
            CalculateAttempted += (_, __) => CalculateAttemptedView?.Invoke(this, EventArgs.Empty);
            ClearAttempted += (_, __) => ClearAttemptedView?.Invoke(this, EventArgs.Empty);

            _presenter = new PythagorasPresenter(this);
        }

        public void ShowError(string message) =>
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public double? SideA
        {
            get => double.TryParse(TextBoxSideA.Text, out var a) ? a : null;
            set => TextBoxSideA.Text = Convert.ToString(value);
        }

        public double? SideB
        {
            get => double.TryParse(TextBoxSideB.Text, out var b) ? b : null;
            set => TextBoxSideB.Text = Convert.ToString(value);
        }

        public double? Hypotenuse
        {
            get => double.TryParse(TextBoxHypotenuse.Text, out var h) ? h : null;
            set => TextBoxHypotenuse.Text = Convert.ToString(value);
        }

        public bool FindHypotenuseChecked
        {
            get => FindHypotenuseRadioButton.Checked;
            set => FindHypotenuseRadioButton.Checked = value;
        }

        public bool FindOtherSideChecked
        {
            get => FindOtherSideRadioButton.Checked;
            set => FindOtherSideRadioButton.Checked = value;
        }

        // Map to BaseCalculatorForm's labels/textbox
        public string Result
        {
            get => ResultText;
            set => ResultText = value;
        }

        public string Steps
        {
            get => StepsText;
            set => StepsText = value;
        }

        // IPythagorasView events (kept distinct name to avoid clashing with base events)
        public event EventHandler? CalculateAttemptedView;
        public event EventHandler? ClearAttemptedView;

        // If your IPythagorasView interface specifically requires these exact names,
        // rename the two events above to CalculateAttempted / ClearAttempted and
        // remove the BaseCalculatorForm events (or make BaseCalculatorForm expose protected raisers instead).
    }
}