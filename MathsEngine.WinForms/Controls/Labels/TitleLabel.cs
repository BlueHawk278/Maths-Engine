using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MathsEngine.WinForms.Core.Styling;

namespace MathsEngine.WinForms.Controls.Display
{
    [ToolboxItem(true)]
    public class TitleLabel : Label
    {
        public TitleLabel()
        {
            this.Font = ThemeSettings.TitleFont;
            this.ForeColor = ThemeSettings.ForegroundColor;
            this.AutoSize = true;
        }
    }
}