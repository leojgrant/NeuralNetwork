// See https://aka.ms/new-console-template for more information
using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.ActivationFunctions;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.NeuralNetworks;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;

List<double> ExtractNumbersFromString(String userInput)
{
    userInput = userInput + "-end";
    string number = "";
    List<double> numbers = new List<double>();
    foreach (char c in userInput)
    {
        if (Char.IsDigit(c))
        {
            number = number + c;
        } else if (number != "")
        {
            numbers.Add(Convert.ToDouble(number));
            number = "";
        }
    }
    return numbers;
}


Console.WriteLine("Welcome to the simple neural network console app!\n");

while (true) { 

    Console.WriteLine("Please enter the desired layer configuration of your neural network below");
    Console.WriteLine("**Tip: enter a set of separated numbers e.g. '1 2 2 1', which creates the neural network below:");
    Console.WriteLine(@"         O---O          ");
    Console.WriteLine(@"        / \ / \         ");
    Console.WriteLine(@"input->O   \   O->Output");
    Console.WriteLine(@"        \ / \ /         ");
    Console.WriteLine(@"         O---O          ");
    Console.WriteLine();
    Console.Write("Enter layer configuration here: ");
    String userInput = Console.ReadLine();

    List<double> layers = ExtractNumbersFromString(userInput);

    Console.Write("\nCustomise the neural network configuration further (y/n): ");
    userInput = Console.ReadLine();

    ILossFunction lossFunction;
    IActivationFunction activationFunction;
    IOptimiser optimiser;
    double learningRate;
    ISequentialNeuralNetwork neuralNetwork;
    if (userInput == "y")
    {
        Console.WriteLine("\nSelecting default neural network configuration:\n");
        Console.WriteLine("Loss function = MSE");
        Console.WriteLine("Activation function = ReLu");
        Console.WriteLine("Optimiser = SGD");
        Console.WriteLine("Learning rate = 0.001");
        lossFunction = new MSE();
        activationFunction = new ReLu();
        learningRate = 0.0001;
        optimiser = new SGD(learningRate);
        INeuron neuronTemplate = new Neuron(activationFunction);

        Console.WriteLine("\nCreating neural network...");
        neuralNetwork = new SequentialNeuralNetwork(layers, lossFunction, optimiser, neuronTemplate);
        Console.WriteLine("\nNeural network created!\n");
    } else
    {
        Console.WriteLine("\nSelecting default neural network configuration:\n");
        Console.WriteLine("Loss function = MSE");
        Console.WriteLine("Activation function = ReLu");
        Console.WriteLine("Optimiser = SGD");
        Console.WriteLine("Learning rate = 0.0001");
        lossFunction = new MSE();
        activationFunction = new ReLu();
        learningRate = 0.0001;
        optimiser = new SGD(learningRate);
        INeuron neuronTemplate = new Neuron(activationFunction);

        Console.WriteLine("\nCreating neural network...");
        neuralNetwork = new SequentialNeuralNetwork(layers, lossFunction, optimiser, neuronTemplate);
        Console.WriteLine("\nNeural network created!\n");
    }

    Console.Write("Enter input(s) to neural network: ");
    userInput = Console.ReadLine();
    Console.WriteLine("");
    List<double> inputs = ExtractNumbersFromString(userInput);
    while (inputs.Count != layers[0])
    {
        Console.WriteLine($"**Error: The number of inputs does not match the number of neurons in the input layer ({layers[0]}).");
        Console.Write($"Please enter new inputs here: ");
        userInput = Console.ReadLine();
        inputs = ExtractNumbersFromString(userInput);
        Console.WriteLine("");
    }

    Console.Write("Enter target(s) for neural network: ");
    userInput = Console.ReadLine();
    Console.WriteLine("");
    List<double> targets = ExtractNumbersFromString(userInput);
    while (targets.Count != layers[layers.Count - 1])
    {
        Console.WriteLine($"**Error: The number of targets does not match the number of neurons in the output layer ({layers.Count - 1}).");
        Console.Write($"Please enter new targets here: ");
        userInput = Console.ReadLine();
        targets = ExtractNumbersFromString(userInput);
        Console.WriteLine("");
    }

    neuralNetwork.Targets = targets;

    Console.Write("Enter the number of training cycles to perform: ");
    userInput = Console.ReadLine();
    double numberOfTrainingCycles = ExtractNumbersFromString(userInput)[0];
    neuralNetwork.ForwardPropagate(inputs);
    Console.Write("\nThe initial prediction of the neural network is:");
    for(int i = 0; i < neuralNetwork.Predictions.Count; i++)
    {
        Console.Write($" {neuralNetwork.Predictions[i]}");
        if (i == neuralNetwork.Predictions.Count - 1)
        {
            Console.WriteLine(".");
        } else
        {
            Console.Write(",");
        }
    }

    Console.WriteLine("\nTraining cycle has started.");
    for (int i = 0; i < numberOfTrainingCycles; i++)
    {
        neuralNetwork.ForwardPropagate(inputs);
        neuralNetwork.BackPropagate();
    }
    Console.WriteLine("\nTraining cycle has ended.");

    Console.Write("\nThe final prediction of the neural network is:");
    for (int i = 0; i < neuralNetwork.Predictions.Count; i++)
    {
        Console.Write($" {neuralNetwork.Predictions[i]}");
        if (i == neuralNetwork.Predictions.Count - 1)
        {
            Console.Write(".");
        }
        else
        {
            Console.Write(",");
        }
    }

    Console.WriteLine("\nThe weights in the neural network are: ");
    foreach (var synapseCollection in neuralNetwork.SynapseCollections)
    {
        foreach (var synapse in synapseCollection.Synapses)
        {
            Console.WriteLine($"{synapse.Weight}");
        }
    }

    Console.Write("\nRepeat the process (y/n): ");
    userInput = Console.ReadLine();
    Console.WriteLine("");
    if (userInput == "n")
    {
        Environment.Exit(0);
    }
}
