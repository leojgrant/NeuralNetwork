using NeuralNetwork.Service.Layers;
using NeuralNetwork.Service.SynapseCollections;

namespace NeuralNetwork.Service.NeuralNetworks;

public interface ISimpleNeuralNetwork
{
    public List<ILayer> Layers { get; set; }

    public List<double> Predictions { get; set; }

    public List<double> Targets { get; set; }

    public List<ISynapseCollection> SynapseCollections { get; set; }

    public void ForwardPropagate(List<double> inputs);

    public void BackPropagate();
}
