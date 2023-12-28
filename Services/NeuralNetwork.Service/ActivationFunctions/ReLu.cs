﻿using NeuralNetwork.Service.Activation_Functions;

namespace NeuralNetwork.Service.ActivationFunctions;

public class ReLu : IActivationFunction
{
    public double Calculate_h(double Z)
    {
        if (Z > 0)
        {
            return Z;
        }
        return 0;
    }

    public double Calculate_dh_dZ(double h)
    {
        if (h > 0)
        {
            return 1;
        }
        return 0;
    }
}
