using NeuralNetwork.ConsoleApp.Utilities;
using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.ActivationFunctions;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.NeuralNetworks;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Neurons.BiasInitialisation;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Synapses.WeightInitialisation;

namespace NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;

public class Seq_NN_3 : INeuralNetworkCreationPlan
{
    public ISequentialNeuralNetwork CreateNeuralNetwork()
    {
        GenericActions.WriteToConsoleNewLine("\nNeural Network Details:");
        GenericActions.WriteToConsoleNewLine("\tNeural Network Creation Plan = Seq_NN_3");
        GenericActions.WriteToConsoleNewLine("\tLoss function = MSE");
        GenericActions.WriteToConsoleNewLine("\tActivation function = ReLu");
        GenericActions.WriteToConsoleNewLine("\tOptimiser = SGD");
        GenericActions.WriteToConsoleNewLine("\tLearning rate = 0.001");

        List<double> layers = new List<double>() { 1,9000,1 };
        ILossFunction lossFunction = new MSE();
        IActivationFunction activationFunction = new ReLu();
        double learningRate = 0.00000001;
        IOptimiser optimiser = new SGD(learningRate);
        IWeightInitialiser weightInitialiser = new WeightInitialiser();
        IBiasInitialiser biasInitialiser = new BiasInitialiser();
        INeuron neuronTemplate = new Neuron(activationFunction, optimiser, biasInitialiser);

        GenericActions.WriteToConsoleNewLine("\tLayer configuration:");
        GenericActions.WriteToConsoleNewLine("\t" + @"        [1]  [9000]   [1]        ");
        GenericActions.WriteToConsoleNewLine("\t" + @"input--->O----->O----->O--->Output");


        ISequentialNeuralNetwork neuralNetwork = new SequentialNeuralNetwork(layers, lossFunction, optimiser, weightInitialiser, neuronTemplate, biasInitialiser);
        GenericActions.WriteToConsoleNewLine("\tNeural network created!");
        return neuralNetwork;
    }
}
