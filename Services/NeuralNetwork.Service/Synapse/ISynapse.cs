using NeuralNetwork.Service.Neuron;

namespace NeuralNetwork.Service.Synapse;

public interface ISynapse
{
    public double Weight { get; set; }

    public INeuron InputNeuron { get; set; }

    public INeuron OutputNeuron { get; set; }

    public void UpdateWeight(double dL_dho);
}
