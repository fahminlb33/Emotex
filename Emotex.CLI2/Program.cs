extern alias lib;
using System;
using System.Linq;
using System.Text;
using Accord.Controls;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.MachineLearning.VectorMachines;
using Accord.Math;
using Accord.Statistics;
using Accord.Statistics.Analysis;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Filters;
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Visualizations;
using Emotex.MachineLearning;
using lib::Accord.MachineLearning.Text.Stemmers;


namespace Emotex.CLI2
{
    class Program
    {
        static void Main(string[] args)
        {
            var stemmer = new IndonesianStemmer();
            var text = "cobalah mulai dengan berenang".Tokenize();
            var sb = new StringBuilder();
            foreach (string s in text)
            {
                sb.Append(stemmer.Stem(s) + " ");
            }
            
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }

        private static void Train2()
        {
            var stemmer = new EnglishStemmer();
            var reader = new ExcelReader("TrainingData.xls");
            var dataStore = reader.GetWorksheet("Data3");

            // read sentiments
            var x = dataStore.ToVector<string>("Sentiment");
            var y = dataStore.ToVector("Label").ToInt32();

            // create bags
            var xTokenized = x.Tokenize();
            var bag = new BagOfWords();
            bag.Learn(xTokenized);
            var xLearn = bag.Transform(xTokenized).ToInt32();

            // learn
            var teacher = new NaiveBayesLearning();
            var model = teacher.Learn(xLearn, y);
            

            // calculate accuracy
            var testStore = reader.GetWorksheet("Data4");
            var xTest = testStore.ToVector<string>("Sentiment").Tokenize();
            var yTest = testStore.ToVector<int>("Label");

            // test by model
            var xTestTokenized = bag.Transform(xTest).ToInt32();
            var testResult = model.Decide(xTestTokenized);

            // calculate stats
            var mat = new ConfusionMatrix(testResult, yTest);
            var roc = new ReceiverOperatingCharacteristic(yTest, testResult.ToDouble());
            roc.Compute(200);

            Console.WriteLine("Accuracy: {0:P2}", mat.Accuracy);
            Console.WriteLine("Sensitivity: {0:P2}", mat.Sensitivity);
            Console.WriteLine("AUC: {0:P2}", roc.Area);
            Console.WriteLine("F-Score: {0:P2}", mat.FScore);
            Console.WriteLine("ChiSquare: " + mat.ChiSquare);

            var box = roc.GetScatterplot(true);
            ScatterplotBox.Show(box)
                .SetSymbolSize(0)
                .SetLinesVisible(true)
                .SetScaleTight(true)
                .WaitForClose();
            

            //// calc
            //// Check the performance of the classifier by comparing with the ground-truth:
            //var m1 = new GeneralConfusionMatrix(predicted: trainPredicted, expected: trainOutputs);
            //double trainAcc = m1.Accuracy; // should be 0.690


            //// Prepare the testing set
            //double[][][] testInputs = pendigits.Testing.Item1;
            //int[] testOutputs = pendigits.Testing.Item2;

            //// Apply the same normalizations
            //testInputs = testInputs.Apply(Accord.Statistics.Tools.ZScores);

            //double[][] testVectors = quantizer.Transform(testInputs);

            //// Compute predictions for the test set
            //int[] testPredicted = svm.Decide(testVectors);

            //// Check the performance of the classifier by comparing with the ground-truth:
            //var m2 = new GeneralConfusionMatrix(predicted: testPredicted, expected: testOutputs);
            //double testAcc = m2.Accuracy; // should be 0.600

            Console.Read();

            void Test(string text)
            {
                var test = bag.Transform(text.Tokenize()).ToInt32();
                var result = model.Decide(test);
                Console.WriteLine("Text  : " + text);
                Console.WriteLine("Result: " + result);
            }
        }
    }
}
