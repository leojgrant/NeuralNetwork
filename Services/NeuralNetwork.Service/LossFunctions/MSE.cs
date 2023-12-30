namespace NeuralNetwork.Service.LossFunctions;

/// <summary>
/// The mean squared error loss function.
/// </summary>
public class MSE : ILossFunction
{
    /// <summary>
    /// Calculate the loss/error from a predicted value and the target value of a neural network using the MSE function.
    /// </summary>
    /// <param name="target">The target value of the output neuron.</param>
    /// <param name="prediction">The actual output value of he output neuron.</param>
    /// <returns>The MSE of the prediction.</returns>
    public double CalculateLoss(double target, double prediction)
    {
        return 0.5 * Math.Pow((prediction - target), 2);
    }

    /// <summary>
    /// Calculate the loss gradient dL_dp (L=loss, p=prediction) having used the MSE function to calculate the error.
    /// </summary>
    /// <param name="target">The target value of the output neuron.</param>
    /// <param name="prediction">The actual output value of he output neuron.</param>
    /// <returns>The loss gradient dL_dp.</returns>
    public double Calculate_dL_dp(double target, double prediction)
    {
        //Console.WriteLine("Error:");
        //Console.WriteLine(prediction - target);
        return prediction - target;
    }
}
