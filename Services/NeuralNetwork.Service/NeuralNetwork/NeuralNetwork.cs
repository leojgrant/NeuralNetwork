using NeuralNetwork.Service.Layer;

namespace NeuralNetwork.Service.NeuralNetwork;

public class NeuralNetwork
{
    public IEnumerable<ILayer> Layers {  get; set; }

    public double ForwardPropagate(IEnumerable<double> inputs)
    {
        return 1;
    }

    public bool BackPropagate(IEnumerable<double> loss)
    {
        return true;
    }
}
