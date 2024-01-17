using NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;
using NeuralNetwork.ConsoleApp.Utilities;
using NeuralNetwork.Service.NeuralNetworks;
using ScottPlot;
using ScottPlot.Control;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NeuralNetwork.ConsoleApp.Experiments;
public class Experiment_FA_3 : IExperiment
{
    public void Run()
    {
        GenericActions.WriteToConsoleNewLine("Experiment_FA_3 is running...");
        GenericActions.WriteToConsoleNewLine("\nExperiment Details:");
        GenericActions.WriteToConsoleNewLine("\tThis experiment aims to replicate f(1) = 5 or f(1) = 10");
        INeuralNetworkCreationPlan neuralNetworkCreationPlan = new Seq_NN_2();
        ISequentialNeuralNetwork neuralNetwork = neuralNetworkCreationPlan.CreateNeuralNetwork();
        List<double> trainingInputData = new List<double>() { 1, 2 };
        List<List<double>> targetData = new List<List<double>>() {
            new List<double>() { 5, 10 },
            new List<double>() { 0, 20 },
        };
        int numEpochs = 100000; // An epoch is when all the training data is used at once and is defined as the total number of iterations of all the training data in one cycle for training the machine learning model.
        GenericActions.WriteToConsoleNewLine("\nTraining Details:");
        neuralNetwork.ForwardPropagate([1]);
        Console.WriteLine("Initial predictions with an input of 1 are:"+ neuralNetwork.Predictions[0] +", "+ neuralNetwork.Predictions[1]);
        GenericActions.WriteToConsoleNewLine("\tThe training cycle has begun.");
        for (int i = 0; i < numEpochs; i++)
        {
            if (i % 10000 == 0)
            {
                Console.WriteLine("\tEpochs performed: " + i);
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
        GenericActions.WriteToConsoleNewLine("\tTesting with input data = 1, 2");
        double[] testInputData = new double[] { 1, 2 };
        double[] neuralNetworkOutputData = new double[testInputData.Length];
        for (int i = 0; i < testInputData.Length / 2; i++)
        {
            neuralNetwork.ForwardPropagate([testInputData[i]]);
            neuralNetworkOutputData[i * 2] = neuralNetwork.Predictions[0];
            neuralNetworkOutputData[(i * 2) + 1] = neuralNetwork.Predictions[1];
        }
        GenericActions.WriteToConsoleNewLine($"\tCorresponding predictions from trained neural network: {Math.Round(neuralNetworkOutputData[0], 4)}, {Math.Round(neuralNetworkOutputData[1], 4)}");
        var myPlot = new ScottPlot.Plot(1200, 900);
        myPlot.AddScatter(testInputData, neuralNetworkOutputData);
        myPlot.Title("Experiment_FA_3");
        myPlot.XLabel("Test Data");
        myPlot.YLabel("Model Prediction");
        var resultFile = "Experiment_FA_3.png";
        Config config = GenericActions.GetConfig();
        myPlot.SaveFig(config.FileDownloadPath + resultFile);
        GenericActions.WriteToConsoleNewLine("\tResults download path: " + config.FileDownloadPath + resultFile);
        GenericActions.WriteToConsoleNewLine("\nExperiment has finished.");
    }
}

