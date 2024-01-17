namespace NeuralNetwork.Service.Optimisers;

/// <summary>
/// The interface for an optimiser.
/// </summary>
public interface IOptimiser
{
    /// <summary>
    /// The learning rate used by the optimiser.
    /// </summary>
    public double LearningRate { get; set; }

    /// <summary>
    /// Calculate a new updated weight value using the optimiser and the loss gradient of the synapse weight.
    /// </summary>
    /// <param name="weight">The weight of the synapse.</param>
    /// <param name="dL_dW">The loss gradient of the weight of the synapse.</param>
    /// <returns>An updated weight value (that should reduce the error at the output).</returns>
    public double CalculateImprovedWeight(double weight, double dL_dW);
}
