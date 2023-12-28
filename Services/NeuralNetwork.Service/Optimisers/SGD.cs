namespace NeuralNetwork.Service.Optimisers;

public class SGD : IOptimiser
{
    public double LearningRate { get; set; }

    public SGD(double learningRate)
    {
        this.LearningRate = learningRate;
    }
    public double CalculateImprovedWeight(double weight, double dL_dW)
    {
        return weight - this.LearningRate * dL_dW;
    }
}
