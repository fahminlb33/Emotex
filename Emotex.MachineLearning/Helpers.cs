using System.IO;
using System.Reflection;

namespace Emotex.MachineLearning
{
    internal class Helpers
    {
        public static readonly string WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static readonly string DatasetPath = Path.Combine(WorkingDirectory, "TrainingData.xls");
    }
}
