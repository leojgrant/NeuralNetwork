using NeuralNetwork.ConsoleApp.Utilities;
using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.ActivationFunctions;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.NeuralNetworks;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;

namespace NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;

public class Seq_NN_1 : INeuralNetworkCreationPlan
{
    public ISequentialNeuralNetwork CreateNeuralNetwork()
    {
        GenericActions.WriteToConsoleNewLine("\nSelected the Seq_NN_1 neural network creation plan:\n");
        GenericActions.WriteToConsoleNewLine("Loss function = MSE");
        GenericActions.WriteToConsoleNewLine("Activation function = ReLu");
        GenericActions.WriteToConsoleNewLine("Optimiser = SGD");
        GenericActions.WriteToConsoleNewLine("Learning rate = 0.001");

        List<double> layers = new List<double>() { 1, 16, 1 };
        ILossFunction lossFunction = new MSE();
        IActivationFunction activationFunction = new ReLu();
        double learningRate = 0.0001;
        IOptimiser optimiser = new SGD(learningRate);
        INeuron neuronTemplate = new Neuron(activationFunction);

        GenericActions.WriteToConsoleNewLine("\nLayer configuration:");
        GenericActions.WriteToConsoleNewLine(@"         O---O          ");
        GenericActions.WriteToConsoleNewLine(@"        / \ / \         ");
        GenericActions.WriteToConsoleNewLine(@"input->O   \   O->Output");
        GenericActions.WriteToConsoleNewLine(@"        \ / \ /         ");
        GenericActions.WriteToConsoleNewLine(@"         O---O          ");

        ISequentialNeuralNetwork neuralNetwork = new SequentialNeuralNetwork(layers, lossFunction, optimiser, neuronTemplate);
        GenericActions.WriteToConsoleNewLine("\nNeural network created!\n");
        return neuralNetwork;
    }
}
