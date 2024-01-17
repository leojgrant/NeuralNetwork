using NeuralNetwork.Service.NeuralNetworks;

namespace NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;

public interface INeuralNetworkCreationPlan
{
    public ISequentialNeuralNetwork CreateNeuralNetwork();
}
