﻿namespace NeuralNetwork.Service.Synapses.WeightInitialisation
{
    public class WeightInitialiser : IWeightInitialiser
    {
        public double RandomNumberBetweenMinusOnePlusOne()
        {
            Random random = new Random();
            return (random.NextDouble() * 2 ) - 1;
        }
    }
}
