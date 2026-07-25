using MathsEngine.WinForms.Views.Pure.Matrices;
using MathsEngine.WinForms.Views.Pure.Pythagoras;
using MathsEngine.WinForms.Views.Pure.Trigonometry;

namespace MathsEngine.WinForms.Views.Pure;

public partial class PureHub : BaseViewControl
{
    public PureHub()
    {
        InitializeComponent();

        TitleLabel = "Welcome to the Pure Hub";

        ThemeManager.ApplyTheme(this);
    }

    protected override void btnBack_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new Home());
        }
    }

    private void pythagorasButton_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new PythagorasCalculatorView());
        }
    }

    private void algebraButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Algebra is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void coordGeometryButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Co-ordinate Geometry is not implemented yet.", "Maths Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void matricesButton_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new MatricesCalculatorView());
        }
    }

    private void trigonometryButton_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new TrigonometryCalculatorView());
        }
    }
}