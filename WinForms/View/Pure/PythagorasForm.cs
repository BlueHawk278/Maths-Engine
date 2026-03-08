using OpenTK.Audio.OpenAL;
using WinForms.Forms;
using WinForms.Presenters.Pure.PythagorasTheorem;

namespace MathsEngine.WinForms.Forms.Pure
{
    public partial class PythagorasForm : BaseForm, IPythagorasView
    {
        private PythagorasPresenter _presenter;

        public PythagorasForm()
        {
            InitializeComponent();
            _presenter = new PythagorasPresenter(this);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAttempted?.Invoke(this, EventArgs.Empty);
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
            get => FindHypotenuseRadioButton.Checked;
            set => FindHypotenuseRadioButton.Checked = value;
        }

        public bool FindOtherSideChecked
        {
            get => FindOtherSideRadioButton.Checked;
            set => FindOtherSideRadioButton.Checked = value;
        }

        public string Result { get => ResultLabel.Text; set => ResultLabel.Text = value; }
        public string Steps { get => StepsTextBox.Text; set => StepsTextBox.Text = value; }

        public event EventHandler CalculateAttempted;
        public event EventHandler ClearAttempted;
    }
}