namespace NeuralNetwork.Service.LossFunctions;

public class MSE : ILossFunction
{
    public double CalculateLoss(double target, double prediction)
    {
        return 0.5 * Math.Pow((prediction - target), 2);
    }

    public double Calculate_dL_dp(double target, double prediction)
    {
        return prediction - target;
    }
}
