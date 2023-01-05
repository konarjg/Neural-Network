using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Network
{
    public Layer Input { get; private set; }
    public Layer[] Hidden { get; private set; }
    public Layer Output { get; private set; }

    public Network(Activation activationFunction, Layer input, Layer output, params Layer[] hidden)
    {
        Input = input;
        Hidden = hidden;
        Output = output;

        Input.SetActivationFunction(activationFunction);
        Output.SetActivationFunction(activationFunction);

        for (int i = 0; i < Hidden.Length; ++i)
            Hidden[i].SetActivationFunction(activationFunction);
    }

    public float[] Evaluate(params float[] input)
    {
        if (input.Length != Input.Neurons.Length)
            throw new ArgumentException();

        for (int i = 0; i < input.Length; ++i)
            Input[i].Activation = input[i];

        var output = new float[Output.Neurons.Length];

        for (int i = 0; i < Hidden.Length; ++i)
            Hidden[i].Process();

        Output.Process();

        for (int i = 0; i < output.Length; ++i)
            output[i] = Output[i].Activation;

        return output;
    }
}
