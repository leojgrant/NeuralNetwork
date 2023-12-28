using NeuralNetwork.Service.Activation_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Service.Neuron;

public interface INeuron
{
    public double Bias { get; set; }

    public IActivationFunction ActivationFunction { get; set; }

    public double Z {  get; set; }

    public double h { get; set; }
}
