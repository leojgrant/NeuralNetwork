// See https://aka.ms/new-console-template for more information
using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.ActivationFunctions;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.NeuralNetworks;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;


Console.WriteLine("Hello, World!");

Console.WriteLine("Creating neural network");
ILossFunction lossFunction = new MSE();
IOptimiser optimiser = new SGD(0.0001);
IActivationFunction activationFunction = new TanH();
INeuron neuronTemplate = new Neuron(activationFunction);
ISimpleNeuralNetwork neuralNetwork = new SimpleNeuralNetwork([1, 1, 2], lossFunction, optimiser, neuronTemplate);

Console.WriteLine("Neural network created (neurons using TanH Activation Function)");

Console.WriteLine("Initial Testing - inputting 1 to [1,2,1] neural network - expecting output of 0");
List<double> inputs = new List<double>() { 1 };
neuralNetwork.ForwardPropagate(inputs);

foreach(double prediction in neuralNetwork.Predictions)
{
    Console.WriteLine(prediction);
}

Console.WriteLine("");

activationFunction = new ReLu();
neuronTemplate = new Neuron(activationFunction);
neuralNetwork = new SimpleNeuralNetwork([1, 2, 1], lossFunction, optimiser, neuronTemplate);

Console.WriteLine("Neural network created (neurons using TanH Activation Function)");

Console.WriteLine("Initial Testing - inputting 1 to [1,2,1] neural network - expecting output of 0");
inputs = new List<double>() { 1 };
neuralNetwork.ForwardPropagate(inputs);

foreach (double prediction in neuralNetwork.Predictions)
{
    Console.WriteLine(prediction);
}

Console.WriteLine("");




Console.WriteLine("Hello, World!");
List<double> targets = new List<double>() { 4 };
neuralNetwork.Targets = targets;

for (int i = 0; i < 10000; i++)
{
    neuralNetwork.ForwardPropagate(inputs);
    neuralNetwork.BackPropagate();
    //Console.WriteLine("Prediction:");
    //Console.WriteLine(neuralNetwork.Predictions[0]);
}

Console.WriteLine("After Training to Aim for a value of 4, the neural network returns:");
Console.WriteLine(neuralNetwork.Predictions[0]);