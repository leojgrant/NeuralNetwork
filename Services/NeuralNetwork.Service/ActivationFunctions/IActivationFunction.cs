namespace NeuralNetwork.Service.Activation_Functions;

/// <summary>
/// The interface for activation functions used by neurons.
/// </summary>
public interface IActivationFunction
{
    /// <summary>
    /// The activation function used during forward propagation.
    /// </summary>
    /// <param name="Z">The sum of the signals entering the neuron and the bias.</param>
    /// <returns>The signal input transformed by the activation function and outputted by the neuron.</returns>
    public double Calculate_h(double Z);

    /// <summary>
    /// Calculate dh_dZ at the neuron, used for back propagation.
    /// </summary>
    /// <param name="h">The output signal leaving the neuron during the most recent forward propagation.</param>
    /// <returns>The gradient dh_dZ (used for back propagation).</returns>
    public double Calculate_dh_dZ(double h);
}
