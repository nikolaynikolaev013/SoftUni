using System;

public class Program
{
	public static void Main()
	{
		double change = double.Parse(Console.ReadLine());

		int sum = 0;

		while (change > 0)
		{
            if (change >= 2)
            {
				sum++;
				change -= 2;
            }
			else if (change >= 1)
			{
				sum++;
				change -= 1;
			}
			else if (change >= 0.5)
			{
				sum++;
				change -= 0.50;
			}
			else if (change >= 0.2)
			{
				sum++;
				change -= 0.20;
			}
			else if (change >= 0.1)
			{
				sum++;
				change -= 0.10;
			}
			else if (change >= 0.05)
			{
				sum++;
				change -= 0.05;
			}
			else if (change >= 0.02)
			{
				sum++;
				change -= 0.02;
			}
			else if (change < 0.02 && change > 0)
			{
				sum++;
				change -= 0.01;
			}

			change = Math.Round(change, 2);
			if (change <= 0)
			{
				break;
			}
		}
		Console.WriteLine(sum);
	}
}