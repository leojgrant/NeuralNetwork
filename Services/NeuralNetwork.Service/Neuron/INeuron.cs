using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.Neurons;

/// <summary>
/// The interface for a neuron.
/// </summary>
public interface INeuron
{
    /// <summary>
    /// The bias of a neuron.
    /// </summary>
    public double Bias { get; set; }

    /// <summary>
    /// The activation function applied to the signal (Z) in the neuron.
    /// </summary>
    public IActivationFunction ActivationFunction { get; set; }

    /// <summary>
    /// The sum of the signals entering the neuron and the bias of the neuron during a run of forward propagation.
    /// </summary>
    public double Z {  get; set; }

    /// <summary>
    /// The output of the neuron (after Z is transformed by the activation function) during a run of forward propagation..
    /// </summary>
    public double h { get; set; }

    /// <summary>
    /// The loss gradient of the neuron output h during the most recent run of back propagation.
    /// </summary>
    public double dL_dh { get; set; }
}
