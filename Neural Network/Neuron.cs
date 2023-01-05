using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Neuron
{
    public Activation ActivationFunction { get; set; }
    public float Activation { get; set; }
    public Connection[] Connections { get; private set; }

    public Neuron(float value, Layer left)
    {
        Activation = value;

        if (left != null)
        {
            Connections = new Connection[left.Neurons.Length];

            for (int i = 0; i < Connections.Length; ++i)
                Connections[i] = new Connection(left.Neurons[i], 0.1f, 0f);
        }
        else
            Connections = new Connection[0];
    }

    public void Activate()
    {
        var val = 0f;

        for (int i = 0; i < Connections.Length; ++i)
            val += Connections[i].PassThrough();

        Activation = ActivationFunctions.Activate(val, ActivationFunction);
    }
}
