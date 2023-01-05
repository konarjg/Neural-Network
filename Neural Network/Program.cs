Layer input = new(2, null);
Layer hidden = new(3, input);
Layer output = new(1, hidden);

Network network = new(Activation.LINEAR, input, output, hidden);

float a, b;

Console.Write("Podaj pierwszą liczbę: ");
a = float.Parse(Console.ReadLine());

Console.Clear();

Console.Write("Podaj drugą liczbę: ");
b = float.Parse(Console.ReadLine());

Console.Clear();

Console.WriteLine("{0} + {1} = {2}", a, b, network.Evaluate(a, b)[0]);