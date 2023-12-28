namespace NeuralNetwork.Service.LossFunctions;

public interface ILossFunction
{
    public double CalculateLoss(double target, double prediction);

    public double Calculate_dL_dp(double target, double prediction);
}
