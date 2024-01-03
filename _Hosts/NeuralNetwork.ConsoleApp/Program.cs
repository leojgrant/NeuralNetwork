// See https://aka.ms/new-console-template for more information
using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.ActivationFunctions;
using NeuralNetwork.Service.LossFunctions;
using NeuralNetwork.Service.NeuralNetworks;
using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.ConsoleApp.Utilities;


GenericMessages.WelcomeToConsoleApp();

GenericMessages.DisplayExperimentSelectionOptions();

double experimentNumber = GenericActions.GetExperimentNumberInput();

String experimentName = GenericActions.MapExperimentNumberToName((int)experimentNumber);

GenericActions.RunExperiment(experimentName);

GenericActions.CloseApp();




