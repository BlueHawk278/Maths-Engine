using MathsEngine.WinForms.Controls.Navigation;
using MathsEngine.WinForms.Core.Styling;
using MathsEngine.Core.Modules.Explanations;

namespace MathsEngine.WinForms.Views.Statistics.Bivariate_Analysis;

public partial class BivariateAnalysisCalculatorView : BaseViewControl
{
    private Panel _containerPanel;
    private NumericUpDown _numericUpDown1;
    private DataGridView _dataGridView;
    private CalculateButton _calculateButton;
    private ClearButton _clearButton;

    public BivariateAnalysisCalculatorView()
    {
        InitializeComponent();

        TitleLabel = "Bivariate Analysis Calculator";

        InitializeCustomLayout();
        SetupGrid((int)_numericUpDown1.Value);

        InitializeCustomButtons();

        ThemeManager.ApplyTheme(this);
    }

    private void InitializeCustomLayout()
    {
        // Panel container
        _containerPanel = new Panel();
        _containerPanel.Location = new Point(10, 100);
        _containerPanel.Size = new Size(525, 280);
        _containerPanel.BorderStyle = BorderStyle.FixedSingle;

        // NumericUpDown configuration (5 to 10 columns)
        _numericUpDown1 = new NumericUpDown();
        _numericUpDown1.Location = new Point(190, 15);
        _numericUpDown1.Size = new Size(60, 23);
        _numericUpDown1.Minimum = 5;
        _numericUpDown1.Maximum = 10;
        _numericUpDown1.Value = 5;
        _numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;

        Label lblChoose = new Label();
        lblChoose.Text = "Number of Data Columns:";
        lblChoose.Location = new Point(15, 15);
        lblChoose.AutoSize = true;

        // DataGridView config
        _dataGridView = new DataGridView();
        _dataGridView.Location = new Point(15, 50);
        _dataGridView.Size = new Size(493, 210);
        _dataGridView.AllowUserToAddRows = false; // Prevents the empty bottom row
        _dataGridView.RowHeadersVisible = false;  // Hides the default left margin arrow column

        // Add components to panel
        _containerPanel.Controls.Add(_numericUpDown1);
        _containerPanel.Controls.Add(lblChoose);
        _containerPanel.Controls.Add(_dataGridView);

        Controls.Add(_containerPanel);
        Size = new Size(800, 350);
        Text = "Data Analysis Grid";
    }

    private void SetupGrid(int desiredDataColumns)
    {
        _dataGridView.Columns.Clear();

        DataGridViewTextBoxColumn itemColumn = new DataGridViewTextBoxColumn();
        itemColumn.Name = "ItemHeader";
        itemColumn.HeaderText = "";
        itemColumn.Width = 90;
        itemColumn.DefaultCellStyle.Font = new Font(_dataGridView.Font, FontStyle.Bold);
        itemColumn.DefaultCellStyle.BackColor = Color.WhiteSmoke;
        itemColumn.SortMode = DataGridViewColumnSortMode.NotSortable; // Prevents sorting on click
        _dataGridView.Columns.Add(itemColumn);

        // Generate data columns dynamically (A, B, C, D...)
        for (int i = 0; i < desiredDataColumns; i++)
        {
            DataGridViewTextBoxColumn dataColumn = new DataGridViewTextBoxColumn();
            // Converts index 0, 1, 2... into 'A', 'B', 'C'...
            char columnLetter = (char)('A' + i);

            dataColumn.Name = $"Col{columnLetter}";
            dataColumn.HeaderText = columnLetter.ToString();
            dataColumn.Width = 40;
            dataColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataColumn.SortMode = DataGridViewColumnSortMode.NotSortable; // Prevents sorting on click
            _dataGridView.Columns.Add(dataColumn);
        }

        string[] rowTitles = { "Score 1", "Score 2", "Rank 1", "Rank 2", "d", "d²" };

        for (int r = 0; r < rowTitles.Length; r++)
        {
            int rowIndex = _dataGridView.Rows.Add();
            // Assign the row title to the first column
            _dataGridView.Rows[rowIndex].Cells[0].Value = rowTitles[r];

            if (r > 1)
            {
                _dataGridView.Rows[rowIndex].ReadOnly = true;
                _dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }

    private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        SetupGrid((int)_numericUpDown1.Value);
    }

    private void InitializeCustomButtons()
    {
        _calculateButton = new CalculateButton();
        _clearButton = new ClearButton();

        _calculateButton.Text = "Calculate";
        _calculateButton.Name = "calculateButton";
        _calculateButton.Size = ThemeSettings.ActionButtonSize;
        _calculateButton.Location = new Point(10, 400);
        _calculateButton.Click += calculateButton_Click;

        _clearButton.Text = "Clear";
        _clearButton.Name = "clearButton";
        _clearButton.Size = ThemeSettings.ActionButtonSize;
        _clearButton.Location = new Point(285, 400);
        _clearButton.Click += clearButton_Click;

        Controls.Add(_calculateButton);
        Controls.Add(_clearButton);
    }

    private void calculateButton_Click(object sender, EventArgs e)
    {
        List<double> scores1 = new List<double>();
        List<double> scores2 = new List<double>();

        // Make sure we actually have rows to read from
        if (_dataGridView.Rows.Count >= 2)
        {
            // Start at i = 1 to skip the first column (index 0)
            for (int i = 1; i < _dataGridView.Rows[0].Cells.Count; i++)
            {
                var cellValue = _dataGridView.Rows[0].Cells[i].Value;
                if (cellValue != null && double.TryParse(cellValue.ToString(), out double val))
                {
                    scores1.Add(val);
                }
            }

            // Start at i = 1 to skip the first column (index 0)
            for (int i = 1; i < _dataGridView.Rows[1].Cells.Count; i++)
            {
                var cellValue = _dataGridView.Rows[1].Cells[i].Value;
                if (cellValue != null && double.TryParse(cellValue.ToString(), out double val))
                {
                    scores2.Add(val);
                }
            }
        }

        var result = Modules.Explanations.Statistics.BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        StepsTextBox.Text = result.GetStepsAsString();
    }

    private void clearButton_Click(object sender, EventArgs e)
    {

    }

    protected override void btnBack_Click(object sender, EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.LoadView(new StatisticsHub());
        }
    }
}