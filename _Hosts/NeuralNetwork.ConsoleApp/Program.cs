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
IOptimiser optimiser = new SGD(0.001);
IActivationFunction activationFunction = new ReLu();
INeuron neuronTemplate = new Neuron(activationFunction);
ISimpleNeuralNetwork neuralNetwork = new SimpleNeuralNetwork([1, 2, 1], lossFunction, optimiser, neuronTemplate);

Console.WriteLine("Neural network created");

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, World!");