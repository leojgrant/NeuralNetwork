namespace NeuralNetwork.Service.Neurons.BiasInitialisation
{
    public interface IBiasInitialiser
    {
        public double Zero();
        public double RandomNumberBetweenMinusOnePlusOne();
    }
}
