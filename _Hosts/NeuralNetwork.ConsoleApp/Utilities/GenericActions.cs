using NeuralNetwork.ConsoleApp.Experiments;
using NeuralNetwork.Service.NeuralNetworks;
using System.Text.Json;

namespace NeuralNetwork.ConsoleApp.Utilities
{
    public static class GenericActions
    {
        public static String ReadUserInput()
        {
            return Console.ReadLine();
        }

        public static void WriteToConsoleNewLine(String text)
        {
            Console.WriteLine(text);
        }
        public static void WriteToConsoleNoBreak(String text)
        {
            Console.Write(text);
        }

        public static void BreakLine()
        {
            Console.WriteLine();
        }

        public static Config GetConfig()
        {
            var configString = File.ReadAllText("../../../config.json");
            return JsonSerializer.Deserialize<Config>(configString);
        }

        public static double GetExperimentNumberInput()
        {
            String userInput;
            List<double> inputs;
            while (true)
            {
                userInput = GenericActions.ReadUserInput();
                GenericActions.BreakLine();
                inputs = HelperFunctions.ExtractNumbersFromString(userInput);
                if (inputs.Count == 0)
                {
                    GenericActions.WriteToConsoleNewLine("**Error: No numbers were input.");
                    GenericActions.WriteToConsoleNoBreak($"Please enter new inputs here: ");
                } else
                {
                    return inputs[0];
                }
            }
        }

        public static String MapExperimentNumberToName(int experimentNumber)
        {
            Config config = GenericActions.GetConfig();
            return config.ExperimentSelection[experimentNumber - 1];
        }

        public static void RunExperiment(String experimentName)
        {
            experimentName = "NeuralNetwork.ConsoleApp.Experiments." + experimentName;
            Type experimentType = Type.GetType(experimentName);
            IExperiment experiment;
            if (experimentType != null)
            {
                experiment = Activator.CreateInstance(experimentType) as IExperiment;
                experiment.Run();
                return;
            }

            // Iterate over the assemblies in the current domain.
            // An assembly is a collection of types and resources that are built to work together and form a logical unit of functionality.
            // Assemblies take the form of executable (.exe) or dynamic link library (.dll) files, and are the building blocks of .NET applications.
            // https://learn.microsoft.com/en-us/dotnet/standard/assembly/
            // An app domain represents an isolated environment where applications run. They provide boundaries between different applications.
            // App.Domain.CurrentDomain specifies the app domain that is currently executing.
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                experimentType = asm.GetType(experimentName);
                if (experimentType != null)
                {
                    experiment = Activator.CreateInstance(experimentType) as IExperiment;
                    experiment.Run();
                    return;
                }
            }
            GenericActions.WriteToConsoleNewLine("\nNo experiment found");
        }

        public static void CloseApp()
        {
            Environment.Exit(0);
        }
    }
}
