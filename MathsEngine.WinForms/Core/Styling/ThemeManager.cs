using MathsEngine.WinForms.Controls.Display;
using MathsEngine.WinForms.Core.Styling;

namespace MathsEngine.WinForms;

public static class ThemeManager
{
    public static void ApplyTheme(Control parentControl)
    {
        parentControl.BackColor = ThemeSettings.BackgroundColor;
        parentControl.Font = ThemeSettings.BaseFont;

        foreach (Control control in parentControl.Controls)
        {
            // Apply specific control styles
            if (control is Button btn)
                btn.Font = ThemeSettings.ButtonFont;

            if (control is Label lbl)
                lbl.Font = ThemeSettings.BaseFont;

            if (control is TitleLabel titleLbl)
                titleLbl.Font = ThemeSettings.TitleFont;

            // If the control has children (like a Panel), recursively theme them
            if (control.HasChildren)
            {
                ApplyTheme(control);
            }
        }
    }
}