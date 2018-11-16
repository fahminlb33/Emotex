using System;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.Text.Stemmers;
using Accord.Math;

namespace Emotex.StemmerText
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new ExcelReader("TrainingData.xls");
            var sheet = reader.GetWorksheet("Training").ToVector<string>("Sentiment");
            var tokeinzed = sheet.Tokenize();
            var stemmer = new EnglishStemmer();
            var i = 0;

            Console.WriteLine("Loading...");
            foreach (string[] strings in tokeinzed)
            {
                foreach (string word in strings)
                {
                    Console.WriteLine($"{word} - {stemmer.Stem(word)}  ");
                }

                Console.WriteLine();
                Console.WriteLine();
                i++;

                if (i == 10)
                {
                    break;
                }
            }
            Console.Read();
        }
    }
}
