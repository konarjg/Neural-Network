using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Layer
{
    public Neuron[] Neurons { get; private set; }

    public Layer(int neurons, Layer left)
    {
        Neurons = new Neuron[neurons];

        for (int i = 0; i < Neurons.Length; ++i)
            Neurons[i] = new Neuron(0f, left);
    }

    public void Process()
    {
        for (int i = 0; i < Neurons.Length; ++i)
            Neurons[i].Activate();
    }

    public void Train(float rate)
    {
        for (int i = 0; i < Neurons.Length; ++i)
            Neurons[i].Train(rate);
    }

    public void SetActivationFunction(Activation activation)
    {
        for (int i = 0; i < Neurons.Length; ++i)
            Neurons[i].ActivationFunction = activation;
    }

    public Neuron this[int index]
    {
        get => Neurons[index]; 
    }
}
