using NeuralNetwork.Service.Synapse;

namespace NeuralNetwork.Service.Layer;

public class Layer : ILayer
{
    public IEnumerable<ISynapse> Synapses { get; set; }

    public void UpdateWeights(Dictionary<>)
    {
        foreach(ISynapse synapse in this.Synapses)
        {

            synapse.UpdateWeight(dL_dho);
        }
    }
}
