
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Synapses;

namespace NeuralNetwork.Service.SynapseCollections;

public interface ISynapseCollection
{
    public List<ISynapse> Synapses { get; set; }

    public void ForwardPropagateInput();

    public void UpdateWeights();
}
