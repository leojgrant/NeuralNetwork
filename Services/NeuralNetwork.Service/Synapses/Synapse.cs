using NeuralNetwork.Service.Neurons;
using NeuralNetwork.Service.Optimisers;

namespace NeuralNetwork.Service.Synapses;

public class Synapse : ISynapse
{
    public double Weight { get; set; }

    public double dL_dhi {  get; set; }

    public INeuron InputNeuron { get; set; }

    public INeuron OutputNeuron { get; set; }

    public IOptimiser Optimiser { get; set; }

    public Synapse(INeuron inputNeuron, INeuron outputNeuron, IOptimiser optimiser)
    {
        this.InputNeuron = inputNeuron;
        this.OutputNeuron = outputNeuron;
        this.Optimiser = optimiser;
        this.Weight = 1;
        this.dL_dhi = 0;
    }

    public void UpdateWeight(double dL_dho)
    {
        double dL_dW = this.Calculate_dL_dW(dL_dho);
        this.Weight = Optimiser.CalculateImprovedWeight(this.Weight, dL_dW);
        //Console.WriteLine(this.Weight);
        this.Update_dL_dhi(dL_dho);
    }

    private double Calculate_dL_dW(double dL_dho)
    {
        // dL_dW = dZ_dW * dh_dW * dL_dh
        double dZo_dW = this.InputNeuron.h;
        double dho_dZ = this.OutputNeuron.ActivationFunction.Calculate_dh_dZ(this.OutputNeuron.h);
        return dZo_dW * dho_dZ * dL_dho;
    }

    private void Update_dL_dhi(double dL_dho)
    {
        double dZo_dhi = this.Weight;
        double dho_dZo = this.OutputNeuron.h;
        this.dL_dhi = dZo_dhi * dho_dZo * dL_dho;
    }
}
