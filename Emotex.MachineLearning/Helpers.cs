using System.IO;
using System.Reflection;

namespace Emotex.MachineLearning
{
    internal class Helpers
    {
        public static string WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string DatasetPath = Path.Combine(WorkingDirectory, "TrainingData");
    }
}
