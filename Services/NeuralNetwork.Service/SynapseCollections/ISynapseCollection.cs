using NeuralNetwork.Service.Synapses;

namespace NeuralNetwork.Service.SynapseCollections;

/// <summary>
/// An interface representing the collection of synapses found between two layers of the neural network.
/// </summary>
public interface ISynapseCollection
{
    /// <summary>
    /// The synapses found between two layers of the neural network.
    /// </summary>
    public List<ISynapse> Synapses { get; set; }

    /// <summary>
    /// Push the output signal of the input neurons to the synapse, out through the output neurons of the synapse.
    /// </summary>
    public void ForwardPropagateSynapseCollection();

    /// <summary>
    /// Optimise the weights of the synapses in the synapse collection and update the gradient dL_dh values of the input neurons to those synapses.
    /// </summary>
    public void BackPropagateSynapseCollection();
}
