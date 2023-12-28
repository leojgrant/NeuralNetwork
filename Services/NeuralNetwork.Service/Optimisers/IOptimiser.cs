namespace NeuralNetwork.Service.Optimisers;

public interface IOptimiser
{
    public double LearningRate { get; set; }
    public double UpdateWeight(double w, double dL_dW);
}
