using MathsEngine.WinForms.Core.Styling;

namespace MathsEngine.WinForms.Views;

public partial class BaseViewControl : UserControl
{
    public BaseViewControl()
    {
        InitializeComponent();

        Size = ThemeSettings.MainPanelSize;

        BackButton.Click += btnBack_Click;
    }

    // Allows inheriting controls to easily change the name of the
    public string TitleLabel
    {
        get => lblTitle.Text;
        set => lblTitle.Text = value;
    }

    // Allows inheriting controls to easily change the implementation of the back button click event
    protected virtual void btnBack_Click(object sender, EventArgs e) { }
}