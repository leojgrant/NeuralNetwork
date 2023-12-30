using NeuralNetwork.Service.Neurons;

namespace NeuralNetwork.Service.Layers
{
    /// <summary>
    /// A layer class representing a single layer of the neural network.
    /// </summary>
    public class Layer : ILayer
    {
        /// <summary>
        /// A list of the neurons in the layer of the neural network.
        /// </summary>
        public List<INeuron> Neurons { get; set; }

        /// <summary>
        /// The constructor method of the layer.
        /// </summary>
        /// <param name="neuronTemplate">A neuron to be used as a template for all other neurons in the layer.</param>
        /// <param name="numberOfNeurons">The number of neurons in the layer.</param>
        public Layer(INeuron neuronTemplate, double numberOfNeurons) 
        { 
            this.Neurons = new List<INeuron>();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                this.Neurons.Add(new Neuron(neuronTemplate));
            }
        }
    }
}
