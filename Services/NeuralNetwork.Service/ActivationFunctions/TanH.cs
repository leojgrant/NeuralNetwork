using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.ActivationFunctions;

public class TanH : IActivationFunction
{
    public double Calculate_h(double Z)
    {
        return 1 / (1 + Math.Exp(-1 * Z));
    }

    public double Calculate_dh_dZ(double h)
    {
        return h*(1-h);
    }
}
