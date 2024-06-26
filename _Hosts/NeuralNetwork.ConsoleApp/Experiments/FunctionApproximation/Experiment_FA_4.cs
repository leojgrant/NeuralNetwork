﻿using NeuralNetwork.ConsoleApp.NeuralNetworkCreationPlan;
using NeuralNetwork.ConsoleApp.Utilities;
using NeuralNetwork.Service.NeuralNetworks;
using ScottPlot;
using ScottPlot.Control;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NeuralNetwork.ConsoleApp.Experiments;
public class Experiment_FA_4 : IExperiment
{
    public void Run()
    {
        GenericActions.WriteToConsoleNewLine("Experiment_FA_4 is running...");
        GenericActions.WriteToConsoleNewLine("\nExperiment Details:");
        GenericActions.WriteToConsoleNewLine("\tThis experiment aims to approximate the function y = x.");
        INeuralNetworkCreationPlan neuralNetworkCreationPlan = new Seq_NN_3();
        ISequentialNeuralNetwork neuralNetwork = neuralNetworkCreationPlan.CreateNeuralNetwork();
        List<double> trainingInputData = new List<double>() { 1, 2, 3, 4, 5 };
        List<double> targetData = new List<double>() { 1, 2, 3, 4, 5 };
        int numEpochs = 10; // An epoch is when all the training data is used at once and is defined as the total number of iterations of all the training data in one cycle for training the machine learning model.
        GenericActions.WriteToConsoleNewLine("\nTraining Details:");
        GenericActions.WriteToConsoleNewLine("\tThe training cycle has begun.");
        for (int i = 0; i < numEpochs; i++)
        {
            if (i % 1 == 0)
            {
                Console.WriteLine("\tEpochs performed: " + i);
            }
            for (int j = 0; j < trainingInputData.Count; j++)
            {
                neuralNetwork.Targets = [targetData[j]];
                neuralNetwork.ForwardPropagate([trainingInputData[j]]);
                neuralNetwork.BackPropagate();
            }
        }
        GenericActions.WriteToConsoleNewLine("\tThe training has finished.");
        GenericActions.WriteToConsoleNewLine("\nTesting Details:");
        GenericActions.WriteToConsoleNewLine("\tTesting with input data = 1, 2, 3, 4, 5");
        double[] testInputData = new double[] { 1, 2, 3, 4, 5 };
        double[] neuralNetworkOutputData = new double[testInputData.Length];
        for(int i = 0; i < testInputData.Length; i++)
        {
            neuralNetwork.ForwardPropagate([testInputData[i]]);
            neuralNetworkOutputData[i] = neuralNetwork.Predictions[0];
        }
        GenericActions.WriteToConsoleNewLine($"\tCorresponding predictions from trained neural network: {Math.Round(neuralNetworkOutputData[0], 4)}, {Math.Round(neuralNetworkOutputData[1], 4)}, {Math.Round(neuralNetworkOutputData[2], 4)}, {Math.Round(neuralNetworkOutputData[3], 4)}, {Math.Round(neuralNetworkOutputData[4], 4)}");
        var myPlot = new ScottPlot.Plot(1200, 900);
        myPlot.AddScatter(testInputData, neuralNetworkOutputData);
        myPlot.Title("Experiment_FA_4");
        myPlot.XLabel("Test Data");
        myPlot.YLabel("Model Prediction");
        var resultFile = "Experiment_FA_4.png";
        Config config = GenericActions.GetConfig();
        myPlot.SaveFig(config.FileDownloadPath + resultFile);
        GenericActions.WriteToConsoleNewLine("\tResults download path: " + config.FileDownloadPath + resultFile);
        GenericActions.WriteToConsoleNewLine("\nExperiment has finished.");
    }
}

