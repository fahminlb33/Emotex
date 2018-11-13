using System;
using System.Diagnostics;
using System.Text;
using Accord.Statistics.Analysis;

namespace Emotex.MachineLearning
{
    public class BenchmarkResult : IExecutionRecorder<BenchmarkResult.RecordType>
    {
        public enum RecordType
        {
            LoadDataset,
            Tokenization,
            Featurization,
            Classification,
            Statistics
        }

        private RecordType _recordType;
        private Stopwatch _stopwatch;

        // timings
        public long LoadDataset { get; set; }
        public long Tokenization { get; set; }
        public long Featurization { get; set; }
        public long Classification { get; set; }
        public long Statistics { get; set; }

        // stats
        public ConfusionMatrix Matrix { get; set; }
        public ReceiverOperatingCharacteristic Roc { get; set; }


        public void StartMeasure(RecordType type)
        {
            _recordType = type;
            _stopwatch = Stopwatch.StartNew();
        }

        public void StopMeasure()
        {
            _stopwatch.Stop();
            switch (_recordType)
            {
                case RecordType.LoadDataset:
                    LoadDataset = _stopwatch.ElapsedMilliseconds;
                    break;
                case RecordType.Tokenization:
                    Tokenization = _stopwatch.ElapsedMilliseconds;
                    break;
                case RecordType.Featurization:
                    Featurization = _stopwatch.ElapsedMilliseconds;
                    break;
                case RecordType.Classification:
                    Classification = _stopwatch.ElapsedMilliseconds;
                    break;
                case RecordType.Statistics:
                    Statistics = _stopwatch.ElapsedMilliseconds;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" == Timings ==");
            sb.AppendLine($"Load dataset: {LoadDataset} ms");
            sb.AppendLine($"Tokenization: {Tokenization} ms");
            sb.AppendLine($"Featurization: {Featurization} ms");
            sb.AppendLine($"Classification: {Classification} ms");
            sb.AppendLine($"Analysis: {Statistics} ms");
            sb.AppendLine();
            sb.AppendLine(" == Statistics ==");
            sb.AppendLine($"Accuracy: {Matrix.Accuracy:P02}");
            sb.AppendLine($"Sensitivity: {Matrix.Sensitivity:P02}");
            sb.AppendLine($"F1-Score: {Matrix.FScore:P02}");
            sb.AppendLine($"ChiSquare: {Matrix.ChiSquare}");
            sb.AppendLine($"AUC: {Roc.Area:P02}");

            return sb.ToString();
        }
    }
}
