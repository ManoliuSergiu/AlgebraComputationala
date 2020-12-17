using System;
using System.IO;
using System.Runtime.InteropServices;

namespace prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            bool ok;
            double[,] matrix;
            double[] results;

            do
            {
                Console.Write("Insert the number of equations and variables (2<=n<=10): ");
                ok = int.TryParse(Console.ReadLine(), out n);
            } while (!ok&&(n<2||n>10));

            matrix = new double[n, n + 1];
            results = new double[n];

            //citirea elementelor matricii
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("E{0}:",i+1);
                for (int j = 0; j < n+1; j++)
                {
                    if (j == n)
                    {
                        Console.Write(" = ");
                    }
                    else
                    {
                        Console.Write("x{0} * ", j + 1);
                    }
                    double input;
                    ok = double.TryParse(Console.ReadLine(), out input);
                    if (ok)
                        matrix[i, j] = input;
                    else
                        j--;
                }
            }

            //metoda gauss
            for (int i = 0; i < n; i++)
            {
                double pivot = matrix[i, i];
                for (int j = i; j < n+1; j++)
                {
                    matrix[i, j] /= pivot;
                }
                for (int k = i+1; k < n; k++)
                {
                    double multiplier = matrix[k, i];
                    for (int l = i; l < n+1; l++)
                    {
                        matrix[k, l] -= matrix[i, l] * multiplier;
                    }
                }
            }

            //
            results[n - 1] = matrix[n - 1, n];
            for (int i = n - 2; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i+1; j < n; j++)
                {
                    sum += matrix[i, j] * results[j];
                }
                results[i] = matrix[i, n] - sum;
            }

            Console.WriteLine("\nResult:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("x{0} = {1}",i+1,results[i]);
            }
          
        }
    }
}
