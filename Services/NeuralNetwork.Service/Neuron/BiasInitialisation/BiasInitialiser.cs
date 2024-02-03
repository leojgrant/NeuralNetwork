namespace NeuralNetwork.Service.Neurons.BiasInitialisation
{
    public class BiasInitialiser : IBiasInitialiser
    {
        public double RandomNumberBetweenMinusOnePlusOne()
        {
            Random random = new Random();
            return (random.NextDouble() * 2 ) - 1;
        }
    }
}
