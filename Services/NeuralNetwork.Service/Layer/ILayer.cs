
using NeuralNetwork.Service.Synapse;

namespace NeuralNetwork.Service.Layer;

public interface ILayer
{
    public IEnumerable<ISynapse> Synapses { get; set; }
}
