namespace Emotex.MachineLearning
{
    public class SentimentResult
    {
        public SentimentPolarity Polarity { get; set; }
        public double PositiveProbability { get; set; }
        public double NegativeProbability { get; set; }
        public double PositiveScore { get; set; }
        public double NegativeScore { get; set; }
    }
}
