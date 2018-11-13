using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Runtime.Data;
using Microsoft.ML.Runtime.FastTree;
using Microsoft.ML.Runtime.Learners;

namespace Emotex.CLI
{
    public class SentimentIssue
    {
        public bool Label { get; set; }
        public string Text { get; set; }
    }

    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        [ColumnName("Probability")]
        public float Probability { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }
    }

    class Program
    {
        private static string AppPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private static string TrainDataPath => Path.Combine(AppPath, "datasets", "wikipedia-detox-250-line-data.tsv");
        private static string TestDataPath => Path.Combine(AppPath, "datasets", "wikipedia-detox-250-line-test.tsv");
        private static string ModelPath => Path.Combine(AppPath, "SentimentModel.zip");

        static void Main(string[] args)
        {
            //var tokenizer = new Tokenizer();
            //var lemmatizer = new Lemmatizer();
            //var raw = "Buka bersama beranugerah kucing gila";
            //Console.WriteLine("Original text: {0}", raw);
            //Console.WriteLine();

            //var tokens = tokenizer.Tokenize(raw);
            //foreach (var token in lemmatizer.Lemmatize(tokens))
            //{
            //    Console.WriteLine("Text: {0}\nType: {1}\nLemmatized:  {2}", token.RawText, token.Type, token.Lemmatized);
            //    Console.WriteLine();
            //}
            //Console.Read();

            PredictWithModelLoadedFromFile(new SentimentIssue { Text = "A very good movie" });
            PredictWithModelLoadedFromFile(new SentimentIssue { Text = "Amusing" });
            PredictWithModelLoadedFromFile(new SentimentIssue { Text = "Cool effects!" });
            PredictWithModelLoadedFromFile(new SentimentIssue { Text = "The best movie!" });
            PredictWithModelLoadedFromFile(new SentimentIssue { Text = "NOTHING COMPARES TO THIS MASTERPIECE" });
            Console.ReadKey();
            //CreateAndTrain();
        }

        private static void CreateAndTrain()
        {
            //1. Create ML.NET context/environment
            using (var env = new LocalEnvironment())
            {
                //2. Create DataReader with data schema mapped to file's columns
                var textLoaderArguments = new TextLoader.Arguments
                {
                    Separator = "tab",
                    HasHeader = true,
                    Column = new[]
                    {
                        new TextLoader.Column("Label", DataKind.Bool, 0),
                        new TextLoader.Column("Text", DataKind.Text, 1)
                    }
                };
                var reader = new TextLoader(env, textLoaderArguments);

                //Load training data
                IDataView trainingDataView = reader.Read(new MultiFileSource(TrainDataPath));


                //3.Create a flexible pipeline (composed by a chain of estimators) for creating/traing the model.
                //var trainer = new FastTreeBinaryClassificationTrainer(env, "Label", "Features");
                var trainer = new LinearClassificationTrainer(env, new LinearClassificationTrainer.Arguments(), "Features", "Label");
                //Convert the text column to numeric vectors (Features column)   
                var pipeline = new TextTransform(env, "Text", "Features").Append(trainer);
                //.Append(new LinearClassificationTrainer(env, "Features", "Label")); //(Simpler in ML.NET v0.7)



                //4. Create and train the model            
                Console.WriteLine("=============== Create and Train the Model ===============");

                var model = pipeline.Fit(trainingDataView);

                Console.WriteLine("=============== End of training ===============");
                Console.WriteLine();


                //5. Evaluate the model and show accuracy stats

                //Load evaluation/test data
                IDataView testDataView = reader.Read(new MultiFileSource(TestDataPath));

                Console.WriteLine("=============== Evaluating Model's accuracy with Test data===============");
                var predictions = model.Transform(testDataView);

                var binClassificationCtx = new BinaryClassificationContext(env);
                var metrics = binClassificationCtx.Evaluate(predictions, "Label");

                Console.WriteLine();
                Console.WriteLine("Model quality metrics evaluation");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
                Console.WriteLine($"Auc: {metrics.Auc:P2}");
                Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
                Console.WriteLine("=============== End of Model's evaluation ===============");
                Console.WriteLine();


                //6. Test Sentiment Prediction with one sample text 
                var predictionFunct = model.MakePredictionFunction<SentimentIssue, SentimentPrediction>(env);

                SentimentIssue sampleStatement = new SentimentIssue
                {
                    Text = "Very good movie"
                };

                var resultprediction = predictionFunct.Predict(sampleStatement);

                Console.WriteLine();
                Console.WriteLine("=============== Test of model with a sample ===============");

                Console.WriteLine($"Text: {sampleStatement.Text} | Prediction: {(Convert.ToBoolean(resultprediction.Prediction) ? "Toxic" : "Nice")} sentiment | Probability: {resultprediction.Probability} ");

                // Save model to .ZIP file
                SaveModelAsFile(env, model);

                // Predict again but now testing the model loading from the .ZIP file
                PredictWithModelLoadedFromFile(sampleStatement);

                Console.WriteLine("=============== End of process, hit any key to finish ===============");
                Console.ReadKey();
            }
        }

        private static void SaveModelAsFile(LocalEnvironment env, TransformerChain<BinaryPredictionTransformer<Microsoft.ML.Runtime.Internal.Internallearn.IPredictorWithFeatureWeights<float>>> model)
        {
            using (var fs = new FileStream(ModelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
                model.SaveTo(env, fs);

            Console.WriteLine("The model is saved to {0}", ModelPath);
        }

        private static void PredictWithModelLoadedFromFile(SentimentIssue sampleStatement)
        {
            // Test with Loaded Model from .zip file

            using (var env2 = new LocalEnvironment())
            {
                ITransformer loadedModel;
                using (var stream = new FileStream(ModelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    loadedModel = TransformerChain.LoadFrom(env2, stream);
                }

                // Create prediction engine and make prediction.

                var engine = loadedModel.MakePredictionFunction<SentimentIssue, SentimentPrediction>(env2);

                var predictionFromLoaded = engine.Predict(sampleStatement);
                
                Console.WriteLine();
                Console.WriteLine("=============== Test of model with a sample ===============");

                Console.WriteLine($"Text: {sampleStatement.Text} | Prediction: {(Convert.ToBoolean(predictionFromLoaded.Prediction) ? "Toxic" : "Nice")} sentiment | Probability: {predictionFromLoaded.Probability} ");

            }
        }
    }
}
