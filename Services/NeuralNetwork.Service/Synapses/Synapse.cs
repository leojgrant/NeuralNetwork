using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;
using NeuralNetwork.Service.Synapses.WeightInitialisation;

namespace NeuralNetwork.Service.Synapses;

/// <summary>
/// A synapse.
/// </summary>
public class Synapse : ISynapse
{
    /// <summary>
    /// The weight applied to signals travelling across the synapse.
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// The input neuron of the synapse.
    /// </summary>
    public INeuron InputNeuron { get; set; }

    /// <summary>
    /// The output neuron of the synapse.
    /// </summary>
    public INeuron OutputNeuron { get; set; }

    /// <summary>
    /// The dL_dhi value of the synapse ('hi' is the signal value leaving the input neuron of the synapse.
    /// </summary>
    public double dL_dhi {  get; set; }

    /// <summary>
    /// The optimiser used by the synapse to update its weight.
    /// </summary>
    public IOptimiser Optimiser { get; set; }

    /// <summary>
    /// A constructor method of the synapse.
    /// </summary>
    /// <param name="inputNeuron"></param>
    /// <param name="outputNeuron"></param>
    /// <param name="optimiser"></param>
    public Synapse(INeuron inputNeuron, INeuron outputNeuron, IOptimiser optimiser, IWeightInitialiser weightInitialiser)
    {
        this.InputNeuron = inputNeuron;
        this.OutputNeuron = outputNeuron;
        this.Optimiser = optimiser;
        this.Weight = weightInitialiser.RandomNumberBetweenZeroAndPlusOne();
        this.dL_dhi = 0;
    }

    /// <summary>
    /// Back propagate the synapse.
    /// </summary>
    /// <param name="dL_dho">The dL_dh value of the output neuron.</param>
    public void BackPropagateSynapse(double dL_dho)
    {
        double dL_dW = this.Calculate_dL_dW(dL_dho);
        this.Weight = Optimiser.CalculateImprovedWeight(this.Weight, dL_dW);
        this.Refresh_dL_dhi(dL_dho);
    }

    /// <summary>
    /// Calculate dL_dW for the weight of the synapse.
    /// </summary>
    /// <param name="dL_dho">The dL_dh value of the output neuron.</param>
    /// <returns>The loss gradient of the synapse weight (dL_dW)</returns>
    private double Calculate_dL_dW(double dL_dho)
    {
        double dZo_dW = this.InputNeuron.h;
        double dho_dZo = this.OutputNeuron.ActivationFunction.Calculate_dh_dZ(this.OutputNeuron.h);
        return dZo_dW * dho_dZo * dL_dho;
    }

    /// <summary>
    /// Refresh the dL_dhi value of this synapse.
    /// </summary>
    /// <param name="dL_dho">The dL_dh value of the output neuron.</param>
    private void Refresh_dL_dhi(double dL_dho)
    {
        double dZo_dhi = this.Weight;
        double dho_dZo = this.OutputNeuron.h;
        this.dL_dhi = dZo_dhi * dho_dZo * dL_dho;
    }
}
