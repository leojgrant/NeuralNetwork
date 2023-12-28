using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.Neurons;

public class Neuron : INeuron
{
    public double Bias { get; set; }

    public IActivationFunction ActivationFunction { get; set; }

    public double Z { get; set; }

    public double h { get; set; }

    public Neuron(IActivationFunction activationFunction)
    {
        this.ActivationFunction = activationFunction;
        this.Bias = 0;
        this.Z = 0;
        this.h = 0;
    }

    public Neuron(INeuron neuronTemplate)
    {
        this.ActivationFunction = neuronTemplate.ActivationFunction;
        this.Bias = neuronTemplate.Bias;
        this.Z = neuronTemplate.Z;
        this.h = neuronTemplate.h;
    }
}


