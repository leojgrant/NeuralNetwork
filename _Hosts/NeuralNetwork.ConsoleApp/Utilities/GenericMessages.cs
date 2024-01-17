using System.Text.Json;

namespace NeuralNetwork.ConsoleApp.Utilities
{
    public static class GenericMessages
    {
        public static void WelcomeToConsoleApp()
        {
            GenericActions.WriteToConsoleNewLine("Welcome to the simple neural network console app!\n");
        }

        public static void DisplayExperimentSelectionOptions()
        {
            Config configObj = GenericActions.GetConfig();
            GenericActions.WriteToConsoleNewLine("Please select one of the pre-configured neural networks below:");
            GenericActions.BreakLine();
            for (int i = 0; i < configObj.ExperimentSelection.Count; i++)
            {
                GenericActions.WriteToConsoleNewLine($"{i + 1} - " + configObj.ExperimentSelection[i]);
            }
            GenericActions.BreakLine();
        }

        public static void DisplayNeuralNetworkSelectionOptions()
        {
            Config configObj = GenericActions.GetConfig();
            GenericActions.WriteToConsoleNewLine("Please select one of the pre-configured neural networks below:");
            GenericActions.BreakLine();
            for(int i = 0; i < configObj.NeuralNetworkSelection.Count; i++)
            {
                GenericActions.WriteToConsoleNewLine($"{i+1} - " + configObj.NeuralNetworkSelection[i]);
            }
            GenericActions.BreakLine();
        }
    }
}
