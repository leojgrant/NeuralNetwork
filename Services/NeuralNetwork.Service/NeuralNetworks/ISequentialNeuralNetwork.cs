using NeuralNetwork.Service.Layers;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.SynapseCollections;

namespace NeuralNetwork.Service.NeuralNetworks;

/// <summary>
/// The interface for a sequential neural network.
/// </summary>
public interface ISequentialNeuralNetwork
{
    /// <summary>
    /// The most recent predicted values of the neural network.
    /// </summary>
    public List<double> Predictions { get; set; }

    /// <summary>
    /// The target outputs of the neural network for the most recent input values.
    /// </summary>
    public List<double> Targets { get; set; }

    /// <summary>
    /// The layers making up the neural network.
    /// </summary>
    public List<ILayer> Layers { get; set; }

    /// <summary>
    /// The collections of synapses within the neural network.
    /// </summary>
    public List<ISynapseCollection> SynapseCollections { get; set; }

    /// <summary>
    /// The loss function to be used to calculate the error of the neural network.
    /// </summary>
    public ILossFunction LossFunction { get; set; }

    /// <summary>
    /// Produce an output for a given set of input values.
    /// </summary>
    /// <param name="inputs"></param>
    public void ForwardPropagate(List<double> inputs);

    /// <summary>
    /// Update the neural network based on the output values produced by the most recent ForwardPropagate(inputs) call, and the target values set on the Targets property.
    /// </summary>
    public void BackPropagate();
}
