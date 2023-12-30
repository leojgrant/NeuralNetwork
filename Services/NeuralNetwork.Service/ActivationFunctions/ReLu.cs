using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.ActivationFunctions;

/// <summary>
/// The ReLu activation function.
/// </summary>
public class ReLu : IActivationFunction
{
    /// <summary>
    /// Apply the ReLu function to a signal input.
    /// </summary>
    /// <param name="Z">The sum of the signals entering the neuron and the bias.</param>
    /// <returns>The signal input transformed by the ReLu function and outputted by the neuron (h).</returns>
    public double Calculate_h(double Z)
    {
        if (Z > 0)
        {
            return Z;
        }
        return 0;
    }

    /// <summary>
    /// Calculate dh_dZ at the neuron for a ReLu function, used for back propagation.
    /// </summary>
    /// <param name="h">The output signal leaving the neuron during the most recent forward propagation.</param>
    /// <returns>The gradient dh_dZ (used for back propagation).</returns>
    public double Calculate_dh_dZ(double h)
    {
        if (h > 0)
        {
            return 1;
        }
        return 0;
    }
}
