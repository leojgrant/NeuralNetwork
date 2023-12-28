
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Synapses;

namespace NeuralNetwork.Service.SynapseCollections;

public interface ISynapseCollection
{
    public List<ISynapse> Synapses { get; set; }

    public Dictionary<INeuron, double> dL_dh_Mapper { get; set; }

    public void UpdateWeights(Dictionary<INeuron, double> Next_Layer_dL_dh_Mapper);
}
