using System;

namespace Emotex.MachineLearning
{
    public interface IExecutionRecorder<T> where T : struct, IConvertible
    {
        void StartMeasure(T type);
        void StopMeasure();
        string GetDescription();
    }
}
