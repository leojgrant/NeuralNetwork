using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.Neuron;

public class Neuron : INeuron
{
    public double Bias { get; set; }

    public IActivationFunction ActivationFunction { get; set; }

    public double Z { get; set; }

    public double h { get; set; }
}


