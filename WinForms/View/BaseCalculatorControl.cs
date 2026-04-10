using WinForms.Forms;

namespace MathsEngine.WinForms.View
{
    public partial class BaseCalculatorControl : UserControl
    {
        protected readonly MainForm MainForm;

        public BaseCalculatorControl(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        public string Title
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        public string ResultText
        {
            get => ResultValueLabel.Text;
            set => ResultValueLabel.Text = value;
        }

        public string StepsText
        {
            get => StepsTextBox.Text;
            set => StepsTextBox.Text = value;
        }

        public event EventHandler? CalculateAttempted;
        public event EventHandler? ClearAttempted;

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAttempted?.Invoke(this, EventArgs.Empty);
        }
    }
}