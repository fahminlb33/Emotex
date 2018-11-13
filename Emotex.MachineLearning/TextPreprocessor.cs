extern alias accord;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using accord::Accord.MachineLearning.Text.Stemmers;
using Accord.IO;
using Accord.MachineLearning;
using Accord.Math;

namespace Emotex.MachineLearning
{
    public class TextPreprocessor
    {
        private readonly StemmerBase _stemmer;

        public List<string> StopWords { get; set; }
        public bool StemWords { get; set; }
        public bool RemoveStopWords { get; set; }

        public TextPreprocessor(StemmerBase stemmer)
        {
            _stemmer = stemmer;
            StopWords = new List<string>();
        }

        /// <summary>
        /// Gets a cleaned string with stop words removed, stemmed, and tokenized.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string[] Process(string sentence)
        {
            var tokens = sentence.Tokenize();
            if (!RemoveStopWords && !StemWords) return tokens;

            var result = new List<string>();
            foreach (string token in tokens)
            {
                if (RemoveStopWords && StemWords)
                {
                    if (StopWords.All(stopWord => !string.Equals(token, stopWord, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        result.Add(_stemmer.Stem(token));
                    }
                }
                else if (!RemoveStopWords && StemWords)
                {
                    result.Add(_stemmer.Stem(token));
                }
                else if (RemoveStopWords && !StemWords)
                {
                    if (StopWords.All(stopWord => !string.Equals(token, stopWord, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        result.Add(token);
                    }
                }
            }

            return result.ToArray();
        }
        
        public void Load()
        {
            var reader = new ExcelReader(Helpers.DatasetPath);
            DataTable workseet = reader.GetWorksheet("Stopwords");
            StopWords = new List<string>(workseet.ToArray<string>("Word"));
        }
    }
}
