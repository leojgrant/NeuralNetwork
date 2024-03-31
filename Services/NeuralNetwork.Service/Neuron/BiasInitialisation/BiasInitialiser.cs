namespace NeuralNetwork.Service.Neurons.BiasInitialisation;

public class BiasInitialiser : IBiasInitialiser
{
    public double Zero()
    {
        return 0;
    }

    public double RandomNumberBetweenMinusOnePlusOne()
    {
        Random random = new Random();
        return (random.NextDouble() * 2) - 1;
    }
}
