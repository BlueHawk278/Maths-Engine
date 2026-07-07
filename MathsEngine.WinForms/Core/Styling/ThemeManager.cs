using MathsEngine.WinForms.Controls.Display;
using MathsEngine.WinForms.Controls.Navigation;
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
            if(control is UserControl)
                control.Size = ThemeSettings.MainPanelSize;

            // Apply specific control styles
            if (control is Button btn)
                btn.Font = ThemeSettings.ButtonFont;

            if (control is BackButton backBtn)
                backBtn.Location = ThemeSettings.BackButtonLocation;

            if (control is Label lbl)
                lbl.Font = ThemeSettings.BaseFont;

            if (control is TitleLabel titleLbl)
            {
                titleLbl.Font = ThemeSettings.TitleFont;
                titleLbl.Location = ThemeSettings.TitleLabelLocation;
            }

            // If the control has children (like a Panel), recursively theme them
            if (control.HasChildren)
            {
                ApplyTheme(control);
            }
        }
    }
}