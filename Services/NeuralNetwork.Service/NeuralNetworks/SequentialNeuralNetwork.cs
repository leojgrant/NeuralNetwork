using NeuralNetwork.Service.SynapseCollections;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Layers;

namespace NeuralNetwork.Service.NeuralNetworks;

/// <summary>
/// A sequential neural network.
/// </summary>
public class SequentialNeuralNetwork : ISequentialNeuralNetwork
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
    public List<ISynapseCollection> SynapseCollections {  get; set; }

    /// <summary>
    /// The loss function to be used to calculate the error of the neural network.
    /// </summary>
    public ILossFunction LossFunction { get; set; }

    /// <summary>
    /// The constructor method of the sequential neural network.
    /// </summary>
    /// <param name="layers">The number of neurons that make up each layer that make up the neural network (from input to output).</param>
    /// <param name="lossFunction">The loss function.</param>
    /// <param name="optimiser">The optimiser used by the synapses in the neural network to update themselves during back propagation.</param>
    /// <param name="neuronTemplate">The template of a neuron to be used to create all neurons in all layers of the neural network.</param>
    public SequentialNeuralNetwork(List<double> layers, ILossFunction lossFunction, IOptimiser optimiser, INeuron neuronTemplate) 
    {
        this.InitLayers(neuronTemplate, layers);
        this.InitSynapseCollections(optimiser);
        this.LossFunction = lossFunction;
        this.Predictions = new List<double>();
        this.Targets = new List<double>();
    }

    /// <summary>
    /// The forward propagation method of the neural network (pushes inputs through the network).
    /// </summary>
    /// <param name="inputs">The inputs fed into the neural network.</param>
    public void ForwardPropagate(List<double> inputs)
    {
        ForwardPropagateInputNeurons(inputs);
        for (var i = 0; i < this.SynapseCollections.Count; i++)
        {
            this.SynapseCollections[i].ForwardPropagateSynapseCollection();
        }
        this.Predictions.Clear();
        foreach (INeuron neuron in this.Layers[this.Layers.Count - 1].Neurons)
        {
            this.Predictions.Add(neuron.h);
        }
    }

    /// <summary>
    /// The back propagation method used to update the synapse weights and neuron biases.
    /// </summary>
    public void BackPropagate()
    {
        this.UpdateOutputNeurons_dL_dh();
        for(var i = this.SynapseCollections.Count - 1; i >= 0; i--)
        { 
            this.SynapseCollections[i].BackPropagateSynapseCollection();
        }
    }

    /// <summary>
    /// Push the inputs through the input layer.
    /// </summary>
    /// <param name="inputs"></param>
    private void ForwardPropagateInputNeurons(List<double> inputs)
    {
        List<INeuron> inputNeurons = this.Layers[0].Neurons;
        for (int i = 0; i < inputNeurons.Count; i++)
        {
            inputNeurons[i].Z = inputs[i];
        }

        foreach (INeuron neuron in this.Layers[0].Neurons)
        {
            neuron.h = neuron.ActivationFunction.Calculate_h(neuron.Z);
        }
    }

    /// <summary>
    /// Calculate and update the dL_dh gradient value of the output neurons.
    /// </summary>
    private void UpdateOutputNeurons_dL_dh()
    {
        int i = 0;
        List<INeuron> outputNeurons = this.Layers[this.Layers.Count - 1].Neurons;
        foreach (INeuron neuron in outputNeurons)
        {
            neuron.dL_dh = this.LossFunction.Calculate_dL_dp(this.Targets[i], this.Predictions[i]);
            i++;
        }
    }

    /// <summary>
    /// Initialise the layers of the neural network.
    /// </summary>
    /// <param name="neuronTemplate">The template of a neuron to be used to create all neurons in all layers of the neural network.</param>
    /// <param name="layers">The number of neurons that make up each layer that make up the neural network (from input to output).</param>
    private void InitLayers(INeuron neuronTemplate, List<double> layers)
    {
        this.Layers = new List<ILayer>();
        for (int i = 0; i < layers.Count; i++)
        {
            this.Layers.Add(new Layer(neuronTemplate, layers[i]));
        }
    }

    /// <summary>
    /// Initialise the synapses in the neural network.
    /// </summary>
    /// <param name="optimiser">The optimiser used by the synapses in the neural network to update themselves during back propagation.</param>
    private void InitSynapseCollections(IOptimiser optimiser)
    {
        // Check number of layers > 0 - throw error if not
        this.SynapseCollections = new List<ISynapseCollection>();
        for (int i = 0; i < this.Layers.Count - 1; i++)
        {
            this.SynapseCollections.Add(new SynapseCollection(this.Layers[i], this.Layers[i+1], optimiser));
        }
    }
}
