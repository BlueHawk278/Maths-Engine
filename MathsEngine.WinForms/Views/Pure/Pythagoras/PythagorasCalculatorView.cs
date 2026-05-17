using MathsEngine.WinForms.Views.Pure;

namespace MathsEngine.WinForms.Views.Pure.Pythagoras
{
    public partial class PythagorasCalculatorView : UserControl
    {
        public PythagorasCalculatorView()
        {
            InitializeComponent();

            // Navigation: go back to the Pure hub.
            backButton1.BackRequested += (_, _) =>
            {
                if (FindForm() is MainForm mainForm)
                {
                    mainForm.LoadView(new PureHub());
                }
            };
        }
    }
}
