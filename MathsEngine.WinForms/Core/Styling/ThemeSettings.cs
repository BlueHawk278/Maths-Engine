namespace MathsEngine.WinForms.Core.Styling;

public static class ThemeSettings
{
    // Centralized variables
    public static readonly Color BackgroundColor = Color.White;
    public static readonly Color ForegroundColor = Color.Black;

    // Fonts
    public static readonly Font BaseFont = new Font("Segoe UI", 10F, FontStyle.Regular);
    public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
    public static readonly Font TitleFont = new Font("Segoe UI", 20F, FontStyle.Bold);

    // Layout settings
    public static Size MainPanelSize = new Size(1164, 657);
    public static Size ActionButtonSize = new Size(250, 60);

    public static Point BackButtonLocation = new Point(10, 10);
    public static Point TitleLabelLocation = new Point(160, 30);
}