using NeuralNetwork.Service.Layers;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Synapses;

namespace NeuralNetwork.Service.SynapseCollections;

/// <summary>
///  A collection of synapses found between two layers of the neural network.
/// </summary>
public class SynapseCollection : ISynapseCollection
{
    /// <summary>
    /// The synapses found between two layers of the neural network.
    /// </summary>
    public List<ISynapse> Synapses { get; set; }

    /// <summary>
    /// The layer of neurons making up the input neurons to the synapses in the synapse collection.
    /// </summary>
    public ILayer InputLayer { get; set; }

    /// <summary>
    /// The layer of neurons making up the output neurons to the synapses in the synapse collection.
    /// </summary>
    public ILayer OutputLayer { get; set; }

    /// <summary>
    /// The constructor method of a synapse collection.
    /// </summary>
    /// <param name="inputLayer">The layer of neurons making up the input neurons to the synapses in the synapse collection.</param>
    /// <param name="outputLayer">The layer of neurons making up the output neurons to the synapses in the synapse collection.</param>
    /// <param name="optimiser">The optimiser used by the synapses of the synapse collection.</param>
    public SynapseCollection(ILayer inputLayer, ILayer outputLayer, IOptimiser optimiser) 
    {
        this.InputLayer = inputLayer;
        this.OutputLayer = outputLayer;
        this.InitSynapses(inputLayer.Neurons, outputLayer.Neurons, optimiser);
    }

    /// <summary>
    /// Push the output signal of the input neurons to the synapse, out through the output neurons of the synapse.
    /// </summary>
    public void ForwardPropagateSynapseCollection()
    {
        foreach(INeuron neuron in this.OutputLayer.Neurons)
        {
            neuron.Z = 0;
            foreach(ISynapse synapse in this.Synapses.Where(synapse => synapse.OutputNeuron == neuron)){
                neuron.Z += synapse.Weight * synapse.InputNeuron.h;
            }

            neuron.h = neuron.ActivationFunction.Calculate_h(neuron.Z);
        }
    }

    /// <summary>
    /// Optimise the weights of the synapses in the synapse collection and update the gradient dL_dh values of the input neurons to those synapses.
    /// </summary>
    public void BackPropagateSynapseCollection()
    {
        OptimiseWeights();
        RefreshInputNeurons_dL_dh();
    }

    /// <summary>
    /// Initialise the synapses that make up the synapse collection.
    /// </summary>
    /// <param name="inputLayer">The layer of neurons making up the input neurons to the synapses in the synapse collection.</param>
    /// <param name="outputLayer">The layer of neurons making up the output neurons to the synapses in the synapse collection.</param>
    /// <param name="optimiser">The optimiser used by the synapses of the synapse collection.</param>
    private void InitSynapses(List<INeuron> inputNeurons, List<INeuron> outputNeurons, IOptimiser optimiser)
    {
        this.Synapses = new List<ISynapse>();
        foreach(INeuron inputNeuron in inputNeurons)
        {
            foreach (INeuron outputNeuron in outputNeurons)
            {
                this.Synapses.Add(new Synapse(inputNeuron, outputNeuron, optimiser));
            }
        }
    }

    /// <summary>
    /// Optimise the weights on the synapses in the synapse collection.
    /// </summary>
    private void OptimiseWeights()
    {
        foreach (ISynapse synapse in this.Synapses)
        {
            synapse.BackPropagateSynapse(synapse.OutputNeuron.dL_dh);
        }
    }

    /// <summary>
    /// Refresh the dL_dh value on the input neurons to the synapses in the synapse collection.
    /// </summary>
    private void RefreshInputNeurons_dL_dh()
    {
        foreach (INeuron neuron in this.InputLayer.Neurons)
        {
            neuron.dL_dh = 0;
            foreach (ISynapse synapse in this.Synapses.Where(synapse => synapse.InputNeuron == neuron))
            {
                neuron.dL_dh += synapse.dL_dhi;
            }
        }
    }
}
