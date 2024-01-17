namespace NeuralNetwork.Service.Optimisers;

/// <summary>
/// The stochastic gradient descent optimiser.
/// </summary>
public class SGD : IOptimiser
{
    /// <summary>
    /// The learning rate of the optimiser.
    /// </summary>
    public double LearningRate { get; set; }

    /// <summary>
    /// The constructor method of the SGD optimiser.
    /// </summary>
    /// <param name="learningRate">The learning rate of the optimiser.</param>
    public SGD(double learningRate)
    {
        this.LearningRate = learningRate;
    }

    /// <summary>
    /// Calculate a new updated weight value using the SGD optimiser and the loss gradient of the synapse weight.
    /// </summary>
    /// <param name="weight">The weight of the synapse.</param>
    /// <param name="dL_dW">The loss gradient of the weight of the synapse.</param>
    /// <returns>An updated weight value (that should reduce the error at the output).</returns>
    public double CalculateImprovedWeight(double weight, double dL_dW)
    {
        return weight - this.LearningRate * dL_dW;
    }
}
