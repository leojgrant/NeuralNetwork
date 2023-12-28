using NeuralNetwork.Service.Layers;
using NeuralNetwork.Service.SynapseCollections;

namespace NeuralNetwork.Service.NeuralNetworks;

public interface ISimpleNeuralNetwork
{
    public List<ILayer> Layers { get; set; }

    public List<ISynapseCollection> SynapseCollections { get; set; }

    public double ForwardPropagate(List<double> inputs);

    public void BackPropagate();
}
