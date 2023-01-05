Layer input = new(2, null);
Layer hidden = new(3, input);
Layer output = new(1, hidden);

Network network = new(Activation.LINEAR, input, output, hidden);

float a, b, x, y, rate, C = 0f;

var table = new List<string>();

for (int j = 0; j <= 5; ++j)
{
    for (int i = 0; i <= 5; ++i)
        table.Add(string.Format("{0} {1} {2}", j, i, i + j));
}

var lines = table.ToArray();

File.WriteAllLines("training.txt", lines);
bool minimized = true;

for (int i = 0; i < lines.Length; ++i)
{
    do
    {
        var data = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        a = float.Parse(data[0]);
        b = float.Parse(data[1]);
        y = float.Parse(data[2]);
        x = network.Evaluate(a, b)[0];

        C = x - y;

        if (C > 0)
            rate = 0.008f;
        else
            rate = -0.008f;

        network.Train(rate, new float[] { a, b }, new float[] { y });

        minimized = true;

        for (int j = 0; j < lines.Length; ++j)
        {
            data = lines[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            a = float.Parse(data[0]);
            b = float.Parse(data[1]);
            y = float.Parse(data[2]);
            x = network.Evaluate(a, b)[0];

            C = x - y;

            if (MathF.Round(C) != 0f)
            {
                minimized = false;
                break;
            }
        }
    }
    while (!minimized);
}

for (int i = -5; i <= 5; ++i)
{
    for (int j = -5; j <= 5; ++j)
        Console.WriteLine("{0} + {1} = {2}", i, j, MathF.Round(network.Evaluate(i, j)[0]));
}