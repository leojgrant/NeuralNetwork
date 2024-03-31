namespace NeuralNetwork.Service.Synapses.WeightInitialisation
{
    public class WeightInitialiser : IWeightInitialiser
    {
        public double RandomNumberBetweenMinusOnePlusOne()
        {
            Random random = new Random();
            return (random.NextDouble() * 2 ) - 1;
        }

        public double RandomNumberBetweenZeroAndPlusOne()
        {
            Random random = new Random();
            return random.NextDouble();
        }
    }
}
