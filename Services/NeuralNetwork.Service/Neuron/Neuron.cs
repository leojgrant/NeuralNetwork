using NeuralNetwork.Service.Activation_Functions;
using NeuralNetwork.Service.Optimisers;

namespace NeuralNetwork.Service.Neurons;

/// <summary>
/// A neuron.
/// </summary>
public class Neuron : INeuron
{
    /// <summary>
    /// The bias of a neuron.
    /// </summary>
    public double Bias { get; set; }

    /// <summary>
    /// The activation function applied to the signal (Z) in the neuron.
    /// </summary>
    public IActivationFunction ActivationFunction { get; set; }

    public IOptimiser Optimiser { get; set; }

    /// <summary>
    /// The sum of the signals entering the neuron and the bias of the neuron during a run of forward propagation.
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// The output of the neuron (after Z is transformed by the activation function) during a run of forward propagation..
    /// </summary>
    public double h { get; set; }

    /// <summary>
    /// The loss gradient of the neuron output h during the most recent run of back propagation.
    /// </summary>
    public double dL_dh { get; set; }

    /// <summary>
    /// A constructor method of a neuron.
    /// </summary>
    /// <param name="activationFunction">The activation function applied to signals (Z) running through the neuron during forward propagation.</param>
    public Neuron(IActivationFunction activationFunction, IOptimiser optimiser)
    {
        this.ActivationFunction = activationFunction;
        this.Optimiser = optimiser;
        this.Bias = 0;
        this.Z = 0;
        this.h = 0;
    }

    /// <summary>
    /// A constructor method of a neuron (creating a neuron by copying another neuron).
    /// </summary>
    /// <param name="neuronTemplate">The neuron from which the new neuron should be copied.</param>
    public Neuron(INeuron neuronTemplate)
    {
        this.ActivationFunction = neuronTemplate.ActivationFunction;
        this.Optimiser = neuronTemplate.Optimiser;
        this.Bias = neuronTemplate.Bias;
        this.Z = neuronTemplate.Z;
        this.h = neuronTemplate.h;
    }
}


