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

    // Allows inheriting controls to easily change the name of the Title
    public string TitleLabel
    {
        get => lblTitle.Text;
        set => lblTitle.Text = value;
    }

    // Allows inheriting controls to easily change the implementation of the back button click event.
    // Base implementation navigates back to the Home view in case the control hasn't been overridden,
    // which would cause an error if the back button is clicked.
    protected virtual void btnBack_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new Home());
        }
    }
}