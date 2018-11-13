using Emotex.MachineLearning;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Controls;
using Accord.MachineLearning.Text.Stemmers;
using Accord.Statistics.Visualizations;
// ReSharper disable LocalizableElement

namespace Emotex
{
    public partial class MainForm : Form
    {
        private readonly TextPreprocessor _preprocessor;
        private readonly SentimentAnalyzer _analyzer;
        private readonly SortableBindingList<SentimentLog> _logs;
        private Scatterplot _scatterplot;

        private enum DisplayPart
        {
            Status,
            Statistics,
        }

        public MainForm()
        {
            InitializeComponent();

            var store = new ModelStore();
            _preprocessor = new TextPreprocessor(store, new EnglishStemmer());
            _analyzer = new SentimentAnalyzer(_preprocessor, store);
            _logs = new SortableBindingList<SentimentLog>();

            Helpers.ApplyStyle(ref dgvLogs);
            dgvLogs.DataSource = _logs;
        }

        private void UpdateStatus(string status, DisplayPart part)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, DisplayPart>(UpdateStatus), status, part);
            }
            else
            {
                if (part == DisplayPart.Status)
                {
                    lblStatus.Text = status;
                }
                else
                {
                    txtStats.Text = status;
                }
            }
        }
        
        private void cmdTrain_Click(object sender, EventArgs e)
        {
            UpdateStatus("TRAINING", DisplayPart.Status);
            _preprocessor.RemoveStopWords = chkStopWords.Checked;
            _preprocessor.StemWords = chkStemWords.Checked;
            Task.Run(() =>
            {
                _preprocessor.Load();
                TrainingResult result = _analyzer.Train();

                UpdateStatus(result.GetDescription(), DisplayPart.Statistics);
                UpdateStatus("TRAINED", DisplayPart.Status);
            });
        }

        private void cmdBenchmark_Click(object sender, EventArgs e)
        {
            UpdateStatus("EVALUATING", DisplayPart.Status);
            Task.Run(() =>
            {
                BenchmarkResult result = _analyzer.Benchmark();
                _scatterplot = result.Roc.GetScatterplot(true);

                UpdateStatus(result.GetDescription(), DisplayPart.Statistics);
                UpdateStatus("EVALUATED", DisplayPart.Status);
            });
        }

        private void cmdRocCurve_Click(object sender, EventArgs e)
        {
            if (_scatterplot != null)
            {
                ScatterplotBox.Show(_scatterplot)
                    .SetSymbolSize(0)
                    .SetLinesVisible(true)
                    .SetScaleTight(true)
                    .WaitForClose();
            }
            else
            {
                MessageBox.Show("Run benchmart first!");
            }
        }

        private void cmdCheck_Click(object sender, EventArgs e)
        {
            SentimentResult result = _analyzer.Predict(txtSentiment.Text);
            lblProbabilities.Text = string.Format("Negative: {0:P02},  Positive: {1:P02}", result.NegativeProbability, result.PositiveProbability);
            lblScores.Text = string.Format("Negative: {0:E2},  Positive: {1:E2}", result.NegativeScore,
                result.PositiveScore);
            if (result.Polarity == SentimentPolarity.Positive)
            {
                lblSentimentResult.Text = "Positive";
                lblSentimentResult.BackColor = Color.FromArgb(35, 168, 109);
            }
            else
            {
                lblSentimentResult.Text = "Negative";
                lblSentimentResult.BackColor = Color.FromArgb(168, 35, 35);
            }

            // add log
            var log = new SentimentLog
            {
                Sentiment = txtSentiment.Text,
                Polarity = result.Polarity.ToString(),
                NegativeProbability = Math.Round(result.NegativeProbability, 3),
                PositiveProbability = Math.Round(result.PositiveProbability,3),
                NegativeScore = Math.Round(result.NegativeScore,3),
                PositiveScore = Math.Round(result.PositiveScore,3)
            };
            _logs.Add(log);
            UpdateStatus("READY", DisplayPart.Status);
        }
    }
}
