using MathsEngine.WinForms.Core.Styling;

namespace MathsEngine.WinForms.Controls.Navigation;

public class BaseButton : Button
{
    public BaseButton()
    {
        FlatStyle = FlatStyle.Flat;
        //Font = Fonts.Default;
        //BackColor = Theme.Primary;
        ForeColor = Color.Black;
    }
}