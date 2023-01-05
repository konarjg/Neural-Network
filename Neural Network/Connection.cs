using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Connection
{
    public Neuron Source { get; private set; }
    public float Weight { get; set; }
    public float Bias { get; set; }

    public Connection(Neuron source, float weight, float bias)
    {
        Source = source;
        Weight = weight;
        Bias = bias;
    }

    public float PassThrough()
    {
        return Weight * Source.Activation + Bias;
    }
}
