namespace Emotex
{
    public class SentimentLog
    {
        public string Sentiment { get; set; }
        public string Polarity { get; set; }
        public double PositiveProbability { get; set; }
        public double NegativeProbability { get; set; }
        public double PositiveScore { get; set; }
        public double NegativeScore { get; set; }
    }
}
