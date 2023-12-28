namespace NeuralNetwork.Service.Optimisers;

public interface IOptimiser
{
    public double learningRate { get; set; }
    public double UpdateWeight(double w, double dL_dW);
}
