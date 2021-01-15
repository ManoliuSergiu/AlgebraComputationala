using System;
using System.Numerics;
using MathNet.Numerics;
namespace prob4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Grad2();
            Grad3(); 

        }

        private static void Grad3()
        {
            int n = 3;
            double[,] mat = new double[n, n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a{0}{1} = ", i + 1, j + 1);
                    mat[i, j] = double.Parse(Console.ReadLine());
                }
            }

            double a = 1;
            double b = -mat[0, 0] - mat[1, 1] - mat[2, 2];
            double c = -mat[0, 0] * -mat[1, 1] + -mat[1, 1] * -mat[2, 2] + -mat[2, 2] * -mat[0, 0] -
                mat[0,2]*mat[2,0] - mat[1,0]*mat[0,1] - mat[1,2] *mat[2,1];
            double d = -mat[0, 0] * -mat[1, 1] * -mat[2, 2] +
                mat[0, 2] * mat[1, 0] * mat[2, 1] +
                mat[0, 1] * mat[1, 2] * mat[2, 0] -
                mat[2, 0] * mat[0, 2] * -mat[1, 1] -
                mat[1, 0] * mat[0, 1] * -mat[2, 2] -
                mat[1, 2] * mat[2, 1] * -mat[0, 0];
            Console.WriteLine("Polinomul caracteristic asociat este: {0}t^3 + ({1}t^2) + ({2}t) + ({3})", a, b, c, d);

            var aux = MathNet.Numerics.RootFinding.Cubic.RealRoots(d, c, b);

            Console.WriteLine("Radacinile sunt:{0},{1},{2}", aux.Item1, aux.Item2, aux.Item3);
        }

        private static void Grad2()
        {
            int n = 2;
            double[,] mat = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a{0}{1} = ", i + 1, j + 1);
                    mat[i, j] = double.Parse(Console.ReadLine());
                }
            }

            double a = 1;
            double b = -mat[0, 0] + -mat[1, 1];
            double c = mat[0, 0] * mat[1, 1] - (mat[0, 1] * mat[1, 0]);

            Console.WriteLine("Polinomul caracteristic asociat este: {0}t^2 + ({1}t) + ({2})", a, b, c);

            var delta = b * b - 4 * a * c;
            Console.WriteLine(delta);

            var t1 = (-b + Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine("t1 = {0}", t1);
            if (delta > 0)
            {
                var t2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("t2 = {0}", t2);
            }
        }
    }
}
