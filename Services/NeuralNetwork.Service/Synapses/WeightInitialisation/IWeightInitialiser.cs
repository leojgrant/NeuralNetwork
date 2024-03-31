namespace NeuralNetwork.Service.Synapses.WeightInitialisation
{
    public interface IWeightInitialiser
    {
        public double RandomNumberBetweenMinusOnePlusOne();

        public double RandomNumberBetweenZeroAndPlusOne();
    }
}
