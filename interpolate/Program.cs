using System.IO;
using System;

class Program
{
    static public double Newton(double x, int n, double[] MasX, double[] MasY, double step)
    {
        double[,] mas = new double[n + 2, n + 1];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < n + 1; j++)
            {
                if (i == 0)
                    mas[i, j] = MasX[j];
                else if (i == 1)
                    mas[i, j] = MasY[j];
            }
        }
        int m = n;
        for (int i = 2; i < n + 2; i++)
        {
            for (int j = 0; j < m; j++)
            {
                mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
            }
            m--;
        }

        double[] dy0 = new double[n + 1];

        for (int i = 0; i < n + 1; i++)
        {
            dy0[i] = mas[i + 1, 0];
        }

        double res = dy0[0];
        double[] xn = new double[n];
        xn[0] = x - mas[0, 0];

        for (int i = 1; i < n; i++)
        {
            double ans = xn[i - 1] * (x - mas[0, i]);
            xn[i] = ans;
            ans = 0;
        }

        int m1 = n + 1;
        int fact = 1;
        for (int i = 1; i < m1; i++)
        {
            fact = fact * i;
            res = res + (dy0[i] * xn[i - 1]) / (fact * Math.Pow(step, i));
        }

        return res;
    }
    static void Main(string[] args)
    {
        double x = 1;
        double step = 1;
        int n = 3; //nodes
        double[] MasX = new double[] { 0.847, 1.546, 1.834, 2.647, 2.910 };
        double[] MasY = new double[] { 1.104, 1.042, 0.029, -0.344, -0.449 };
        double Res = Newton(x, n, MasX, MasY, step);
        Console.WriteLine("res ={0}", Res);
        Console.ReadKey();
    }
}