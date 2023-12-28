namespace NeuralNetwork.Service.Optimisers;

internal class SGD : IOptimiser
{
    public double learningRate { get; set; }
    public double UpdateWeight(double w, double dL_dW)
    {
        return w - this.learningRate * dL_dW;
    }
}
