using MathsEngine.Modules.Explanations;
using MathsEngine.Modules.Explanations.Pure;
using WinForms.Forms;

namespace MathsEngine.WinForms.Forms.Pure
{
    public partial class PythagorasForm : BaseForm
    {
        public PythagorasForm()
        {
            InitializeComponent();

            FindHypotenuseRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            FindOtherSideRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            CalculateButton.Click += CalculateButton_Click;
            ClearButton.Click += ClearButton_Click;
            FindHypotenuseRadioButton.Checked = true;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isFindingHypotenuse = FindHypotenuseRadioButton.Checked;

            TextBoxSideA.ReadOnly = false;
            TextBoxSideB.ReadOnly = !isFindingHypotenuse;
            TextBoxHypotenuse.ReadOnly = isFindingHypotenuse;

            if (isFindingHypotenuse)
            {
                TextBoxHypotenuse.Text = string.Empty;
            }
            else
            {
                TextBoxSideB.Text = string.Empty;
            }
        }

        private void FindHypotenuseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Logic to adjust UI when this radio button is checked
            TextBoxHypotenuse.Enabled = false;
            TextBoxSideA.Enabled = true;
            TextBoxSideB.Enabled = true;
        }

        private void FindOtherSideRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Logic to adjust UI when this radio button is checked
            TextBoxHypotenuse.Enabled = true;
            TextBoxSideA.Enabled = true;
            TextBoxSideB.Enabled = false; // Or adjust as needed for your logic
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            ResultLabel.Text = string.Empty;

            if (FindHypotenuseRadioButton.Checked)
            {
                if (double.TryParse(TextBoxSideA.Text, out var sideA) && double.TryParse(TextBoxSideB.Text, out var sideB))
                {
                    var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(sideA, sideB);
                    ResultLabel.Text = result.Value.ToString("F4");
                    richTextBox1.Text = result.GetStepsAsString();
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for Side A and Side B.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (FindOtherSideRadioButton.Checked)
            {
                if (double.TryParse(TextBoxSideA.Text, out var sideA) && double.TryParse(TextBoxHypotenuse.Text, out var hypotenuse))
                {
                    if (hypotenuse <= sideA)
                    {
                        MessageBox.Show("Hypotenuse must be greater than Side A.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(sideA, hypotenuse);
                    ResultLabel.Text = result.Value.ToString("F4");
                    richTextBox1.Text = result.GetStepsAsString();
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for Side A and Hypotenuse.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextBoxSideA.Clear();
            TextBoxSideB.Clear();
            TextBoxHypotenuse.Clear();
            ResultLabel.Text = string.Empty;
            richTextBox1.Clear();
        }
    }
}