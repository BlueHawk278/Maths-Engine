using MathsEngine.WinForms.View;
using WinForms.Forms;
using MathsEngine.Application.Presenters.Pure.PythagorasTheorem;

namespace MathsEngine.WinForms.Forms.Pure
{
    public partial class PythagorasControl : BaseCalculatorControl, IPythagorasView
    {
        private readonly PythagorasPresenter _presenter;
        protected readonly MainForm mainForm;

        public PythagorasControl()
        {
            InitializeComponent();
        }

        public PythagorasControl(MainForm mainForm) : base(mainForm)
        {
            InitializeComponent();

            Title = "Pythagoras Theorem";

            CalculateAttempted += (_, __) => CalculateAttemptedView?.Invoke(this, EventArgs.Empty);
            ClearAttempted += (_, __) => ClearAttemptedView?.Invoke(this, EventArgs.Empty);

            _presenter = new PythagorasPresenter(this);
        }

        public void ShowError(string message) =>
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm.LoadView(new PureMenu(mainForm));
        }

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

        public event EventHandler? CalculateAttemptedView;
        public event EventHandler? ClearAttemptedView;
    }
}