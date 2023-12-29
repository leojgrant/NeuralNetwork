using NeuralNetwork.Service.SynapseCollections;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Layers;

namespace NeuralNetwork.Service.NeuralNetworks;

public class SimpleNeuralNetwork : ISimpleNeuralNetwork
{
    public List<ILayer> Layers { get; set; }

    public List<ISynapseCollection> SynapseCollections {  get; set; }

    public ILossFunction LossFunction { get; set; }

    public List<double> Predictions { get; set; }

    public List<double> Targets { get; set; }

    public SimpleNeuralNetwork(List<double> layers, ILossFunction lossFunction, IOptimiser optimiser, INeuron neuronTemplate) 
    {
        this.InitLayers(neuronTemplate, layers);
        this.InitSynapseCollections(optimiser);
        this.LossFunction = lossFunction;
        this.Predictions = new List<double>();
        this.Targets = new List<double>();
    }

    public void ForwardPropagate(List<double> inputs)
    {
        UpdateInputNeuronsZ(inputs);
        for (var i = 0; i < this.SynapseCollections.Count; i++)
        {
            this.SynapseCollections[i].ForwardPropagateInput();
        }
        this.Predictions.Clear();
        foreach (INeuron neuron in this.Layers[this.Layers.Count - 1].Neurons)
        {
            this.Predictions.Add(neuron.h);
        }
    }

    public void BackPropagate()
    {
        this.UpdateOutputNeurons_dL_dh();
        for(var i = this.SynapseCollections.Count - 1; i >= 0; i--)
        { 
            this.SynapseCollections[i].UpdateWeights();
        }
    }

    private void UpdateInputNeuronsZ(List<double> inputs)
    {
        List<INeuron> inputNeurons = this.Layers[0].Neurons;
        for (int i = 0; i < inputNeurons.Count; i++)
        {
            inputNeurons[i].Z = inputs[i];
        }
    }

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

    public void SetTargets(List<double> targets)
    {
        this.Targets = targets;
    }

    private void InitLayers(INeuron neuronTemplate, List<double> layers)
    {
        this.Layers = new List<ILayer>();
        for (int i = 0; i < layers.Count; i++)
        {
            this.Layers.Add(new Layer(neuronTemplate, layers[i]));
        }
    }

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



