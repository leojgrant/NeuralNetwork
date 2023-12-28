using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.Neurons;

public interface INeuron
{
    public double Bias { get; set; }

    public IActivationFunction ActivationFunction { get; set; }

    public double Z {  get; set; }

    public double h { get; set; }

    public double dL_dh { get; set; }
}
