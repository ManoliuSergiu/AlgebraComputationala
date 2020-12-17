using System;
using System.IO;
using System.Numerics;
namespace prob_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string path = "input.txt";
            string[] input = File.ReadAllLines(path);
            n = input.Length;
            Complex[,] matrix = new Complex[n,n];
            int x = 0, y = 0 ;

            //Citirea matricii din fisier
            foreach (var line in input)
            {
                y = 0;
                string[] numbers = line.Split('\t');
                foreach (var complexNumber in numbers)
                {
                    string[] data = complexNumber.Split(' ');
                    matrix[x, y] = new Complex(double.Parse(data[0]), double.Parse(data[1]));
                    y++;
                }
                x++;
            }

            //Verificarea daca matricea este hermetica
            bool ok = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j]  != Complex.Conjugate(matrix[j,i]))
                    {
                        ok = false;
                        Console.WriteLine("Matricea nu este hermetica");
                        break;
                    }
                }
                if (!ok)
                {
                    break;
                }
            }
            if (ok)
            {
                Console.WriteLine("Matricea este hermetica");
            }
            
        }
    }
}
