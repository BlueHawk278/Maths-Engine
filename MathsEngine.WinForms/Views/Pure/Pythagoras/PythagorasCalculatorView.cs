using MathsEngine.Core.Presenters.Pure.PythagorasTheorem;

namespace MathsEngine.WinForms.Views.Pure.Pythagoras
{
    public partial class PythagorasCalculatorView : CalculatorViewControl, IPythagorasView
    {
        private readonly PythagorasPresenter _presenter;

        public PythagorasCalculatorView()
        {
            InitializeComponent();

            TitleLabel = "Welcome to the Pythagoras Theorem Calculator";

            ThemeManager.ApplyTheme(this);

            _presenter = new PythagorasPresenter(this);
        }

        protected override void btnBack_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
            {
                mainForm.LoadView(new PureHub());
            }
        }

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
    }
}