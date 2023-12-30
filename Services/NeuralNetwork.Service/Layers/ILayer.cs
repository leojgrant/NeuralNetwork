using NeuralNetwork.Service.Neurons;

namespace NeuralNetwork.Service.Layers;

/// <summary>
/// The interface for layers of a neural network.
/// </summary>
public interface ILayer
{
    /// <summary>
    /// A list of the neurons in the layer of the neural network.
    /// </summary>
    public List<INeuron> Neurons { get; set; }
}
