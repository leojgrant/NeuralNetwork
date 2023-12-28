namespace NeuralNetwork.Service.Optimisers;

public interface IOptimiser
{
    public double LearningRate { get; set; }
    public double CalculateImprovedWeight(double w, double dL_dW);
}
