using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Activation
{
    LINEAR,
    QUADRATIC,
    EXPONENTIAL,
    LOGARITHMIC,
    LOGISTIC
}

public static class ActivationFunctions
{
    public static float Activate(float x, Activation activation)
    {
        switch (activation)
        {
            case Activation.LINEAR:
                return Linear(x);

            case Activation.QUADRATIC:
                return Quadratic(x);

            case Activation.EXPONENTIAL:
                return Exponential(x);

            case Activation.LOGARITHMIC:
                return Logarithmic(x);

            case Activation.LOGISTIC:
                return Logistic(x);
        }

        throw new ArgumentException();
    }

    public static float Linear(float x)
    {
        return x;
    }

    public static float Quadratic(float x)
    {
        return x * x;
    }

    public static float Exponential(float x)
    {
        return MathF.Exp(x);
    }

    public static float Logarithmic(float x)
    {
        return MathF.Log(x + 1.0f);
    }

    public static float Logistic(float x)
    {
        return MathF.Exp(x) / (MathF.Exp(x) + 1);
    }
}