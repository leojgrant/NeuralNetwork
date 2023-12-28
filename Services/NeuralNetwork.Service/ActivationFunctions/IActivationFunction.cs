namespace NeuralNetwork.Service.Activation_Functions;

public interface IActivationFunction
{
    public double Calculate_h(double Z);

    public double Calculate_dh_dZ(double h);
}
