using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Service.Synapses.WeightInitialisation
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
