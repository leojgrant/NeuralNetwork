using NeuralNetwork.Service.Layers;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Synapses;

namespace NeuralNetwork.Service.SynapseCollections;

public class SynapseCollection : ISynapseCollection
{
    public List<ISynapse> Synapses { get; set; }

    public ILayer InputLayer { get; set; }

    public ILayer OutputLayer { get; set; }

    public SynapseCollection(ILayer inputLayer, ILayer outputLayer, IOptimiser optimiser) 
    {
        this.InputLayer = inputLayer;
        this.OutputLayer = outputLayer;

        this.InitSynapses(inputLayer.Neurons, outputLayer.Neurons, optimiser);
    }

    public void ForwardPropagateInput()
    {
        // for neurons in input layer - update h
        foreach(INeuron neuron in this.InputLayer.Neurons)
        {
            neuron.h = neuron.ActivationFunction.Calculate_h(neuron.Z);
        }

        // for neurons in output layer - update z
        foreach(INeuron neuron in this.OutputLayer.Neurons)
        {
            neuron.Z = 0;
            foreach(ISynapse synapse in this.Synapses.Where(synapse => synapse.OutputNeuron == neuron)){
                neuron.Z += synapse.Weight * synapse.InputNeuron.h;
                //Console.WriteLine(neuron.Z);
            }

            // for neurons in output layer - update h
            neuron.h = neuron.ActivationFunction.Calculate_h(neuron.Z);
        }
        //Console.WriteLine(this.OutputLayer.Neurons[0].h);
    }

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

    public void UpdateWeights()
    {
        foreach(ISynapse synapse in this.Synapses)
        {
            synapse.UpdateWeight(synapse.OutputNeuron.dL_dh);
        }
        UpdateInputNeurons_dL_dh();
    }

    private void UpdateInputNeurons_dL_dh()
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
