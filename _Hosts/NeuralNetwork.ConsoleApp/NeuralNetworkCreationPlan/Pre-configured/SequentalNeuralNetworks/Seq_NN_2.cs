using NeuralNetwork.ConsoleApp.Utilities;
using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.ActivationFunctions;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.NeuralNetworks;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;

namespace NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;

public class Seq_NN_2 : INeuralNetworkCreationPlan
{
    public ISequentialNeuralNetwork CreateNeuralNetwork()
    {
        GenericActions.WriteToConsoleNewLine("\nNeural Network Details:");
        GenericActions.WriteToConsoleNewLine("\tNeural Network Creation Plan = Seq_NN_2");
        GenericActions.WriteToConsoleNewLine("\tLoss function = MSE");
        GenericActions.WriteToConsoleNewLine("\tActivation function = ReLu");
        GenericActions.WriteToConsoleNewLine("\tOptimiser = SGD");
        GenericActions.WriteToConsoleNewLine("\tLearning rate = 0.001");

        List<double> layers = new List<double>() { 1, 2,2,2,2,2,2 };
        ILossFunction lossFunction = new MSE();
        IActivationFunction activationFunction = new ReLu();
        double learningRate = 0.00000001;
        IOptimiser optimiser = new SGD(learningRate);
        INeuron neuronTemplate = new Neuron(activationFunction, optimiser);

        GenericActions.WriteToConsoleNewLine("\tLayer configuration:");
        GenericActions.WriteToConsoleNewLine("\t" + @"         O---O          ");
        GenericActions.WriteToConsoleNewLine("\t" + @"        / \ / \         ");
        GenericActions.WriteToConsoleNewLine("\t" + @"input->O   \   O->Output");
        GenericActions.WriteToConsoleNewLine("\t" + @"        \ / \ /         ");
        GenericActions.WriteToConsoleNewLine("\t" + @"         O---O          ");

        ISequentialNeuralNetwork neuralNetwork = new SequentialNeuralNetwork(layers, lossFunction, optimiser, neuronTemplate);
        GenericActions.WriteToConsoleNewLine("\tNeural network created!");
        return neuralNetwork;
    }
}
