namespace MathsEngine.WinForms.Views.Statistics.Bivariate_Analysis;

public partial class BivariateAnalysisCalculatorView : BaseViewControl
{
    public BivariateAnalysisCalculatorView()
    {
        InitializeComponent();

        TitleLabel = "Bivariate Analysis Calculator";

        ThemeManager.ApplyTheme(this);
    }

    protected override void btnBack_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new StatisticsHub());
        }
    }
}