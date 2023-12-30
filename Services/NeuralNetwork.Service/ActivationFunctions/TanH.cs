using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.ActivationFunctions;

/// <summary>
/// The TanH activation function.
/// </summary>
public class TanH : IActivationFunction
{
    /// <summary>
    /// Apply the TanH function to a signal input.
    /// </summary>
    /// <param name="Z">The sum of the signals entering the neuron and the bias.</param>
    /// <returns>The signal input transformed by the TanH function and outputted by the neuron (h).</returns>
    public double Calculate_h(double Z)
    {
        return 1 / (1 + Math.Exp(-1 * Z));
    }

    /// <summary>
    /// Calculate dh_dZ at the neuron for a TanH function, used for back propagation.
    /// </summary>
    /// <param name="h">The output signal leaving the neuron during the most recent forward propagation.</param>
    /// <returns>The gradient dh_dZ (used for back propagation).</returns>
    public double Calculate_dh_dZ(double h)
    {
        return h*(1-h);
    }
}
