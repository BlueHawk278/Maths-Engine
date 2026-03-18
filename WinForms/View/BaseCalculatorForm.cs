using ScottPlot.Panels;
using System;
using System.Windows.Forms;
using WinForms.Forms;

namespace WinForms.View
{
    /// <summary>
    /// Base calculator layout: InputPanel, ResultPanel, StepsTextBox, Calculate/Clear buttons.
    /// Intended to be inherited by calculator-style forms (e.g., Pythagoras).
    /// </summary>
    public partial class BaseCalculatorForm : BaseForm
    {
        public BaseCalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Derived forms can set the title label text.
        /// </summary>
        public string Title
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        /// <summary>
        /// Derived forms typically bind their "Result" output to this.
        /// </summary>
        public string ResultText
        {
            get => ResultValueLabel.Text;
            set => ResultValueLabel.Text = value;
        }

        /// <summary>
        /// Derived forms typically bind their "Steps" output to this.
        /// </summary>
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