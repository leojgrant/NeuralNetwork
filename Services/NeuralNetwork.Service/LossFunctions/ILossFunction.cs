namespace NeuralNetwork.Service.LossFunctions;

/// <summary>
/// The interface for a loss function used by a neural network to calculate the error in its predictions.
/// </summary>
public interface ILossFunction
{
    /// <summary>
    /// Calculate the loss/error from a predicted value and the target value of a neural network.
    /// </summary>
    /// <param name="target">The target value of the output neuron.</param>
    /// <param name="prediction">The actual output value of he output neuron.</param>
    /// <returns>The loss/error of the prediction w.r.t the target value.</returns>
    public double CalculateLoss(double target, double prediction);

    /// <summary>
    /// Calculate the loss gradient dL_dp (L=loss, p=prediction).
    /// </summary>
    /// <param name="target">The target value of the output neuron.</param>
    /// <param name="prediction">The actual output value of he output neuron.</param>
    /// <returns>The loss gradient dL_dp.</returns>
    public double Calculate_dL_dp(double target, double prediction);
}
