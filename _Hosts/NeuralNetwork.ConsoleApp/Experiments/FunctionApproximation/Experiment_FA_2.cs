using NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;
using NeuralNetwork.ConsoleApp.Utilities;
using NeuralNetwork.Service.NeuralNetworks;
using ScottPlot;
using ScottPlot.Control;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NeuralNetwork.ConsoleApp.Experiments;
public class Experiment_FA_2 : IExperiment
{
    public void Run()
    {
        GenericActions.WriteToConsoleNewLine("Experiment_FA_2 is running...");
        GenericActions.WriteToConsoleNewLine("\nExperiment Details:");
        GenericActions.WriteToConsoleNewLine("\tThis experiment aims to approximate the circle function 100 = (x-10)^2 + (y-10)^2 i.e. a circle of radius 10, and centre (10,10).");
        INeuralNetworkCreationPlan neuralNetworkCreationPlan = new Seq_NN_2();
        ISequentialNeuralNetwork neuralNetwork = neuralNetworkCreationPlan.CreateNeuralNetwork();
        List<double> trainingInputData = new List<double>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<List<double>> targetData = new List<List<double>>() {
            new List<double>() { 10, 10 },
            new List<double>() { 5.6411, 14.3589 },
            new List<double>() { 4, 16 },
            new List<double>() { 2.8586, 17.1414 },
            new List<double>() { 2, 18 },
            new List<double>() { 1.3397, 18.6603 },
            new List<double>() { 0.8348, 19.1652 },
            new List<double>() { 0.4606, 19.5394 },
            new List<double>() { 0.2020, 19.7980},
            new List<double>() { 0.0501, 19.9499 },
            new List<double>() { 0, 20 },
            new List<double>() { 0.0501, 19.9499 },
            new List<double>() { 0.2020, 19.7980},
            new List<double>() { 0.4606, 19.5394 },
            new List<double>() { 0.8348, 19.1652 },
            new List<double>() { 1.3397, 18.6603 },
            new List<double>() { 2, 18 },
            new List<double>() { 2.8586, 17.1414 },
            new List<double>() { 4, 16 },
            new List<double>() { 5.6411, 14.3589 },
            new List<double>() { 10, 10 },
        };
        int numEpochs = 1000; // An epoch is when all the training data is used at once and is defined as the total number of iterations of all the training data in one cycle for training the machine learning model.
        GenericActions.WriteToConsoleNewLine("\nTraining Details:");
        neuralNetwork.ForwardPropagate([1]);
        Console.WriteLine(neuralNetwork.Predictions[0]);
        Console.WriteLine(neuralNetwork.Predictions[1]);
        GenericActions.WriteToConsoleNewLine("\tThe training cycle has begun.");
        for (int i = 0; i < numEpochs; i++)
        {
            if (i % 100 == 0)
            {
                Console.WriteLine(i);
            }
            for (int j = 0; j < trainingInputData.Count; j++)
            {
                neuralNetwork.Targets = targetData[j];
                neuralNetwork.ForwardPropagate([trainingInputData[j]]);
                neuralNetwork.BackPropagate();

            }
        }
        GenericActions.WriteToConsoleNewLine("\tThe training has finished.");
        GenericActions.WriteToConsoleNewLine("\nTesting Details:");
        GenericActions.WriteToConsoleNewLine("\tTesting with input data = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20");
        double[] testInputData = new double[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        double[] neuralNetworkOutputData = new double[testInputData.Length];
        for (int i = 0; i < testInputData.Length/2; i++)
        {
            neuralNetwork.ForwardPropagate([testInputData[i]]);
            neuralNetworkOutputData[i * 2] = neuralNetwork.Predictions[0];
            neuralNetworkOutputData[(i * 2) + 1] = neuralNetwork.Predictions[1];
        }
        GenericActions.WriteToConsoleNewLine($"\tCorresponding predictions from trained neural network: {Math.Round(neuralNetworkOutputData[0], 4)}, {Math.Round(neuralNetworkOutputData[1], 4)}, {Math.Round(neuralNetworkOutputData[2], 4)}, {Math.Round(neuralNetworkOutputData[3], 4)}, {Math.Round(neuralNetworkOutputData[4], 4)}");
        //double[] testInputDat = new double[] { 0, 0, 1, 1, 2, 2, 3, 3 };
        //double[] neuralNetworkOutputDat = new double[] { 0, 1, 0, 2, 0, 3, 0, 4 };
        var myPlot = new ScottPlot.Plot(1200, 900);
        myPlot.AddScatter(testInputData, neuralNetworkOutputData);
        myPlot.Title("Experiment_FA_2");
        myPlot.XLabel("Test Data");
        myPlot.YLabel("Model Prediction");
        myPlot.SaveFig("C:/Users/Owner/Documents/Software Development/C#/Console Applications/NeuralNetwork/NeuralNetwork/Results/Experiment_FA_2.png");
        neuralNetwork.ForwardPropagate([10]);
        Console.WriteLine(neuralNetwork.Predictions[0]);
        Console.WriteLine(neuralNetwork.Predictions[1]);
    }
}

