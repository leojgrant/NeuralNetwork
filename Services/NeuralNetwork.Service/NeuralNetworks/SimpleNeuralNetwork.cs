using NeuralNetwork.Service.SynapseCollections;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Synapses;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Layers;

namespace NeuralNetwork.Service.NeuralNetworks;

public class SimpleNeuralNetwork : ISimpleNeuralNetwork
{
    public List<ILayer> Layers { get; set; }

    public List<ISynapseCollection> SynapseCollections {  get; set; }

    public ILossFunction LossFunction { get; set; }

    public List<double> Predictions { get; set; }

    Dictionary<INeuron, double> dL_dp_Mapper {  get; set; }

    Dictionary<INeuron, double> TargetMapper { get; set; }

    public SimpleNeuralNetwork(List<double> layers, ILossFunction lossFunction, IOptimiser optimiser, INeuron neuronTemplate) 
    {
        this.InitLayers(neuronTemplate, layers);
        this.InitSynapseCollection(optimiser);
        this.LossFunction = lossFunction;
        this.Init_dL_dp_Mapper();
        this.Init_Targets();
    }

    public double ForwardPropagate(List<double> inputs)
    {
        this.Predictions = inputs;
        return 1;
    }

    public void BackPropagate()
    {
        this.Update_dL_dp_Mapper();

        bool isOutputLayer = true;
        for(var i = this.Layers.Count - 1; i > 0; i--)
        { 
            if (isOutputLayer)
            {
                this.SynapseCollections[this.SynapseCollections.Count - 1].UpdateWeights(this.dL_dp_Mapper);
                isOutputLayer = false;
                continue;
            } 

            this.SynapseCollections[i].UpdateWeights(SynapseCollections[i+1].dL_dh_Mapper);
        }
    }

    public void SetTargets(List<double> targets)
    {
        int i = 0;
        foreach (var (neuron, dL_dp) in this.TargetMapper)
        {
            this.TargetMapper[neuron] = targets[i];
            Console.WriteLine(neuron);
            i++;
        }
    }

    private void InitLayers(INeuron neuronTemplate, List<double> layers)
    {
        this.Layers = new List<ILayer>();
        for (int i = 0; i < layers.Count; i++)
        {
            this.Layers.Add(new Layer(neuronTemplate, layers[i]));
        }
    }

    private void InitSynapseCollection(IOptimiser optimiser)
    {
        // Check number of layers > 0 - through error if not
        this.SynapseCollections = new List<ISynapseCollection>();
        for (int i = 0; i < this.Layers.Count - 1; i++)
        {
            this.SynapseCollections.Add(new SynapseCollection(this.Layers[i].Neurons, this.Layers[i+1].Neurons, optimiser));
        }
    }

    private void Init_dL_dp_Mapper()
    {
        int indexOutputLayer = this.SynapseCollections.Count - 1;
        this.dL_dp_Mapper = new Dictionary<INeuron, double>();
        foreach (ISynapse synapse in this.SynapseCollections[indexOutputLayer].Synapses)
        {
            this.dL_dp_Mapper[synapse.OutputNeuron] = 0;
        }
    }

    private void Init_Targets()
    {
        int indexOutputLayer = this.SynapseCollections.Count - 1;
        this.TargetMapper = new Dictionary<INeuron, double>();
        foreach (ISynapse synapse in this.SynapseCollections[indexOutputLayer].Synapses)
        {
            this.TargetMapper[synapse.OutputNeuron] = 0;
        }
    }

    private void Update_dL_dp_Mapper()
    {
        foreach(var (neuron, dL_dp) in this.dL_dp_Mapper)
        {
            this.dL_dp_Mapper[neuron] = this.LossFunction.Calculate_dL_dp(TargetMapper[neuron], neuron.h);
        }
    }
}



