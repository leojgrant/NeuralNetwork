using NeuralNetwork.Service.Neurons;

namespace NeuralNetwork.Service.Synapses;

public interface ISynapse
{
    public double Weight { get; set; }

    public double dL_dh { get; set; }

    public INeuron InputNeuron { get; set; }

    public INeuron OutputNeuron { get; set; }

    public void UpdateWeight(double dL_dho);
}
