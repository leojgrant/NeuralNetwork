using NeuralNetwork.Service.Layer;

namespace NeuralNetwork.Service.NeuralNetwork;

public interface INeuralNetwork
{
    public IEnumerable<ILayer> Layers { get; set; }

    public double ForwardPropagate(IEnumerable<double> inputs);

    public bool BackPropagate();
}
