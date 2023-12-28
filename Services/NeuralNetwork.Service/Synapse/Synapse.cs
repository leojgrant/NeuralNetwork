using NeuralNetwork.Service.Neuron;
using NeuralNetwork.Service.Optimisers;

namespace NeuralNetwork.Service.Synapse;

public class Synapse
{
    public double Weight { get; set; }

    public double dL_dh {  get; set; }

    public INeuron InputNeuron { get; set; }

    public INeuron OutputNeuron { get; set; }

    public IOptimiser Optimiser { get; set; }

    public void UpdateWeight(double dL_dho)
    {
        double dL_dW = this.Calculate_dL_dW(dL_dho);
        Optimiser.UpdateWeight(this.Weight, dL_dW);
        this.Update_dL_dh(dL_dho);
    }

    private double Calculate_dL_dW(double dL_dho)
    {
        // dL_dW = dZ_dW * dh_dW * dL_dh
        double dZo_dW = this.InputNeuron.h;
        double dho_dZ = this.OutputNeuron.ActivationFunction.Calculate_dh_dZ(this.OutputNeuron.h);
        return dZo_dW * dho_dZ * dL_dho;
    }

    private void Update_dL_dh(double dL_dho)
    {
        double dZo_dhi = this.Weight;
        double dho_dZo = this.OutputNeuron.h;
        this.dL_dh = dZo_dhi * dho_dZo * dL_dho;
    }
}
