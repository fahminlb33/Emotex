using System;
using System.Diagnostics;
using System.Linq;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Statistics.Analysis;

namespace Emotex.MachineLearning
{
    public class SentimentAnalyzer
    {
        private BagOfWords _bagOfWords;
        private NaiveBayes _bayes;
        private readonly TextPreprocessor _preprocessor;
        private readonly ModelStore _store;

        public SentimentAnalyzer(TextPreprocessor preprocessor, ModelStore store)
        {
            _preprocessor = preprocessor;
            _store = store;
        }

        public SentimentResult Predict(string sentiment)
        {
            var result = new SentimentResult();
            var tokenized = _preprocessor.Process(sentiment);
            var featurized = _bagOfWords.Transform(tokenized).ToInt32();

            var scores = _bayes.Scores(featurized);
            var prob = _bayes.Probabilities(featurized);
            result.Polarity = (SentimentPolarity) _bayes.Decide(featurized);
            result.NegativeScore = scores[0];
            result.PositiveScore = scores[1];
            result.NegativeProbability = prob[0];
            result.PositiveProbability = prob[1];

            return result;
        }

        public TrainingResult Train()
        {
            var result = new TrainingResult();

            // load training data
            result.StartMeasure(TrainingResult.RecordType.LoadDataset);
            var reader = new ExcelReader(_store.GetFilePath(ModelFileType.Dataset));
            var dataStore = reader.GetWorksheet("Training");

            int[] labels = dataStore.ToVector<int>("Label");
            string[] learnData = dataStore.ToVector<string>("Sentiment");
            result.StopMeasure();

            // tokenize
            result.StartMeasure(TrainingResult.RecordType.Tokenization);
            string[][] tokenized = learnData.Select(x => _preprocessor.Process(x)).ToArray();
            result.StopMeasure();

            // train bag of words
            result.StartMeasure(TrainingResult.RecordType.BagOfWordsLearning);
            _bagOfWords = new BagOfWords();
            _bagOfWords.Learn(tokenized);
            result.StopMeasure();

            // vectorization of tokens
            result.StartMeasure(TrainingResult.RecordType.Featurization);
            var featurized = _bagOfWords.Transform(tokenized).ToInt32();
            result.StopMeasure();

            // train
            result.StartMeasure(TrainingResult.RecordType.NaiveBayesLearning);
            var teacher = new NaiveBayesLearning();
            _bayes = teacher.Learn(featurized, labels);
            result.StopMeasure();

            return result;
        }

        public BenchmarkResult Benchmark()
        {
            var result = new BenchmarkResult();

            // load evaluation data
            result.StartMeasure(BenchmarkResult.RecordType.LoadDataset);
            var reader = new ExcelReader(_store.GetFilePath(ModelFileType.Dataset));
            var dataStore = reader.GetWorksheet("Evaluation");

            int[] labels = dataStore.ToVector<int>("Label");
            string[] learnData = dataStore.ToVector<string>("Sentiment");
            result.StopMeasure();

            // tokenize
            result.StartMeasure(BenchmarkResult.RecordType.Tokenization);
            string[][] tokenized = learnData.Select(x => _preprocessor.Process(x)).ToArray();
            result.StopMeasure();

            // benchmark featurization
            result.StartMeasure(BenchmarkResult.RecordType.Featurization);
            var xTestTokenized = _bagOfWords.Transform(tokenized).ToInt32();
            result.StopMeasure();

            // benchmark classification
            result.StartMeasure(BenchmarkResult.RecordType.Classification);
            var testResult = _bayes.Decide(xTestTokenized);
            result.StopMeasure();

            // calculate stats
            result.StartMeasure(BenchmarkResult.RecordType.Statistics);
            var mat = new ConfusionMatrix(testResult, labels);
            var roc = new ReceiverOperatingCharacteristic(labels, testResult.ToDouble());
            roc.Compute(200);
            result.StopMeasure();

            // save metrics
            result.Matrix = mat;
            result.Roc = roc;

            return result;
        }
    }
}
