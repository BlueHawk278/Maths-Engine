using MathsEngine.Presentation.Presenters.Statistics.BivariateAnalysis;
using MathsEngine.WinForms.Controls.Display;

namespace MathsEngine.WinForms.Views.Statistics.Bivariate_Analysis
{
    public partial class BivariateAnalysisCalculatorView : BaseViewControl, IBivariateAnalysisView
    {
        private readonly BivariateAnalysisPresenter _presenter;

        public event EventHandler? CalculateAttempted;
        public event EventHandler? ClearAttempted;

        public BivariateAnalysisCalculatorView()
        {
            InitializeComponent();

            TitleLabel = "Bivariate Analysis Calculator";
            SetupGrid((int)_numericUpDown1.Value);

            _presenter = new BivariateAnalysisPresenter(this);

            ThemeManager.ApplyTheme(this);
        }

        public List<double> Scores1 => GatherRowData(0);
        public List<double> Scores2 => GatherRowData(1);

        public void DisplayResults(List<double> ranks1, List<double> ranks2, List<double> diffs,
                                   List<double> diffsSquared, double sumDiffSquared,
                                   double coefficient, string interpretation, string steps)
        {
            int dataColumnCount = _dataGridView.Columns.Count - 1;
            int count = Math.Min(dataColumnCount, ranks1.Count);

            for (int i = 0; i < count; i++)
            {
                int colIndex = i + 1;
                _dataGridView.Rows[2].Cells[colIndex].Value = ranks1[i];
                _dataGridView.Rows[3].Cells[colIndex].Value = ranks2[i];
                _dataGridView.Rows[4].Cells[colIndex].Value = diffs[i];
                _dataGridView.Rows[5].Cells[colIndex].Value = diffsSquared[i];
            }

            _lblSigmaDifferenceSquared.Text = $"Σd² = {sumDiffSquared:F2}";
            _lblCorrelation.Text = $"Correlation Coefficient = {coefficient:F3}";
            _lblCorrelationInterpretation.Text = $"Interpretation: {interpretation}";
            StepsTextBox.Text = steps;
        }

        public void ClearDisplay()
        {
            for (int r = 0; r < _dataGridView.Rows.Count; r++)
            {
                for (int c = 1; c < _dataGridView.Columns.Count; c++)
                {
                    _dataGridView.Rows[r].Cells[c].Value = null;
                }
            }

            _lblSigmaDifferenceSquared.Text = "Σd² = ";
            _lblCorrelation.Text = "Correlation Coefficient = ";
            _lblCorrelationInterpretation.Text = "Interpretation: ";
            StepsTextBox.Text = string.Empty;
        }

        public void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // UI Events
        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculateAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SetupGrid((int)_numericUpDown1.Value);

            clearButton_Click(this, EventArgs.Empty);
        }

        // Helper Methods
        private List<double> GatherRowData(int rowIndex)
        {
            var list = new List<double>();
            if (_dataGridView.Rows.Count > rowIndex)
            {
                for (int i = 1; i < _dataGridView.Columns.Count; i++)
                {
                    var cellValue = _dataGridView.Rows[rowIndex].Cells[i].Value;
                    if (cellValue != null && double.TryParse(cellValue.ToString(), out double val))
                    {
                        list.Add(val);
                    }
                }
            }
            return list;
        }

        private void SetupGrid(int desiredDataColumns)
        {
            _dataGridView.Columns.Clear();

            // Header Column setup
            DataGridViewTextBoxColumn itemColumn = new DataGridViewTextBoxColumn
            {
                Name = "ItemHeader",
                HeaderText = "",
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            itemColumn.DefaultCellStyle.Font = new Font(_dataGridView.Font, FontStyle.Bold);
            itemColumn.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            _dataGridView.Columns.Add(itemColumn);

            // Data Columns setup
            for (int i = 0; i < desiredDataColumns; i++)
            {
                char columnLetter = (char)('A' + i);
                _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = $"Col{columnLetter}",
                    HeaderText = columnLetter.ToString(),
                    Width = 40,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                });
            }

            string[] rowTitles = { "Score 1", "Score 2", "Rank 1", "Rank 2", "d", "d²" };
            for (int r = 0; r < rowTitles.Length; r++)
            {
                int rowIndex = _dataGridView.Rows.Add();
                _dataGridView.Rows[rowIndex].Cells[0].Value = rowTitles[r];

                if (r > 1) // Calculated rows are read-only
                {
                    _dataGridView.Rows[rowIndex].ReadOnly = true;
                    _dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        protected override void btnBack_Click(object sender, EventArgs e)
        {
            if (FindForm() is MainForm mainForm)
            {
                mainForm.LoadView(new StatisticsHub());
            }
        }
    }
}