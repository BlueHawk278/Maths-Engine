namespace MathsEngine.WinForms.Controls.Navigation;

public class BackButton : BaseButton
{
    public event EventHandler? BackRequested;

    public BackButton()
    {
        Text = "← Back";
        Width = 100;
        Height = 50;
        Location = new Point(10, 10);
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        BackRequested?.Invoke(this, EventArgs.Empty);
    }
}