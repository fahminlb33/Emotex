using System;
using System.Diagnostics;
using System.Text;

namespace Emotex.MachineLearning
{
    public class TrainingResult : IExecutionRecorder<TrainingResult.RecordType>
    {
        public enum RecordType
        {
            LoadDataset,
            Tokenization,
            BagOfWordsLearning,
            Featurization,
            NaiveBayesLearning
        }

        private RecordType _recordType;
        private Stopwatch _stopwatch;

        public long LoadDataset { get; set; }
        public long Tokenization { get; set; }
        public long BagOfWordsLearning { get; set; }
        public long Featurization { get; set; }
        public long NaiveBayesLearning { get; set; }

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
                case RecordType.BagOfWordsLearning:
                    BagOfWordsLearning = _stopwatch.ElapsedMilliseconds;
                    break;
                case RecordType.Featurization:
                    Featurization = _stopwatch.ElapsedMilliseconds;
                    break;
                case RecordType.NaiveBayesLearning:
                    NaiveBayesLearning = _stopwatch.ElapsedMilliseconds;
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
            sb.AppendLine($"Bag of Words Learning: {BagOfWordsLearning} ms");
            sb.AppendLine($"Featurization: {Featurization} ms");
            sb.AppendLine($"Naive Bayes Learning: {NaiveBayesLearning} ms");

            return sb.ToString();
        }
    }
}
