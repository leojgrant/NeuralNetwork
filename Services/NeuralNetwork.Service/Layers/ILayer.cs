using NeuralNetwork.Service.Neurons;

namespace NeuralNetwork.Service.Layers;

public interface ILayer
{
    public List<INeuron> Neurons { get; set; }
}
