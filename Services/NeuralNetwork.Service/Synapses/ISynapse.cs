using NeuralNetwork.Service.Neurons;

namespace NeuralNetwork.Service.Synapses;

/// <summary>
/// An interface representing a synapse.
/// </summary>
public interface ISynapse
{
    /// <summary>
    /// The weight applied to signals travelling across the synapse.
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// The dL_dhi value of the synapse ('hi' is the signal value leaving the input neuron of the synapse.
    /// </summary>
    public double dL_dhi { get; set; }

    /// <summary>
    /// The input neuron of the synapse.
    /// </summary>
    public INeuron InputNeuron { get; set; }

    /// <summary>
    /// The output neuron of the synapse.
    /// </summary>
    public INeuron OutputNeuron { get; set; }

    /// <summary>
    /// Back propagate the synapse.
    /// </summary>
    /// <param name="dL_dho">The dL_dh value of the output neuron.</param>
    public void BackPropagateSynapse(double dL_dho);
}
