using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Synapses;

namespace NeuralNetwork.Service.SynapseCollections;

public class SynapseCollection : ISynapseCollection
{
    public List<ISynapse> Synapses { get; set; }

    public Dictionary<INeuron, double> dL_dh_Mapper {  get; set; }

    public SynapseCollection(List<INeuron> inputNeurons, List<INeuron> outputNeurons, IOptimiser optimiser) 
    {
        //this.Synapses = synapses;
        this.InitSynapses(inputNeurons, outputNeurons, optimiser);
        this.Init_dL_dh_Mapper();
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

    private void Init_dL_dh_Mapper()
    {
        this.dL_dh_Mapper = new Dictionary<INeuron, double>();
        foreach (ISynapse synapse in this.Synapses)
        {
            this.dL_dh_Mapper[synapse.InputNeuron] = 0;
        }
    }

    public void UpdateWeights(Dictionary<INeuron, double> Next_Layer_dL_dh_Mapper)
    {
        foreach(ISynapse synapse in this.Synapses)
        {
            synapse.UpdateWeight(Next_Layer_dL_dh_Mapper[synapse.OutputNeuron]);
        }
        Update_dL_dh_Mapper();
    }

    private void Update_dL_dh_Mapper()
    {
        Reset_dL_dh_Mapper();
        foreach (ISynapse synapse in this.Synapses)
        {
            this.dL_dh_Mapper[synapse.InputNeuron] += synapse.dL_dh;
        }
    }

    private void Reset_dL_dh_Mapper()
    {
        foreach (var (neuron, dL_dh) in this.dL_dh_Mapper)
        {
            this.dL_dh_Mapper[neuron] = 0;
        }
    }
}
