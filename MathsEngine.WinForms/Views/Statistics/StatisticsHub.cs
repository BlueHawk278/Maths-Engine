using MathsEngine.WinForms.Views.Statistics.Bivariate_Analysis;

namespace MathsEngine.WinForms.Views.Statistics;

public partial class StatisticsHub : BaseViewControl
{
    public StatisticsHub()
    {
        InitializeComponent();

        TitleLabel = "Welcome to the Statistics Hub";

        ThemeManager.ApplyTheme(this);
    }

    protected override void btnBack_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new Home());
        }
    }

    private void bivariateAnalysisButton_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new BivariateAnalysisCalculatorView());
        }
    }

    private void dispersionButton_Click(object sender, EventArgs e)
    {

    }
}