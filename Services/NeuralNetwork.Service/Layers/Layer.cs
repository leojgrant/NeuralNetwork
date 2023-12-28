using NeuralNetwork.Service.Neurons;

namespace NeuralNetwork.Service.Layers
{
    public class Layer : ILayer
    {
        public List<INeuron> Neurons { get; set; }

        public Layer(INeuron neuron, double numberOfNeurons) 
        { 
            this.Neurons = new List<INeuron>();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                this.Neurons.Add(new Neuron(neuron));
            }
        }
    }
}
