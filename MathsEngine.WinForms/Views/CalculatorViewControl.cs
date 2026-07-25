namespace MathsEngine.WinForms.Views;

public abstract class CalculatorViewControl : BaseViewControl
{
    public event EventHandler? CalculateAttempted;
    public event EventHandler? ClearAttempted;

    private bool _buttonsWired;

    protected override void OnCreateControl()
    {
        base.OnCreateControl();

        if (!_buttonsWired)
        {
            WireCalculatorButtons(this);
            _buttonsWired = true;
        }
    }

    private void WireCalculatorButtons(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is Controls.Navigation.CalculateButton calcBtn)
                calcBtn.Click += (s, e) => CalculateAttempted?.Invoke(this, EventArgs.Empty);

            if (control is Controls.Navigation.ClearButton clearBtn)
                clearBtn.Click += (s, e) => ClearAttempted?.Invoke(this, EventArgs.Empty);

            if (control.HasChildren)
                WireCalculatorButtons(control);
        }
    }

    public void ShowError(string message) =>
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}