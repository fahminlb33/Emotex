using System;
using System.IO;
using System.Reflection;

namespace Emotex.MachineLearning
{
    public class ModelStore
    {
        public string WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Path.Combine(Path.GetTempPath(), "emotex");

        public string GetFilePath(ModelFileType type)
        {
            switch (type)
            {
                case ModelFileType.Dataset:
                    return Path.Combine(WorkingDirectory, "TrainingData.xls");
                    
                case ModelFileType.NaiveBayesClassifier:
                    return Path.Combine(WorkingDirectory, "bayes-model.tds");
                    
                case ModelFileType.BagOfWords:
                    return Path.Combine(WorkingDirectory, "bow-model.tds");

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void LoadModels(string path)
        {
            throw new NotImplementedException();
        }
    }
}
