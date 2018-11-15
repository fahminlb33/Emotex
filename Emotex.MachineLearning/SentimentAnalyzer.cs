using System.Data;
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

        public SentimentAnalyzer(TextPreprocessor preprocessor)
        {
            _preprocessor = preprocessor;
        }

        public SentimentResult Predict(string sentiment)
        {
            var result = new SentimentResult();
            var tokenized = _preprocessor.Process(sentiment);
            var featurized = _bagOfWords.Transform(tokenized).ToInt32();

            var scores = _bayes.Scores(featurized);
            var prob = _bayes.Probabilities(featurized);
            result.Polarity = _bayes.Decide(featurized) == 0 ? Polarity.Negative : Polarity.Positive;
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
            var reader = new ExcelReader(Helpers.DatasetPath);
            DataTable dataStore = reader.GetWorksheet("Training");

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
            int[][] featurized = _bagOfWords.Transform(tokenized).ToInt32();
            result.StopMeasure();

            // train
            result.StartMeasure(TrainingResult.RecordType.NaiveBayesLearning);
            var teacher = new NaiveBayesLearning();
            _bayes = teacher.Learn(featurized, labels);
            result.StopMeasure();

            return result;
        }

        public EvaluationResult Evaluate()
        {
            var result = new EvaluationResult();

            // load evaluation data
            result.StartMeasure(EvaluationResult.RecordType.LoadDataset);
            var reader = new ExcelReader(Helpers.DatasetPath);
            DataTable dataStore = reader.GetWorksheet("Evaluation");

            int[] labels = dataStore.ToVector<int>("Label");
            string[] learnData = dataStore.ToVector<string>("Sentiment");
            result.StopMeasure();

            // tokenize
            result.StartMeasure(EvaluationResult.RecordType.Tokenization);
            string[][] tokenized = learnData.Select(x => _preprocessor.Process(x)).ToArray();
            result.StopMeasure();

            // benchmark featurization
            result.StartMeasure(EvaluationResult.RecordType.Featurization);
            int[][] learnTokenized = _bagOfWords.Transform(tokenized).ToInt32();
            result.StopMeasure();

            // benchmark classification
            result.StartMeasure(EvaluationResult.RecordType.Classification);
            int[] testResult = _bayes.Decide(learnTokenized);
            result.StopMeasure();

            // calculate stats
            result.StartMeasure(EvaluationResult.RecordType.Statistics);
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
